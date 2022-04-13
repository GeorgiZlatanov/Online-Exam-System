using OnlineExamination.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.BLL.Services
{
    public interface IQaAService
    {
        PagedResult<QnAsViewModel> GetAll(int pageNUmber, int pageSize);
        Task<QnAsViewModel> AddAsync(QnAsViewModel QnAVM);
        IEnumerable<QnAsViewModel> GetAllQnAByExam(int examID);
        bool IsExamAttended(int examId, int studentId);
    }
}
