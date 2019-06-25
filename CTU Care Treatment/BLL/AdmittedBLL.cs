using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTU_Care_Treatment.BLL
{
    class AdmittedBLL
    {
        public int AdmissionID { get; set; }
        public int FileNumber { get; set; }
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime DateAdmitted { get; set; }
    }
}
