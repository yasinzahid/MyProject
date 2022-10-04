using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Phoneler
{
    public class Phone : FullAuditedEntity
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public  int Hafiza { get; set; }
        public int RAM { get; set; }
        public string Renk{ get; set; }
        public string EkranBoyutu { get; set; }
        public int Garanti { get; set; }
        public bool SatildiMi { get; set; }
        public int StokAdedi { get; set; }

    }
}
