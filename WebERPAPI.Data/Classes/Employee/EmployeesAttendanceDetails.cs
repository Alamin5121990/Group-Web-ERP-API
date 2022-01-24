﻿using System;

namespace LabaidMIS.Data.Classes.Employee
{
    public class EmployeesAttendanceDetails
    {
        public Nullable<DateTime> LogIn { get; set; }
        public Nullable<DateTime> LogOut { get; set; }
        public Nullable<int> MachineUserID { get; set; }
        public Nullable<int> BadgeNumber { get; set; }
    }
}