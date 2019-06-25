using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTU_Care_Treatment.BLL
{
    class DoctorsBLL
    {
         
        public int DoctorsID { get; set; }
        public string DrName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public DateTime AddedDate { get; set; }
        public int AddedBy { get; set; }

    }

}
