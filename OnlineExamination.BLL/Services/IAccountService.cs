using System;
using System.Collections.Generic;
using System.Text;
using OnlineExamination.ViewModels;

namespace OnlineExamination.BLL.Services
{
    public interface IAccountService
    {
        LoginViewModel Login(LoginViewModel vm);
        bool AddTeacher(UserViewModel vm);
        PagedResult<UserViewModel> GetAllTeachers(int pageNumber, int pageSize);
    }
}
