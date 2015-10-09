using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestManualTest
{
    public class patient
    {

        public int? ID { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string device_id { get; set; }
        public int Pacman_patient_dbID { get; set; }

        public patient()
        {

        }
    }
}
