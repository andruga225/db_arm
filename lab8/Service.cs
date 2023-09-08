using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class Service
    {
        public Service()
        {
            MriCans = new HashSet<MriCan>();
        }

        public int IdService { get; set; }
        public string OrganGroup { get; set; }
        public string Organ { get; set; }
        public int Price { get; set; }

        public virtual ICollection<MriCan> MriCans { get; set; }
    }
}
