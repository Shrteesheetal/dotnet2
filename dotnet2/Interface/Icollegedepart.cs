using collegemanagementfirstproject.Models;

namespace collegemanagementfirstproject.Interface
{
    public interface Icollegedepart
    {
        IEnumerable<collegeDepartmentModel> GetAllcollegeDepartment();

        void DeletecollegeDepartment(collegeDepartmentModel cd);

        collegeDepartmentModel GetById(int id);

        void InsertcollegeDepartment(collegeDepartmentModel cd);

        void UpdatecollegeDepartment(collegeDepartmentModel cd);
    }
}
