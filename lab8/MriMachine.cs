using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class MriMachine
    {
        public MriMachine()
        {
            MriCans = new HashSet<MriCan>();
        }

        public int IdMachine { get; set; }
        public int SerialNumber { get; set; }
        public string MachineType { get; set; }
        public int IdClinic { get; set; }

        public virtual Clinic IdClinicNavigation { get; set; }
        public virtual ICollection<MriCan> MriCans { get; set; }
    }
}
