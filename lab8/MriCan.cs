using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class MriCan
    {
        public int IdMachine { get; set; }
        public int IdEmployer { get; set; }
        public int IdPatient { get; set; }
        public int IdService { get; set; }
        public DateTime ScanDate { get; set; }
        public DateTime ResultDate { get; set; }

        public virtual Employer IdEmployerNavigation { get; set; }
        public virtual MriMachine IdMachineNavigation { get; set; }
        public virtual Patinet IdPatientNavigation { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
    }
}
