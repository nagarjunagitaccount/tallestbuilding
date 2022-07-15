using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallestBuilding.Entities
{
    public class BuildingTableEntity
    {
        public int Rank { get; set; }   

        public string Name { get; set; }

        public string City { get; set; }

        public string Status { get; set; }

        public string Completion { get; set; }

        public string Height  { get; set; }

        public string Materials { get; set; }

        public string Function { get; set; }

        public string Floors { get; set; }
    }
}
