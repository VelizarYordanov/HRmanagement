using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRmanagement.BLL;
using HRmanagement.BLL.DTO.Projects;
using HRmanagement.DAO;
using HRmanagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            DepartmentBLL bll = new DepartmentBLL();

            return View(bll.GetProjectDepartmentDTO());
        }

        private IActionResult View(Func<List<Project>> getAll)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create()
        {
            DepartmentDAO dao = new DepartmentDAO();
            return View(dao.GetAll());
        }

        public IActionResult Insert()
        {
            throw new NotImplementedException();
        }
    }
}
