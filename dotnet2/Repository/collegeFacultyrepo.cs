using collegemanagementfirstproject.Interface;
using collegemanagementfirstproject.Models;
using Dapper;
using System.Data;

namespace collegemanagementfirstproject.Repository
{
    public class CollegeFacultyrepo : IcollegeFaculty
    {
        private readonly IConnection _connect;
        public CollegeFacultyrepo(IConnection connection)
        {
            connection = _connect = connection;
        }
        public void collegeFacultymodel(collegeFacultymodel cf)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@FacultyID", cf.FacultyID);
                    param.Add("@Flag", "Delete");
                    con.Execute("facultyStoreProcedure", param, commandType: CommandType.StoredProcedure);

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

        public void DeletecollegeFaculty(collegeFacultymodel cf)
        {
            throw new NotImplementedException();
        }

        public void Deletecollegestudent(collegeFacultymodel cf)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<collegeFacultymodel> GetAllcollegeFaculty()
        {
            using (var con = _connect.Connect())
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Flag", "list");
                    var data = SqlMapper.Query<collegeFacultymodel>(con, "facultyStoreProcedure", param, commandType: CommandType.StoredProcedure).ToList();
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
        public collegeFacultymodel GetById(int id)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@FacultyID",id);
                    param.Add("@Flag", "GetById");
                    var data = SqlMapper.Query<collegeFacultymodel>(con, "facultyStoreProcedure", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
        public void InsertcollegeFaculty(collegeFacultymodel cf)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();

                    param.Add("@FirstName", cf.FirstName);
                    param.Add("@LastName", cf.LastName);
                    param.Add("@Email", cf.Email);
                    param.Add("@PhoneNumber", cf.PhoneNumber);
                    param.Add("@Department", cf.Department);
                    param.Add("@HireDate ", cf.HireDate);
                    param.Add("@Designation", cf.Designation);
                    

                    param.Add("@Flag", "Insert");
                    con.Execute("facultyStoreProcedure", param, commandType: CommandType.StoredProcedure);

                }
                catch (Exception ex)
                {
                    throw ex;// Preserves stack trace
                }
                finally
                {
                    con.Close();
                }
            }
;
        }
        public void UpdatecollegeFaculty(collegeFacultymodel cf)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try  //Id na lee kana update garna kojcha 
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@FacultyID ", cf.FacultyID);
                    param.Add("@FirstName", cf.FirstName);
                    param.Add("@LastName", cf.LastName);
                    param.Add("@Email", cf.Email);
                    param.Add("@PhoneNumber", cf.PhoneNumber);
                    param.Add("@Department", cf.Department);
                    param.Add("@Designation", cf.Designation);
                    param.Add("@HireDate ", DateTime.Now);
                    param.Add("@Flag", "Update");
                    con.Execute("facultyStoreProcedure", param, commandType: CommandType.StoredProcedure);

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
