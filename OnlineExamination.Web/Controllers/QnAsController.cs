﻿using Microsoft.AspNetCore.Mvc;
using OnlineExamination.BLL.Services;
using OnlineExamination.ViewModels;
using System.Threading.Tasks;

namespace OnlineExamination.Web.Controllers
{
    public class QnAsController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQaAService _qnAService;

        public QnAsController(IExamService examService, IQaAService qnAService)
        {
            _examService = examService;
            _qnAService = qnAService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_qnAService.GetAll(pageSize, pageNumber));
        }

        public IActionResult Create()
        {
            var model = new QnAsViewModel();
            model.ExamsList = _examService.GetAllExams();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(QnAsViewModel qnViewModel)
        {
            if (ModelState.IsValid)
            {
                await _qnAService.AddAsync(qnViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(qnViewModel);

        }
    }
}
