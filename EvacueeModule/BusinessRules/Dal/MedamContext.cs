using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Guardian.Moin.EvacueeModule.DataContract;
using Guardian.Moin.EvacueeModule.DataModel;

namespace Guardian.Moin.EvacueeModule.Dal
{
    internal class MedamContext : BaseService
    {

        internal MedamContext(string connString, Action<string> log, Action<string> error)
            : base(connString, log, error)
        {

        }

        internal Result<bool> Login(string userName, string pws)
        {
            var result = new Result<bool>();
            result.IsError = false;
            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_login", connection);
                command.Parameters.Add("@userName", userName);
                command.Parameters.Add("@pws", pws);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var drOutput = command.ExecuteScalar();

                if (drOutput.ToString() == "1")
                    result.Return = true;
                else
                    result.Return = false;

            }
            catch (Exception ee)
            {
                result.Return = false;
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }

            return result;
        }

        internal Result<IEnumerable<Address>> GetAddresses()
        {
            var result = new Result<IEnumerable<Address>>();
            var data = new List<Address>();
            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_GetAddresses", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var drOutput = command.ExecuteReader();

                using (drOutput)
                {
                    while (drOutput.Read())
                    {
                        var item = new Address();
                        item.YeshuvNum = (drOutput["YeshuvNum"] != Convert.DBNull) ? int.Parse(drOutput["YeshuvNum"].ToString()) : 0;
                        item.YeshuvName = (drOutput["YeshuvName"] != Convert.DBNull) ? drOutput["YeshuvName"].ToString() : null;
                        item.StNum = (drOutput["StNum"] != Convert.DBNull) ? int.Parse(drOutput["StNum"].ToString()) : 0;
                        item.StName = (drOutput["StName"] != Convert.DBNull) ? drOutput["StName"].ToString() : null;
                        item.Moaza = (drOutput["Moaza"] != Convert.DBNull) ? int.Parse(drOutput["Moaza"].ToString()) : 0;
                        data.Add(item);
                    }
                    result.Return = data;
                }
            }
            catch (Exception ee)
            {
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return result;
        }

        internal Result<IEnumerable<Mitkanim>> GetMitkanim()
        {
            var result = new Result<IEnumerable<Mitkanim>>();
            result.IsError = false;
            var data = new List<Mitkanim>();

            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_getMitkanim", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var drOutput = command.ExecuteReader();

                using (drOutput)
                {
                    while (drOutput.Read())
                    {
                        var item = new Mitkanim();

                        item.MitkanNum = (drOutput["MitkanNum"] != Convert.DBNull) ? int.Parse(drOutput["MitkanNum"].ToString()) : 0;
                        item.MitkanName = (drOutput["MitkanName"] != Convert.DBNull) ? drOutput["MitkanName"].ToString() : null;

                        item.Rashut = new Rashuyot();
                        item.Rashut.RashutID = (drOutput["RashutID"] != Convert.DBNull) ? int.Parse(drOutput["RashutID"].ToString()) : 0;
                        item.Rashut.RashutName = (drOutput["RashutName"] != Convert.DBNull) ? drOutput["RashutName"].ToString() : null;

                        item.Rashut.Mehoz = new Mehozot();
                        item.Rashut.Mehoz.MahozNum = (drOutput["MahozNum"] != Convert.DBNull) ? int.Parse(drOutput["MahozNum"].ToString()) : 0;
                        item.Rashut.Mehoz.MahozName = (drOutput["MahozName"] != Convert.DBNull) ? drOutput["MahozName"].ToString() : null;

                        data.Add(item);
                    }
                    result.Return = data;
                }
            }
            catch (Exception ee)
            {
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

            }
            return result;
        }

        internal Result<IEnumerable<AgeType>> GetAgeType()
        {
            var result = new Result<IEnumerable<AgeType>>();
            var data = new List<AgeType>();
            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_getAgeType", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var drOutput = command.ExecuteReader();

                using (drOutput)
                {
                    while (drOutput.Read())
                    {
                        var item = new AgeType();
                        item.AgeId = (drOutput["AgeId"] != Convert.DBNull) ? int.Parse(drOutput["AgeId"].ToString()) : 0;
                        item.AgeName = (drOutput["AgeName"] != Convert.DBNull) ? drOutput["AgeName"].ToString() : null;
                        data.Add(item);
                    }
                    result.Return = data;
                }
            }
            catch (Exception ee)
            {
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return result;
        }

        internal Result<IEnumerable<Yeshuvim>> GetYeshuvim()
        {
            var result = new Result<IEnumerable<Yeshuvim>>();
            var data = new List<Yeshuvim>();
            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_GetYeshuvim", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var drOutput = command.ExecuteReader();

                using (drOutput)
                {
                    while (drOutput.Read())
                    {
                        var item = new Yeshuvim();
                        item.YeshuvNum = (drOutput["YeshuvNum"] != Convert.DBNull) ? int.Parse(drOutput["YeshuvNum"].ToString()) : 0;
                        item.YeshuvName = (drOutput["YeshuvName"] != Convert.DBNull) ? drOutput["YeshuvName"].ToString() : null;

                        data.Add(item);
                    }
                    result.Return = data;
                }
            }
            catch (Exception ee)
            {
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return result;
        }

        internal Result<IEnumerable<Rashuyot>> GetRashuyot()
        {
            var result = new Result<IEnumerable<Rashuyot>>();
            var data = new List<Rashuyot>();
            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_GetRashuyot", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();

                var drOutput = command.ExecuteReader();

                using (drOutput)
                {
                    while (drOutput.Read())
                    {
                        var item = new Rashuyot();
                        item.RashutID = (drOutput["RashutID"] != Convert.DBNull) ? int.Parse(drOutput["RashutID"].ToString()) : 0;
                        item.RashutName = (drOutput["RashutName"] != Convert.DBNull) ? drOutput["RashutName"].ToString() : null;

                        data.Add(item);
                    }
                    result.Return = data;
                }
            }
            catch (Exception ee)
            {
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return result;
        }

        string GenerateSortingFieldAndOrder(SortingField sortingName, SortingOrder sortingOrder)
        {
            return sortingName.ToString() + " " + sortingOrder.ToString();
        }

        string GenerateSortingFieldAndOrder(SortingMitkanimField sortingName, SortingOrder sortingOrder)
        {
            return sortingName.ToString() + " " + sortingOrder.ToString();
        }

        internal Result<IEnumerable<ShiltonMekomi>> GetShiltonMekomiByModelAndPages(SearchRequest request)
        {
            var orderBy = GenerateSortingFieldAndOrder(request.SortingName, request.SortingOrder);
            var result = new Result<IEnumerable<ShiltonMekomi>>();
            var data = new List<ShiltonMekomi>();
            result.IsError = false;
            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_searchShiltonMekomi", connection);

                command.Parameters.Add("@pOrderBy", orderBy);
                command.Parameters.Add("@pCurrentPage", request.CurrentPage);
                command.Parameters.Add("@pPageSize", request.MaxRowsPerPage);
                command.Parameters.Add("@MfDateIncomeBegin", request.MfDateIncomeBegin);
                command.Parameters.Add("@MfDateIncomeEnd", request.MfDateIncomeEnd);
                command.Parameters.Add("@MehozId", request.MehozId);
                command.Parameters.Add("@MitkanNum", request.MitkanNum);
                command.Parameters.Add("@RashutID", request.RashutID);
                command.Parameters.Add("@MfFirstName", request.MfFirstName);
                command.Parameters.Add("@MfLastName", request.MfLastName);
                command.Parameters.Add("@MfGender", request.MfGender);
                command.Parameters.Add("@MfFather", request.MfFather);
                command.Parameters.Add("@MfAge", request.MfAge);
                command.Parameters.Add("@YeshuvNum", request.YeshuvNum);
                command.Parameters.Add("@StNum", request.StNum);
                command.Parameters.Add("@MfAddHouseNum", request.MfAddHouseNum);
                command.Parameters.Add("@IsMfDateOutcome", request.IsMfDateOutcome);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var drOutput = command.ExecuteReader();

                using (drOutput)
                {
                    while (drOutput.Read())
                    {
                        var item = new ShiltonMekomi();
                        item.MefuneSysNum = (drOutput["MefuneSysNum"] != Convert.DBNull) ? long.Parse(drOutput["MefuneSysNum"].ToString()) : 0;
                        item.MefuneID = (drOutput["MefuneID"] != Convert.DBNull) ? long.Parse(drOutput["MefuneID"].ToString()) : 0;
                        item.MfLastName = (drOutput["MfLastName"] != Convert.DBNull) ? drOutput["MfLastName"].ToString() : null;
                        item.MfFirstName = (drOutput["MfFirstName"] != Convert.DBNull) ? drOutput["MfFirstName"].ToString() : null;
                        item.ShiltonMekomiAddress = (drOutput["ShiltonMekomiAddress"] != Convert.DBNull) ? drOutput["ShiltonMekomiAddress"].ToString() : null;
                        item.MfAge = (drOutput["MfAge"] != Convert.DBNull) ? (int?)int.Parse(drOutput["MfAge"].ToString()) : null;

                        item.Mitkan = new Mitkanim();
                        item.Mitkan.MitkanName = (drOutput["MitkanName"] != Convert.DBNull) ? drOutput["MitkanName"].ToString() : null;
                        item.Mitkan.MitkanPhone = (drOutput["MitkanPhone"] != Convert.DBNull) ? drOutput["MitkanPhone"].ToString() : null;
                        item.Mitkan.MitkanNum = (drOutput["MitkanNum"] != Convert.DBNull) ? int.Parse(drOutput["MitkanNum"].ToString()) : 0;
                        item.Mitkan.MitkanAddress = (drOutput["MitkanAddress"] != Convert.DBNull) ? drOutput["MitkanAddress"].ToString() : null;

                        item.Mitkan.Rashut = new Rashuyot();
                        item.Mitkan.Rashut.RashutID = (drOutput["RashutID"] != Convert.DBNull) ? int.Parse(drOutput["RashutID"].ToString()) : 0;
                        item.Mitkan.Rashut.RashutName = (drOutput["RashutName"] != Convert.DBNull) ? drOutput["RashutName"].ToString() : null;

                        data.Add(item);
                    }
                    result.Return = data;
                }
            }
            catch (Exception ee)
            {
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return result;
        }

        internal Result<ShiltonMekomi> UpdateMefune(ShiltonMekomi model)
        {
            var result = new Result<ShiltonMekomi>();
            result.IsError = false;
            result.Return = model;
            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_updateMefune", connection);
                command.Parameters.Add("@MefuneSysNum", model.MefuneSysNum);
                command.Parameters.Add("@MfDateOutcome", model.MfDateOutcome);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var drOutput = command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }

            return result;
        }

        internal Result<IEnumerable<ReportMitkanim>> ExcuteReportMitkanim(SearchMitkanimRequest request)
        {
            var orderBy = GenerateSortingFieldAndOrder(request.SortingName, request.SortingOrder);
            var result = new Result<IEnumerable<ReportMitkanim>>();
            var data = new List<ReportMitkanim>();
            result.IsError = false;
            var connection = GetSqlConnection();
            try
            {
                var command = new SqlCommand(@"gs_searchMitkan", connection);

                command.Parameters.Add("@pOrderBy", orderBy);
                command.Parameters.Add("@pCurrentPage", request.CurrentPage);
                command.Parameters.Add("@pPageSize", request.MaxRowsPerPage);

                command.Parameters.Add("@MahozNum", request.MahozNum);
                command.Parameters.Add("@MitkanNum", request.MitkanNum);
                command.Parameters.Add("@RashutID", request.RashutID);
           

                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var drOutput = command.ExecuteReader();

                using (drOutput)
                {
                    while (drOutput.Read())
                    {
                        var item = new ReportMitkanim();
                        item.MahozNum = (drOutput["MahozNum"] != Convert.DBNull) ? (int?)int.Parse(drOutput["MahozNum"].ToString()) : null;
                        item.MahozName = (drOutput["MahozName"] != Convert.DBNull) ? drOutput["MahozName"].ToString() : null;
                       
                        item.MitkanNum = (drOutput["MitkanNum"] != Convert.DBNull) ? (int?)int.Parse(drOutput["MitkanNum"].ToString()) : null;
                        item.MitkanName = (drOutput["MitkanName"] != Convert.DBNull) ? drOutput["MitkanName"].ToString() : null;
                       
                        item.RashutID = (drOutput["RashutID"] != Convert.DBNull) ? (int?)int.Parse(drOutput["RashutID"].ToString()) : null;
                        item.RashutName = (drOutput["RashutName"] != Convert.DBNull) ? drOutput["RashutName"].ToString() : null;
                       
                        item.Sum19To65 = (drOutput["Sum19To65"] != Convert.DBNull) ? (int?)int.Parse(drOutput["Sum19To65"].ToString()) : null;
                        item.Sum3 = (drOutput["Sum3"] != Convert.DBNull) ? (int?)int.Parse(drOutput["Sum3"].ToString()) : null;
                        item.Sum4To6 = (drOutput["Sum4To6"] != Convert.DBNull) ? (int?)int.Parse(drOutput["Sum4To6"].ToString()) : null;
                        item.Sum66 = (drOutput["Sum66"] != Convert.DBNull) ? (int?)int.Parse(drOutput["Sum66"].ToString()) : null;
                        item.Sum7To18 = (drOutput["Sum7To18"] != Convert.DBNull) ? (int?)int.Parse(drOutput["Sum7To18"].ToString()) : null;
                        item.SumAll = (drOutput["SumAll"] != Convert.DBNull) ? (int?)int.Parse(drOutput["SumAll"].ToString()) : null;
                        data.Add(item);
                    }
                    result.Return = data;
                }
               
            }
            catch (Exception ee)
            {
                WriteError(ee.ToString());
                result.IsError = true;
                result.ErrorDesc = ee.ToString();
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return result;
        }
    }
}
