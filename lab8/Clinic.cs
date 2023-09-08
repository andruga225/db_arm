using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class Clinic
    {
        public Clinic()
        {
            EmpPos = new HashSet<EmpPo>();
            MriMachines = new HashSet<MriMachine>();
        }

        public int IdClinic { get; set; }
        public string ClinicName { get; set; }
        public string ClinicFinance { get; set; }
        public int ClinicEmployers { get; set; }
        public int IdBuilding { get; set; }

        public virtual Building IdBuildingNavigation { get; set; }
        public virtual ICollection<EmpPo> EmpPos { get; set; }
        public virtual ICollection<MriMachine> MriMachines { get; set; }
    }
}
