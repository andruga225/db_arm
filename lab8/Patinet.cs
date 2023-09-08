using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class Patinet
    {
        public Patinet()
        {
            MriCans = new HashSet<MriCan>();
        }

        public int IdPatient { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientMiddleName { get; set; }
        public DateTime PatientBirthday { get; set; }

        public virtual ICollection<MriCan> MriCans { get; set; }
    }
}
