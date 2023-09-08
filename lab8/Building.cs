using System;
using System.Collections.Generic;

#nullable disable

namespace lab8
{
    public partial class Building
    {
        public Building()
        {
            Clinics = new HashSet<Clinic>();
        }

        public int IdBuilding { get; set; }
        public string BuildingAddress { get; set; }
        public string BuildingType { get; set; }
        public int BuildingFloors { get; set; }

        public virtual ICollection<Clinic> Clinics { get; set; }
    }
}
