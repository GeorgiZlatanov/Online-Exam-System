using Microsoft.Extensions.Logging;
using OnlineExamination.DataAccess;
using OnlineExamination.DataAccess.UnitOfWork;
using OnlineExamination.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.BLL.Services
{
    public class ExamService : IExamService
    {
        IUnitOfWork _unitofwork;
        ILogger<ExamService> _iLogger;

        public ExamService(IUnitOfWork unitofwork, ILogger<ExamService> iLogger)
        {
            _unitofwork = unitofwork;
            _iLogger = iLogger;
        }

        public async Task<ExamViewModel> AddAsync(ExamViewModel examVM)
        {
            try
            {
                Exams objGroup = examVM.ConvertViewModel(examVM);
                await _unitofwork.GenericRepository<Exams>().AddAsync(objGroup);
                _unitofwork.Save();
            }
            catch (Exception ex)
            {

                return null;
            }
            return examVM;
        }

        public PagedResult<ExamViewModel> GetAll(int pageNumber, int pageSize)
        {
            var model = new ExamViewModel();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                List<ExamViewModel> detailList = new List<ExamViewModel>();
                var modelList = _unitofwork.GenericRepository<Exams>().GetAll().Skip(ExcludeRecords)
                    .Take(pageSize).ToList();
                var totalCount = _unitofwork.GenericRepository<Exams>().GetAll().ToList();
                detailList = ExamListInfo(modelList);
                if (detailList != null)
                {
                    model.ExamList = detailList;
                    model.TotalCount = totalCount.Count();
                }
            }
            catch (Exception ex)
            {

                _iLogger.LogError(ex.Message);
            }
            var result = new PagedResult<ExamViewModel>()
            {
                Data = model.ExamList,
                TotalItems = model.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<ExamViewModel> ExamListInfo(List<Exams> modelList)
        {
            return modelList.Select(o => new ExamViewModel(o)).ToList();
        }


        public IEnumerable<Exams> GetAllExams()
        {
            try
            {
                var exams = _unitofwork.GenericRepository<Exams>().GetAll();
                return exams;
            }
            catch (Exception ex)
            {

                _iLogger.LogError(ex.Message);
            }
            return Enumerable.Empty<Exams>();
        }
    }
}
