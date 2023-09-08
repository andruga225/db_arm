using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class Employer
    {
        public Employer()
        {
            EmpPos = new HashSet<EmpPo>();
            MriCans = new HashSet<MriCan>();
        }

        public int IdEmployer { get; set; }
        public string EmployerName { get; set; }
        public string EmployerSurname { get; set; }
        public string EmployerMiddleName { get; set; }
        public string EmployerSex { get; set; }
        public DateTime? EmployerBirthday { get; set; }
        public int EmployerExperience { get; set; }

        public virtual ICollection<EmpPo> EmpPos { get; set; }
        public virtual ICollection<MriCan> MriCans { get; set; }
    }
}
