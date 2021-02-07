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
            EmployeeBLL BLL = new EmployeeBLL();
            BLL.Insert(Name, Address, Gender, Doj, Dob, Department);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int EmployeeID)
        {
            EmployeeDAO dao = new EmployeeDAO();
            dao.Delete(EmployeeID);
            return RedirectToAction("Index");
        }
    }
}
