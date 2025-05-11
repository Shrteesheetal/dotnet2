using collegemanagementfirstproject.Models;

namespace collegemanagementfirstproject.Interface
{
    public interface Icollegestudent
    {
        IEnumerable<collegestudentModel> GetAllcollegestudent();

          void Deletecollegestudent(collegestudentModel cs);

         collegestudentModel GetById(int id);
         void Insertcollegestudent(collegestudentModel cs);
         void Updatecollegestudent(collegestudentModel cs);


    }


}
