using System;
using System.Collections.Generic;
using System.Text;
using OnlineExamination.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace OnlineExamination.ViewModels
{
    public class AttendExamViewModel
    {
        public int StudentId { get; set; }
        public string ExamName { get; set; }
        public List<QnAsViewModel> QnAs { get; set; }
        public string Message { get; set; }

    }
}
