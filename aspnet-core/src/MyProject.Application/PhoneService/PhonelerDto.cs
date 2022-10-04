using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PhoneService
{
    public class PhonelerDto
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Hafiza { get; set; }
        public int RAM { get; set; }
        public string Renk { get; set; }
        public string EkranBouyutu { get; set; }
        public int Garanti { get; set; }
        public bool SatildiMi { get; set; }
        public int StokAdedi { get; set; }

    }
}
