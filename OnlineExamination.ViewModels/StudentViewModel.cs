using System;
using System.Collections.Generic;
using System.Text;
using OnlineExamination.DataAccess;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineExamination.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel()
        { } 
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Contact No")]
        public string Contact { get; set; }
        [Display(Name = "CV")]
        public string CVFileName { get; set; }
        public string PictureFileName { get; set; }
        public int? GroupsId { get; set; }
        public IFormFile PictureFile { get; set; }
        public IFormFile CVFile { get; set; }
        public int TotalCount { get; set; }
        public List<StudentViewModel> StudentList { get; set; }

        public StudentViewModel(Students model)
        {
            Id = model.Id;
            Name = model.Name ?? "";
            UserName = model.UserName;
            Password = model.Password;
            Contact = model.Contact ?? "";
            CVFileName = model.CVFileName ?? "";
            PictureFileName = model.PictureFileName ?? "";
            GroupsId = model.GroupsId;
        }
        public Students ConvertViewModel(StudentViewModel vm)
        {
            return new Students
            {
                Id = vm.Id,
                Name = vm.Name ?? "",
                UserName = vm.UserName,
                Password = vm.Password,
                Contact = vm.Contact ?? "",
                CVFileName = vm.CVFileName ?? "",
                PictureFileName = vm.PictureFileName ?? "",
                GroupsId = vm.GroupsId
            };
        }
    }
}
