using OnlineExamination.ViewModels;
using System.Collections.Generic;

namespace OnlineExamination.Web.Controllers
{
    public interface IQnAService
    {
        List<QnAsViewModel> GetAllQnAByExam(int id);
        bool IsExamAttended(int id, int studentId);
    }
}