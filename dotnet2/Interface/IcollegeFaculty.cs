using collegemanagementfirstproject.Models;

namespace collegemanagementfirstproject.Interface
{
    public interface IcollegeFaculty
    {
        IEnumerable<collegeFacultymodel> GetAllcollegeFaculty();

        void DeletecollegeFaculty(collegeFacultymodel cf);

        collegeFacultymodel GetById(int id);
        void InsertcollegeFaculty(collegeFacultymodel cf);
        void UpdatecollegeFaculty(collegeFacultymodel cf);
    }
}
