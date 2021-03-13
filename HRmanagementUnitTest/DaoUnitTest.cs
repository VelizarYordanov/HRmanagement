using HRmanagement.DAO;
using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HRmanagementUnitTest
{
    public class DaoUnitTest
    {
        [Fact]
        public void TestInsertSqlBuilder()
        {
            DepartmentDAO dep = new DepartmentDAO();



            string actual = dep.InsertSqlBuilder("departments",
                new List<string>() { "name", "address" }
                );

            Assert.Equal("insert into departments (name, address) values (@name, @address);", actual);
        }

        [Fact]
        public void TestUpdateSqlBuilder()
        {
            DepartmentDAO dep = new DepartmentDAO();

            string actual = dep.UpdateSqlBuilder("departments", new List<string>() { "name", "address" });

            Assert.Equal("update departments set name = @name, address = @address where id = @id;", actual);
        }

        [Fact]
        public void TestGetAllDepartment()
        {
            try
            {
                DepartmentDAO dep = new DepartmentDAO();
                List<Department> departments = dep.GetAll();
                Assert.Contains(departments, d => d.ID != 0);
            }
            catch(Exception ex)
            {
                Assert.False(true, ex.Message);
            }

        }

        [Fact]

        public void TestGetDepartment()
        {
            //try
            //{
            //    DepartmentDAO dao = new DepartmentDAO();
            //    HRmanagement.Models.Department dep =  dao.Get(1);
            //    Assert.True(dep != null);
            //}
            //catch
            //{
            //    Assert.False(true);
            //}
        }
    }
}
