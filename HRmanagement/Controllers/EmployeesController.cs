using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRmanagement.DAO;
using HRmanagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            EmployeeDAO dao = new EmployeeDAO();
            return View(dao.GetAll());
        }

        public IActionResult Create()
        {
            DepartmentDAO dao = new DepartmentDAO();
            return View(dao.GetAll());
        }

        public IActionResult Insert(string Name, string Address, string Gender, DateTime Doj, DateTime Dob, int Department)
        {
            return View();
        }
    }
}
