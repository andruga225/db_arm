using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class EmpPo
    {
        public int IdClinic { get; set; }
        public int IdEmployer { get; set; }
        public string Position { get; set; }

        public virtual Clinic IdClinicNavigation { get; set; }
        public virtual Employer IdEmployerNavigation { get; set; }
        public virtual Position PositionNavigation { get; set; }
    }
}
