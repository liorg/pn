using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using MoinLocalGovDataService.DataLayer;
using EntityLayer;

namespace MoinLocalGovDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class MoinLocalGovService : IMoinLocalGovService
    {


        public string GetLawSubjects()
        {
            string retVal = string.Empty;
            try
            {
                LawSubjectsDataContext db = new LawSubjectsDataContext();
                var itemsList = db.GetLawSubjects();
                XElement itemsXml = new XElement("items",
                    from item in itemsList 
                    select new XElement("item", 
                        new XElement("value", item.SubjectID),
                        new XElement("text", item.SubjectName)));               
                retVal = itemsXml.ToString();      
               
            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetLawSubjects() - " + ex.Message);
            }
         /*   int i = "k";
            LawSubjectsDataContext db = new LawSubjectsDataContext();
            var itemsList = db.GetLawSubjects();
            XElement itemsXml = new XElement("items",
                from item in itemsList
                select new XElement("item",
                    new XElement("value", item.SubjectID),
                    new XElement("text", item.SubjectName)));
            retVal = itemsXml.ToString();
            Exceptions.WriteToLogFile("GetLawSubjects() - " );

*/


            return retVal;
        }

        public string GetLaws(int subjectID, int fromRow, int toRow)
        {
            string retVal = string.Empty;
            try
            {
                LawSubjectsDataContext db = new LawSubjectsDataContext();
                var itemsList = db.GetLaws(subjectID, -1, fromRow, toRow);
                XElement itemsXml = new XElement("laws",
                    from item in itemsList
                    select new XElement("law",
                        new XAttribute("rownum",item.rownum),
                        new XAttribute("totalRows",item.totalRows),
                        new XElement("lawID", item.LawID),
                        new XElement("lawName", item.LawName.Trim()),
                        new XElement("date", item.DateRecord),
                       // new XElement("rashutID", item.RashutNumLms),
                        new XElement("rashutName", item.Shem_Rashut),  
                        //new XElement("subjectID", item.SubjectID),
                        new XElement("subjectName", item.SubjectName.Trim())));
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetLaws(" + subjectID.ToString() + ") - " + ex.Message);
            }
            return retVal;
        }

        public string GetRashutLaws(int rashut_Lms, int fromRow, int toRow)////////////
        {
            string retVal = string.Empty;
            try
            {
                LawSubjectsDataContext db = new LawSubjectsDataContext();
                var itemsList = db.GetLaws(-1, rashut_Lms, fromRow, toRow);
                XElement itemsXml = new XElement("laws",
                    from item in itemsList
                    select new XElement("law",
                        new XAttribute("rownum", item.rownum),
                        new XAttribute("totalRows", item.totalRows),
                        new XElement("lawID", item.LawID),
                        new XElement("lawName", item.LawName.Trim()),
                        new XElement("date", item.DateRecord),
                        // new XElement("rashutID", item.RashutNumLms),
                       // new XElement("rashutName", item.Shem_Rashut),
                        //new XElement("subjectID", item.SubjectID),
                        new XElement("subjectName", item.SubjectName.Trim())));
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetRashutLaws(" + rashut_Lms.ToString() + ") - " + ex.Message);
            }
            return retVal;
        }

        public DocumentContent GetLawContent(int lawID)
        {
            DocumentContent retVal = null;
            try
            {
                LawSubjectsDataContext db = new LawSubjectsDataContext();
                var itemsList = db.GetLawContent(lawID).First();

                retVal = new DocumentContent(itemsList.Content.ToArray(), itemsList.Extention);               

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetLawContent(" + lawID.ToString() + ") - " + ex.Message);
            }
            return retVal;

        }

        public string GetInspectionDocuments(int typeID, int year, int fromRow, int toRow)
        {
            string retVal = string.Empty;
            try
            {
                DocumentsDataContext db = new DocumentsDataContext();
                var itemsList = db.GetDocumentsInspection(year, typeID, fromRow, toRow);
                XElement itemsXml = new XElement("documents",
                    from item in itemsList
                    select new XElement("document",
                        new XAttribute("rownum", item.rownum),
                        new XAttribute("totalRows", item.totalRows),
                        new XElement("docType", item.DocTypeName.Trim()),
                        new XElement("docID", item.DocId),
                        new XElement("docName", item.DocName.Trim()),                     
                        new XElement("rashutName", item.Shem_Rashut)));                	
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetInspectionDocuments(" + typeID.ToString() + ", " + year.ToString() + ") - " + ex.Message);
            }
            return retVal;
        }

        public string GetInspactionDocumentTypes()
        {
            string retVal = string.Empty;
            try
            {
               DocumentsDataContext db = new DocumentsDataContext();
               var itemsList = db.GetDocumentsTypesInsp();
                XElement itemsXml = new XElement("items",
                    from item in itemsList
                    select new XElement("item",
                        new XElement("value", item.DocTypeID),
                        new XElement("text", item.DocTypeName)));
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetInspactionDocumentTypes() - " + ex.Message);
            }

            return retVal;
        }

        public DocumentContent GetDocumentContent(int docID)
        {
            DocumentContent retVal = null;
            try
            {
                DocumentsDataContext db = new DocumentsDataContext();
                var itemsList = db.GetDocumentContent(docID).First();

                retVal = new DocumentContent(itemsList.DocPath.ToArray(), itemsList.DocExtention);

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetDocumentContent(" + docID.ToString() + ") - " + ex.Message);
            }
            return retVal;

        }

        public string GetMeafyen(int numRashut)
        {
            string retVal = string.Empty;
            try
            {
              
                MeafyenDataContext db = new MeafyenDataContext();
                var itemsList = db.GetRashutMeafyenim(numRashut);
               
                   XElement itemsXml = new XElement("Root",
                       from item in itemsList
                       select new XElement("meafeyn",
                            new XAttribute("Id",item.NumMeafyen),
                            new XAttribute("TypeMeafyen", item.TypeMeafyen),
                            new XAttribute("IsSelection", item.IsSelection),
                            new XElement("Name", item.NameMeafyen),
                            new XElement("ValueId", item.ValueId),
                            new XElement("ValueName", item.ValueName),
                            new XElement("StringValue", item.StringValue.Trim()),
                            new XElement("DateValue", item.DateValue),
                            new XElement("NumericValue", item.NumericValue),
                            new XElement("Shem_Rashut", item.Shem_Rashut)));

            
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetMeafyen(" + numRashut.ToString() + ") - " + ex.Message);
            }
            return retVal;
        }

        public string GetElectionDocuments(DateTime fromDate, DateTime toDate, int fromRow, int toRow)
        {
            string retVal = string.Empty;
            try
            {
                DocumentsDataContext db = new DocumentsDataContext();
                var itemsList = db.GetDocumentsElection(fromRow, toRow, fromDate, toDate);
                XElement itemsXml = new XElement("documents",
                    from item in itemsList
                    select new XElement("document",
                        new XAttribute("rownum", item.rownum),
                        new XAttribute("totalRows", item.totalRows),
                        new XElement("docType", item.DocTypeName.Trim()),
                        new XElement("docID", item.DocId),
                        new XElement("docName", item.DocName.Trim()),
                        new XElement("rashutName", item.Shem_Rashut),
                        new XElement("docDate", item.AcceptDate),
                        new XElement("docYear", item.DocYear)));
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetElectionDocuments(" + fromDate.ToString() + ", " + toDate.ToString() + ") - " + ex.Message);
            }
            return retVal;
        }

        public string GetPortalDocumentsTypes() //***
        {
            string retVal = string.Empty;
              try
              {
                  DocumentsDataContext db = new DocumentsDataContext();
                  var itemsList = db.GetPortalDocumentsTypes();
                  XElement itemsXml = new XElement("Root",
                        from item in itemsList
                        select new XElement("type",
                               new XElement("DocMainTypeID", item.DocMainTypeID),
                               new XElement("SysNo", item.SysNo),
                               new XElement("DocMainTypeName", item.DocMainTypeName)));
                       retVal = itemsXml.ToString();

              }
              catch (Exception ex)
              {
                  Exceptions.WriteToLogFile("GetPortalDocumentsTypes() - " + ex.Message);
              }

            return retVal;
        }

        public string GetRashuoyt() 
        {
            string retVal = string.Empty;
            try
            {
                RashutDataContext db = new RashutDataContext();
                var itemsList = db.GetRashuyot();
                XElement itemsXml = new XElement("items",
                    from item in itemsList
                    select new XElement("item",
                        new XElement("value", item.Kod_Rashut_Lms),
                        new XElement("text", item.Shem_Rashut)));
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetRashuoyt() - " + ex.Message);
            }

            return retVal;
        }


        public string GetRashutDocuments(int typeID, int numRashut, int fromRow, int toRow)
        {
            string retVal = string.Empty;
            try
            {
                DocumentsDataContext db = new DocumentsDataContext();
                var itemsList = db.GetReportDocumentsRashut(typeID, numRashut, fromRow, toRow);
                XElement itemsXml = new XElement("documents",
                    from item in itemsList
                    select new XElement("document",
                        new XAttribute("rownum", item.rownum),
                        new XAttribute("totalRows", item.totalRows),
                        new XElement("docYear", item.DocYear),
                        new XElement("docName", item.DocName.Trim()),
                        new XElement("docID", item.DocId),
                        new XElement("docDate", item.AcceptDate),
                        new XElement("docType", item.DocTypeName.Trim())));
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetReportDocumentsRashut(" + typeID.ToString() + ", " + numRashut.ToString() + ") - " + ex.Message);
            }
            return retVal;
        }

        public string GetRelatedEntities(int rashutID, int fromRow, int toRow)
        {
            string retVal = string.Empty;
            try
            {
                RashutDataContext db = new RashutDataContext();
                int i=0;
                var itemsList = db.GLOBAL_GetRelatedEntitiesForRashut(rashutID, fromRow, toRow);               
                XElement itemsXml = new XElement("items",
                    from item in itemsList
                    select new XElement("entity",
                         new XAttribute("rownum", item.rownum),
                        new XAttribute("totalRows", item.totalRows),
                        new XElement("name", item.RelatedEntityName),
                        new XElement("id", item.RelatedEntityID),
                        new XElement("mainType", item.MainTypeName),
                         new XElement("subType", item.SubTypeName),
                          new XElement("startDate", item.DateStart),
                          new XElement("participating", item.Participating)
                        ));
                retVal = itemsXml.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.WriteToLogFile("GetInspactionDocumentTypes() - " + ex.Message);
            }

            return retVal;
        }
        
    }
}
