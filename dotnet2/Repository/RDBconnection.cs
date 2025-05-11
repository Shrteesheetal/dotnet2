using collegemanagementfirstproject.Interface;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace collegemanagementfirstproject.Repository
{
    public class RDBconnection : IConnection
    {
        private readonly IConfiguration _configs; //inbuild(2)
        public RDBconnection(IConfiguration _config) //constructor name same as cs(2.1)
        {
            _configs = _config ?? throw new ArgumentNullException(nameof(_config)); //added null check
        } //(2)

        

        public IDbConnection Connect()//(1.1)
        {
            return new SqlConnection(_configs.GetConnectionString("DefaultConnection"));
           
        }
    }

}
