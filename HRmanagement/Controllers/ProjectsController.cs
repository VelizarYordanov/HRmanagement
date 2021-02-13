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
            ProjectBLL bll = new ProjectBLL();

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

        public IActionResult Insert(string Name, string Address, int Department)
        {
            ProjectBLL bll = new ProjectBLL();
            bll.Insert(Name, Address, Department);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int ProjectID)
        {
            ProjectDAO dao = new ProjectDAO();
            dao.Delete(ProjectID);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ProjectId)
        {
            ProjectBLL projectBLL = new ProjectBLL();
            return View(projectBLL.GetProjectDepartmentsDTO(ProjectId));
        }

        public IActionResult Update(int ProjectId, int DepartmentId, string Name, string Address)
        {
            ProjectBLL bll = new ProjectBLL();
            bll.Update(ProjectId, Name, Address, DepartmentId);
            return RedirectToAction("Index");
        }
    }
}
