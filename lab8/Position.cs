using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class Position
    {
        public Position()
        {
            EmpPos = new HashSet<EmpPo>();
        }

        public string Position1 { get; set; }
        public int Salary { get; set; }
        public bool Permission { get; set; }

        public virtual ICollection<EmpPo> EmpPos { get; set; }
    }
}
