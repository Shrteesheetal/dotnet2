

using collegemanagementfirstproject.Interface;
using collegemanagementfirstproject.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Data.Common;

namespace collegemanagementfirstproject.Repository
{
    public class collegestudentrepository : Icollegestudent
    {
        private readonly IConnection _connect;

        public collegestudentrepository(IConnection connection)
        {
            connection=_connect = connection;
        }

     

        public void Insertcollegestudent(collegestudentModel cs)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    
                    param.Add("@name", cs.Name);
                    param.Add("@Email", cs.Email);
                
                    param.Add("@Flag", "Insert");
                    con.Execute("collegestudentsp", param, commandType: CommandType.StoredProcedure);

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
        public void Updatecollegestudent(collegestudentModel crs)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try  //Id na lee kana update garna kojcha 
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", crs.Id);
                    param.Add("@name", crs.Name);
                    param.Add("@Email", crs.Email);
                    param.Add("@Flag", "Update");
                    con.Execute("collegestudentsp", param, commandType: CommandType.StoredProcedure);

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
        public void Deletecollegestudent(collegestudentModel crs)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", crs.Id);
                    param.Add("@Flag", "Delete");
                    con.Execute("collegestudentsp", param, commandType: CommandType.StoredProcedure);

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

        public IEnumerable<collegestudentModel> GetAllcollegestudent()
        {
            using (var con = _connect.Connect())
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Flag", "List");
                    var data = SqlMapper.Query<collegestudentModel>(con, "collegestudentsp", param, commandType: CommandType.StoredProcedure).ToList();
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

        public collegestudentModel GetById(int Id)
        {
            using (var con = _connect.Connect())//look .connect what happen
            {
                try
                {
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", Id);
                    param.Add("@Flag", "GetById");
                    var data = SqlMapper.Query<collegestudentModel>(con, "collegestudentsp", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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




    
 