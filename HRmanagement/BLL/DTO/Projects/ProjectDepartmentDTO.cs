﻿using HRmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.BLL.DTO.Projects
{
    public class ProjectDepartmentDTO : Project
    {
        public Department BelongsToDepartment { get; set; }
    }
}
