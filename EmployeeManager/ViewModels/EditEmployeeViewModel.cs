﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.ViewModels
{
    public class EditEmployeeViewModel : CreateEmployeeViewModel
    {
        //public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
