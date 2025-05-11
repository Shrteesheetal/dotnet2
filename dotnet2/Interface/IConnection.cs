using System.Data;

namespace collegemanagementfirstproject.Interface
{
    public interface IConnection   //self made(1)
    {
        IDbConnection Connect();  //inbuild lib(1)
    }
}
