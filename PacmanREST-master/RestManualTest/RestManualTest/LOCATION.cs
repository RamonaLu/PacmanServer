using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestManualTest
{
    class LOCATION
    {
        public int? ID { get; set; }
        public decimal coordinates_x { get; set; }
        public decimal coordinates_y { get; set; }
        public Nullable<int> id_patient { get; set; }
        public Nullable<int> id_carer { get; set; }

        public LOCATION(){}
    }
}
