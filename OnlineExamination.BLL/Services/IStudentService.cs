using System;
using System.Collections.Generic;
using System.Text;
using OnlineExamination.ViewModels;
using OnlineExamination.DataAccess;
using System.Threading.Tasks;

namespace OnlineExamination.BLL.Services
{
    public interface IStudentService
    {
        PagedResult<StudentViewModel> GetAll(int pageNumber, int pageSize);
        Task<StudentViewModel> AddAsync(StudentViewModel vm);
        //his is called GetAllstudents check if there is exeption
        IEnumerable<Students> GetAllStudents();
        bool SetGroupIdToStudents(GroupViewModel vm);
        bool SetExamResult(AttendExamViewModel vm);
        IEnumerable<ResultViewModel> GetExamResults(int studentId);
        StudentViewModel GetStudentDetails(int studentId);
        Task<StudentViewModel> UpdateAsync(StudentViewModel vm);
    }
}
