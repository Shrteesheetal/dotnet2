using collegemanagementfirstproject.Interface;
using collegemanagementfirstproject.Models;
using Dapper;
using System.Data;

namespace collegemanagementfirstproject.Repository
{
    public class collegeDepartRepo : Icollegedepart
    {
        private readonly IConnection _connect;

        public collegeDepartRepo(IConnection connection)
        {
            connection = _connect = connection;
        }

        

        public void InsertcollegeDepartment(collegeDepartmentModel cd)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                  
                    param.Add("@DepartmentName", cd.DepartmentName);
                    param.Add("@DepartmentHead", cd.DepartmentHead);
                    param.Add("@OfficeLocation", cd.OfficeLocation);
                    param.Add("@ContactEmail", cd.ContactEmail);
                    param.Add("@Flag", "Insert");
                    con.Execute("CollegeDepartmentStoreProcedure", param, commandType: CommandType.StoredProcedure);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public void UpdatecollegeDepartment(collegeDepartmentModel cd)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try  //Id na lee kana update garna kojcha 
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@DepartmentId", cd.DepartmentId);
                    param.Add("@DepartmentName", cd.DepartmentName);
                    param.Add("@DepartmentHead", cd.DepartmentHead);
                    param.Add("@OfficeLocation", cd.OfficeLocation);
                    param.Add("@ContactEmail", cd.ContactEmail);
                    param.Add("@Flag", "Update");
                    con.Execute("CollegeDepartmentStoreProcedure", param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public void DeletecollegeDepartment(collegeDepartmentModel cd)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@DepartmentId", cd.DepartmentId);
                    param.Add("@Flag", "Delete");
                    con.Execute("CollegeDepartmentStoreProcedure", param, commandType: CommandType.StoredProcedure);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }
        public IEnumerable<collegeDepartmentModel> GetAllcollegeDepartment()
        {
            using (var con = _connect.Connect())
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Flag", "Select");
                    var data = SqlMapper.Query<collegeDepartmentModel>(con, "CollegeDepartmentStoreProcedure", param, commandType: CommandType.StoredProcedure).ToList();
                    return data;

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    con.Close();

                }

            }

        }


        public collegeDepartmentModel GetById(int Id)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@DepartmentId", Id);
                    param.Add("@Flag", "GetById");
                    var data = SqlMapper.Query<collegeDepartmentModel>(con, "CollegeDepartmentStoreProcedure", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return data;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }




    }
}
