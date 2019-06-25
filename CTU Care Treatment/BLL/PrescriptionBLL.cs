using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTU_Care_Treatment.BLL
{
    class PrescriptionBLL
    {
        public int FileNumber { get; set; }
        public int DoctorsID { get; set; }
        public DateTime Date { get; set; }
        public string Prescribed { get; set; }
    }
}
