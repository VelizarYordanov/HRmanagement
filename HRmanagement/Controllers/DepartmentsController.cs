using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRmanagement.BLL;
using HRmanagement.DAO;
using HRmanagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            DepartmentDAO dao = new DepartmentDAO();
            return View(dao.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Insert(string Name, string Address)
        {
            DepartmentBLL bll = new DepartmentBLL();
            bll.Insert(Name, Address);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int departmentId)
        {
            DepartmentDAO dao = new DepartmentDAO();
            dao.Delete(departmentId);
            return RedirectToAction("Index");
        }
    }
}
