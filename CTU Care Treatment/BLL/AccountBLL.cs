using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTU_Care_Treatment.BLL
{
    class AccountBLL
    {
        public int FileNumber { get; set; }
        public int Id { get; set; }
        public int PrescriptionID { get; set; }
        public decimal AdmissionFee { get; set; }
        public decimal AccommodationFee { get; set; }
        public decimal PrescriptionFee { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public int AccountID { get; set; }
    }
}
