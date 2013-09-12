using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using ManageEvacuateds.DataObjects;
using ManageEvacuees.Moduls;

namespace ManageEvacuateds
{
    /// <summary>
    /// Summary description for WebHandler1
    /// </summary>
    public class WebHandler1 : IHttpHandler
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
            
            string methodName = context.Request.QueryString["method"];

            switch (methodName.ToLower())
            {
                case "searchevacuateds":
                    SearchEvacuateds(context);
                    break;
                case "searchequipment":
                    SearchEquipment(context);
                    break;
                case "getareas":
                    GetAreas(context);
                    break;
                case "getcities":
                    GetCities(context);
                    break;
                default:
                    break;
            }
        }

        private void GetAreas(HttpContext context)
        {
            //List<KeyValuePair<int, string>> areas = new List<KeyValuePair<int, string>>();
            //areas.Add(new KeyValuePair<int, string>(1, "מרכז"));
            //areas.Add(new KeyValuePair<int, string>(2, "צפון"));
            //areas.Add(new KeyValuePair<int, string>(3, "דרום"));

            var areas = ManageAddresses.GetAreas();

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(areas);
            context.Response.Write(json);
        }

        private void GetCities(HttpContext context)
        {
            int areaId = Convert.ToInt32(context.Request.QueryString["area"]);
            List<KeyValuePair<int, string>> cities = new List<KeyValuePair<int, string>>();
            switch (areaId)
            {
                case 1:
                    cities.Add(new KeyValuePair<int, string>(1, "תל אביב"));
                    cities.Add(new KeyValuePair<int, string>(3, "פתח תקוה"));
                    cities.Add(new KeyValuePair<int, string>(4, "רמת גן"));
                    break;
                case 2:
                    cities.Add(new KeyValuePair<int, string>(1, "חיפה"));
                    cities.Add(new KeyValuePair<int, string>(2, "זכרון יעקב"));
                    cities.Add(new KeyValuePair<int, string>(3, "טבריה"));
                    break;
                case 3:
                    cities.Add(new KeyValuePair<int, string>(1, "באר שבע"));
                    cities.Add(new KeyValuePair<int, string>(2, "דימונה"));
                    cities.Add(new KeyValuePair<int, string>(3, "ערד"));
                    break;
                default:
                    break;

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(cities);
            context.Response.Write(json);
        }

        private void SearchEquipment(HttpContext context)
        {
            JqGridDataObject<EvacuatedResultDataItem> dataObject = new JqGridDataObject<EvacuatedResultDataItem>();

            dataObject.colNames = new List<string>() 
            { 
                "שם משפחה", 
                "שם פרטי", 
                "שם האב", 
                "רשות מקומית", 
                "כתובת מגורים", 
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
                new JqGridColModel() { name = "LastName", index = "LastName", sorttype = "string", width = 50},
                new JqGridColModel() { name = "FirstName", index = "FirstName", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "FatherName", index = "FatherName", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "LocalArea", index = "LocalArea", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "Address", index = "Address", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "Gender", index = "Gender", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "Age", index = "Age", sorttype = "int", width = 50 },
                new JqGridColModel() { name = "CurrentInSite", index = "CurrentInSite", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "EqLocalArea", index = "EqLocalArea", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "EquipName", index = "EquipName", sorttype = "string", width = 50 },
                new JqGridColModel() { name = "EqAddress", index = "EqAddress", sorttype = "string", width = 50},
                new JqGridColModel() { name = "EqTelephone", index = "EqTelephone", sorttype = "string", width = 50 }
            };
            
            dataObject.datastr = new List<EvacuatedResultDataItem>()
            {
                new EvacuatedResultDataItem()
                {
                    //evacuatedDetails = new EvacuatedDetails()
                    //{
                        LastName = "כהן",
                        FirstName = "משה",
                        FatherName = "חיים",
                        LocalArea = "מרכז",
                        Address = "הכרמל 13",
                        Gender = "זכר",
                        Age = 45,
                        CurrentInSite = "מקלט 3",
                    //},
                    //equipmentResult = new EquipmentResult() 
                    //{
                        EqLocalArea = "שרון",
                        EquipName = "כרמלית",
                        EqAddress = "הנרקיסים 4",
                        EqTelephone = "09-6767676"
                    //}
                },
                new EvacuatedResultDataItem()
                {
                    //evacuatedDetails = new EvacuatedDetails()
                    //{
                        LastName = "לוי",
                        FirstName = "יצחק",
                        FatherName = "דוד",
                        LocalArea = "שפלה",
                        Address = "הפלמח 2",
                        Gender = "זכר",
                        Age = 50,
                        CurrentInSite = "מקלט 4",
                    //},
                    //equipmentResult = new EquipmentResult() 
                    //{
                        EqLocalArea = "שפלה",
                        EquipName = "פרפר",
                        EqAddress = "ירושלים 54",
                        EqTelephone = "09-7878787"
                    //}
                }
            };

            JqGridResult<EvacuatedResultDataItem> result = new JqGridResult<EvacuatedResultDataItem>()
            {
                jqGridDataObject = dataObject,
                groupHeaders = new GroupHeaders()
                {
                    groupHeaders = new List<GroupHeader>()
                    {
                        new GroupHeader(){startColumnName = "LastName", numberOfColumns = 8, titleText = "פרטי המפונה"},
                        new GroupHeader(){startColumnName = "EqLocalArea", numberOfColumns = 4, titleText = "פרטי המתקן"}
                    }
                }
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(result);
            context.Response.Write(json); 
        }

        private void SearchEvacuateds(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Age", typeof(string));

            DataRow row = dt.NewRow();
            row["FirstName"] = "Sara";
            row["LastName"] = "Shats";
            row["Age"] = "25";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["FirstName"] = "Yosef";
            row["LastName"] = "Shats";
            row["Age"] = "26";
            dt.Rows.Add(row);

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string json = js.Serialize(ds.GetXml());
            context.Response.Write(ds.GetXml());
        }
    }
}