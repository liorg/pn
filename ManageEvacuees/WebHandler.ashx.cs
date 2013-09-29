using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Caching;
using System.Web.Script.Serialization;
using ManageEvacuees.DataObjects;
using ManageEvacuees.Moduls;
using ManageEvacuees.NSMefonimGovService;
using System.Globalization;

namespace ManageEvacuees
{
    /// <summary>
    /// Summary description for WebHandler
    /// </summary>
    public class WebHandler : IHttpHandler
    {

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jsonString = context.Request.Params[0];
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            Dictionary<string, object> jsData = (Dictionary<string, object>)jsonSerializer.DeserializeObject(jsonString);

            string methodName = jsData["method"].ToString();


            switch (methodName.ToLower())
            {
                case "searchevacuees":
                    SearchEvacuees(context, jsData);
                    break;
                case "searchequipment":
                    SearchEquipment(context, jsData);
                    break;
                case "getmahos":
                    GetMahos(context, jsData);
                    break;
                case "getareas":
                    GetAreas(context, jsData);
                    break;
                case "getequipment":
                    GetEquipment(context, jsData);
                    break;
                case "getcities":
                    GetCities(context, jsData);
                    break;
                case "getstreets":
                    GetStreets(context, jsData);
                    break;
                default:
                    break;
            }
        }

        #region Get Search Results To Client

        private void SearchEquipment(HttpContext context, Dictionary<string, object> jsData)
        {
            JqGridDataObject<ReportMitkanim> dataObject = BuildEquipmentColModel();
            int mahozId, mitkanNum, rashutId;

            if (jsData["mahoz"] == null || !int.TryParse(jsData["mahoz"].ToString(), out mahozId))
            {
                mahozId = -1;
            }
            if (jsData["area"] == null || !int.TryParse(jsData["area"].ToString(), out rashutId))
            {
                rashutId = -1;
            }
            if (jsData["equip"] == null || !int.TryParse(jsData["equip"].ToString(), out mitkanNum))
            {
                mitkanNum = -1;
            }

            SearchMitkanimResponse response = ManageSearch.SearchEquipment(mahozId, mitkanNum, rashutId);

            if (response != null && !response.IsError)
            {
                dataObject.datastr = response.Data.ToList();
            }
            
            JqGridResult<ReportMitkanim> result = new JqGridResult<ReportMitkanim>()
            {
                jqGridDataObject = dataObject
            };

            if (response.IsError)
            {
                result.errorMessage = response.ErrorDesc;
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(result);
            context.Response.Write(json); 
        }

        private void SearchEvacuees(HttpContext context, Dictionary<string, object> jsData)
        {
            JqGridDataObject<ShiltonMekomi> dataObject = BuildEvacueesColModel();

            #region Fill Values in Vars
            int? AreaId = null, CityId = null, streetId = null, EqMahozId = null, equipId = null;
            DateTime? DateIncomeBegin = null, DateIncomeEnd = null;
            long? IdNumber = null;

            if (jsData["AreaId"] != null && !string.IsNullOrEmpty(jsData["AreaId"].ToString()))
            {
                AreaId = int.Parse(jsData["AreaId"].ToString());
            }
            if (jsData["EqMahozId"] != null && !string.IsNullOrEmpty(jsData["EqMahozId"].ToString()))
            {
                EqMahozId = int.Parse(jsData["EqMahozId"].ToString());
            }
            if (jsData["equipId"] != null && !string.IsNullOrEmpty(jsData["equipId"].ToString()))
            {
                equipId = int.Parse(jsData["equipId"].ToString());
            }
            if (jsData["City"] != null && !string.IsNullOrEmpty(jsData["City"].ToString()))
            {
                CityId = GetCitiesCache(context)
                    .Where(c => c.YeshuvName == jsData["City"].ToString())
                    .Select(c => c.YeshuvNum)
                    .FirstOrDefault();
            }
            if (jsData["street"] != null && !string.IsNullOrEmpty(jsData["street"].ToString()))
            {
                streetId = GetStreetsCache(context)
                    .Where(s => s.StName == jsData["street"].ToString())
                    .Select(s => s.StNum)
                    .FirstOrDefault();
            }
            if (jsData["DateIncomeBegin"] != null && !string.IsNullOrEmpty(jsData["DateIncomeBegin"].ToString()))
            {
                string[] formats = { "MM/dd/yyyy" };
                DateIncomeBegin = DateTime.ParseExact(jsData["DateIncomeBegin"].ToString(), formats, new CultureInfo("he-IL"), DateTimeStyles.None);
            }
            if (jsData["DateIncomeEnd"] != null && !string.IsNullOrEmpty(jsData["DateIncomeEnd"].ToString()))
            {
                string[] formats = { "MM/dd/yyyy" };
                DateIncomeEnd = DateTime.ParseExact(jsData["DateIncomeEnd"].ToString(), formats, new CultureInfo("he-IL"), DateTimeStyles.None);
            }
            if (jsData["IdNumber"] != null && !string.IsNullOrEmpty(jsData["IdNumber"].ToString()))
            {
                IdNumber = long.Parse(jsData["IdNumber"].ToString());
            }
            #endregion

            SearchResponse response = ManageSearch.SearchEvacuees(jsData["firstName"] != null? jsData["firstName"].ToString() : null,
                                                      jsData["lastName"] != null ? jsData["lastName"].ToString() : null,
                                                      jsData["fatherName"] != null ? jsData["fatherName"].ToString() : null,
                                                      jsData["gender"] != null ? jsData["gender"].ToString() : null, 
                                                      IdNumber, 
                                                      DateIncomeBegin, 
                                                      DateIncomeEnd, 
                                                      AreaId, 
                                                      CityId, 
                                                      streetId, 
                                                      EqMahozId, 
                                                      equipId);

            if (!response.IsError)
            {
                dataObject.datastr = response.ShiltonMekomi.ToList();
            }
            JqGridResult<ShiltonMekomi> result = new JqGridResult<ShiltonMekomi>()
            {
                jqGridDataObject = dataObject,
                groupHeaders = new GroupHeaders()
                {
                    groupHeaders = new List<GroupHeader>()
                    {
                        //new GroupHeader(){startColumnName = "LastName", numberOfColumns = 10, titleText = "פרטי מפונה"},
                        new GroupHeader(){startColumnName = "LocalArea", numberOfColumns = 4, titleText = "כתובת מגורים"},
                        new GroupHeader(){startColumnName = "EqLocalArea", numberOfColumns = 4, titleText = "פרטי מרכז קליטה"}
                    }
                }
            };

            if (response.IsError)
            {
                result.errorMessage = response.ErrorDesc;
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(result);
            context.Response.Write(json); 
        }

        private static JqGridDataObject<ReportMitkanim> BuildEquipmentColModel()
        {
            JqGridDataObject<ReportMitkanim> dataObject = new JqGridDataObject<ReportMitkanim>();

            dataObject.colNames = new List<string>() 
            { 
                "מחוז", 
                "רשות", 
                "שם מרכז קליטה", 
                "כתובת", 
                "סה\"כ קלוטים במרכז קליטה", 
                "סה\"כ קלוטים בטווח גילאים: 0-3", 
                "סה\"כ קלוטים בטווח גילאים: 4-6", 
                "סה\"כ קלוטים בטווח גילאים: 7-18", 
                "סה\"כ קלוטים בטווח גילאים: 19-65", 
                "סה\"כ קלוטים בטווח גילאים 66+"
            };
            
            dataObject.colModel = new List<JqGridColModel>()
            {
                new JqGridColModel() { name = "MahozName", index = "MahozName", sorttype = "string", width = 64},
                new JqGridColModel() { name = "RashutName", index = "RashutName", sorttype = "string", width = 68 },
                new JqGridColModel() { name = "MitkanName", index = "MitkanName", sorttype = "string", width = 68 },
                new JqGridColModel() { name = "MitkanAddress", index = "MitkanAddress", sorttype = "string", width = 68 },
                new JqGridColModel() { name = "SumAll", index = "SumAll", sorttype = "int", width = 68 },
                new JqGridColModel() { name = "Sum3", index = "Sum3", sorttype = "int", width = 68 },
                new JqGridColModel() { name = "Sum4To6", index = "Sum4To6", sorttype = "int", width = 68 },
                new JqGridColModel() { name = "Sum7To18", index = "Sum7To18", sorttype = "int", width = 68 },
                new JqGridColModel() { name = "Sum19To65", index = "Sum19To65", sorttype = "int", width = 68 },
                new JqGridColModel() { name = "Sum66", index = "Sum66", sorttype = "int", width = 68 }
            };
            return dataObject;
        }

        private static JqGridDataObject<ShiltonMekomi> BuildEvacueesColModel()
        {
            JqGridDataObject<ShiltonMekomi> dataObject = new JqGridDataObject<ShiltonMekomi>();

            dataObject.colNames = new List<string>() 
            { 
                "שם משפחה", 
                "שם פרטי", 
                "שם האב", 
                "רשות מקומית", 
                "ישוב", 
                "רחוב", 
                "מספר", 
                "מין", 
                "גיל", 
                "נמצא כרגע באתר פינוי",
                "רשות מקומית",
                "שם מתקן",
                "כתובת",
                "טלפון"
            };
            
            dataObject.colModel = new List<JqGridColModel>()
            {
                new JqGridColModel() { name = "MfLastName", index = "MfLastName", sorttype = "string", width = 50},
                new JqGridColModel() { name = "MfFirstName", index = "MfFirstName", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "MfFather", index = "MfFather", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "", index = "", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "", index = "", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "", index = "", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "MfAddHouseNum", index = "MfAddHouseNum", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "MfGender", index = "MfGender", sorttype = "string", width = 30 },
                new JqGridColModel() { name = "MfAge", index = "MfAge", sorttype = "int", width = 30 },
                new JqGridColModel() { name = "IsMfDateOutcome", index = "IsMfDateOutcome", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "Mitkan.Rashut.RashutName", index = "Mitkan.Rashut.RashutName", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "Mitkan.MitkanName", index = "Mitkan.MitkanName", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "Mitkan.MitkanAddress", index = "Mitkan.MitkanAddress", sorttype = "string", width = 50},
                new JqGridColModel() { name = "Mitkan.MitkanPhone", index = "Mitkan.MitkanPhone", sorttype = "string", width = 50 }
            };
            return dataObject;
        }

        #endregion

        #region Get Adresses Lists To Client

        private void GetMahos(HttpContext context, Dictionary<string, object> jsData)
        {
            Mehozot[] mehozot = GetMahozCache(context);
            //string let = jsData["letters"].ToString();

            //if (!string.IsNullOrEmpty(let))
            //{
            //    Mehozot[] selectedMahoz = mehozot.Where(a => a.MahozName.StartsWith(let)).ToArray();
            //    mehozot = selectedMahoz;
            //}

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(mehozot);
            context.Response.Write(json);
        }

        private void GetAreas(HttpContext context, Dictionary<string, object> jsData)
        {
            Rashuyot[] areas = GetAreasCache(context);
            //string let = jsData["letters"].ToString();
            string mahoz = jsData["mahoz"] != null ? jsData["mahoz"].ToString() : null;
            int mahozNum;

            if (!string.IsNullOrEmpty(mahoz) && int.TryParse(mahoz, out mahozNum))
            {
                Rashuyot[] selectedAreas = areas.Where(a => a.Mehoz.MahozNum == mahozNum).ToArray();
                areas = selectedAreas;
            }

            //if (!string.IsNullOrEmpty(let))
            //{
            //    Rashuyot[] selectedAreas = areas.Where(a => a.RashutName.StartsWith(let)).ToArray();
            //    areas = selectedAreas;
            //}

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(areas);
            context.Response.Write(json);
        }

        private void GetEquipment(HttpContext context, Dictionary<string, object> jsData)
        {
            Mitkanim[] equip = GetEquipmentCache(context);
            string area = jsData["area"] != null ? jsData["area"].ToString() : null;
            int areaId;

            if (!string.IsNullOrEmpty(area) && int.TryParse(area, out areaId))
            {
                Mitkanim[] selectedEquip = equip.Where(a => a.Rashut.RashutID == areaId).ToArray();
                equip = selectedEquip;
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(equip);
            context.Response.Write(json);
        }

        private void GetCities(HttpContext context, Dictionary<string, object> jsData)
        {
            Yeshuvim[] cities = GetCitiesCache(context);
            string let = jsData["letters"].ToString();
            string area = jsData["area"].ToString();

            //if (!string.IsNullOrEmpty(area))
            //{
            //    //Get Area Id
            //    if (context.Cache["Areas"] == null)
            //        context.Cache["Areas"] = ManageAddresses.GetAreas();
            //    Rashuyot[] areas = (Rashuyot[])context.Cache["Areas"];
            //    int areaId = areas.Where(a => a.RashutName == area).Select(a => a.RashutID).FirstOrDefault();

            //    //Get associated cities
            //    Yeshuvim[] selectedCities = cities.Where(s => s.).ToArray();
            //    cities = selectedCities;
            //}

            if (!string.IsNullOrEmpty(let))
            {
                Yeshuvim[] selectedCities = cities.Where(s => s.YeshuvName.StartsWith(let)).ToArray();
                cities = selectedCities;
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(cities);
            context.Response.Write(json);
        }

        private void GetStreets(HttpContext context, Dictionary<string, object> jsData)
        {
            Address[] streets = GetStreetsCache(context);
            string let = jsData["letters"].ToString();
            string city = jsData["city"].ToString();

            if (!string.IsNullOrEmpty(city))
            {
                //Get associated streets
                Address[] selectedStreets = streets.Where(s => (s.YeshuvName == city)).ToArray();
                streets = selectedStreets;
            }

            if (!string.IsNullOrEmpty(let))
            {
                Address[] selectedStreets = streets.Where(s => s.StName.StartsWith(let)).ToArray();
                streets = selectedStreets;
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(streets);
            context.Response.Write(json);
        }

        #endregion

        #region Manage Cache

        private Mehozot[] GetMahozCache(HttpContext context)
        {
            if (context.Cache["Mahos"] == null)
            {
                Mehozot[] mehozot = GetEquipmentCache(context)
                                    .GroupBy(r => r.Rashut.Mehoz.MahozNum)
                                    .Select(g => g.First().Rashut.Mehoz)
                                    .ToArray();
                context.Cache["Mahos"] = mehozot;
            }
            
            return (Mehozot[])context.Cache["Mahos"];
        }

        private Rashuyot[] GetAreasCache(HttpContext context)
        {
            if (context.Cache["Areas"] == null)
            {
                //context.Cache["Areas"] = ManageAddresses.GetAreas();
                Rashuyot[] rashuyot = GetEquipmentCache(context)
                                    .GroupBy(r => r.Rashut.RashutID)
                                    .Select(g => g.First().Rashut)
                                    .ToArray();
                context.Cache["Areas"] = rashuyot;
            }
            return (Rashuyot[])context.Cache["Areas"];
        }

        private Yeshuvim[] GetCitiesCache(HttpContext context)
        {
            if (context.Cache["Cities"] == null)
                context.Cache["Cities"] = ManageAddresses.GetCities();
            return (Yeshuvim[])context.Cache["Cities"];
        }

        private Address[] GetStreetsCache(HttpContext context)
        {
            if (context.Cache["Streets"] == null)
                context.Cache["Streets"] = ManageAddresses.GetStreets();
            return (Address[])context.Cache["Streets"];
        }

        private Mitkanim[] GetEquipmentCache(HttpContext context)
        {
            if (context.Cache["Equipment"] == null)
                context.Cache["Equipment"] = ManageEquipment.GetEquipment();
            return (Mitkanim[])context.Cache["Equipment"];
        }

        #endregion
    }
}