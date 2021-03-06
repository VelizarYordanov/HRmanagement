﻿using HRmanagement.DAO;
using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRmanagement.BLL.DTO.Projects;

namespace HRmanagement.BLL
{
    public class ProjectBLL
    {
        public void Insert(string Name, string Address, int DepartmentID)
        {
            Project entity = new Project();
            entity.Name = Name;
            entity.Address = Address;
            entity.DepartmentID = DepartmentID;
            ProjectDAO dao = new ProjectDAO();
            dao.Insert(entity);
        }

        public List<ProjectDepartmentDTO> GetProjectDepartmentDTO()
        {
            ProjectDAO dao = new ProjectDAO();
            DepartmentDAO depdao = new DepartmentDAO();
            List<Project> projectsModel = dao.GetAll();
            List<ProjectDepartmentDTO> projDepDTO = new List<ProjectDepartmentDTO>();

            List<string> mutualFileds = typeof(Project).GetProperties().Select(p => p.Name)
                .Intersect(typeof(ProjectDepartmentDTO).GetProperties().Select(p => p.Name)).ToList();

            for (int i = 0; i < projectsModel.Count; i++)
            {
                // Add new Element
                projDepDTO.Add(new ProjectDepartmentDTO());

                // Fill mutual fields
                foreach (string f in mutualFileds)
                {
                    typeof(ProjectDepartmentDTO).GetProperty(f).SetValue(projDepDTO[i],
                        typeof(Project).GetProperty(f).GetValue(projectsModel[i]));
                }

                // Add Department
                projDepDTO[i].BelongsToDepartment = depdao.GetFiltered("id", projDepDTO[i].DepartmentID.ToString());
            }

            return projDepDTO;
        }

        public ProjectDepartmentsDTO GetProjectDepartmentsDTO(int ProjectId)
        {
            ProjectDepartmentsDTO output = new ProjectDepartmentsDTO();

            ProjectDAO projectDao = new ProjectDAO();
            output.Project = projectDao.GetFiltered("id", ProjectId.ToString());

            DepartmentDAO departmentDAO = new DepartmentDAO();
            output.Departments = departmentDAO.GetAll();

            return output;
        }

        public void Update(int ProjectID, string Name, string Address, int DepartmentID )
        {
            Project proj = new Project()
            {
                ID = ProjectID,
                Name = Name,
                Address = Address,
                DepartmentID = DepartmentID
            };

            ProjectDAO dao = new ProjectDAO();

            dao.Update(proj);
        }
    }
}
