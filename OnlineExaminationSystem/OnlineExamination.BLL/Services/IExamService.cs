using OnlineExamination.DataAccess;
using OnlineExamination.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.BLL.Services
{
    public interface IExamService
    {
        PagedResult<ExamViewModel> GetAll(int pageNUmber, int pageSize);
        Task<ExamViewModel> AddAsync(ExamViewModel examVM);
        IEnumerable<Exams> GetAllExams();
    }
}
