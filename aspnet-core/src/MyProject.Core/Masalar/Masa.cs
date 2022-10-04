using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Masalar
{
    public class Masa : FullAuditedEntity
    {
        public string Malzemesi { get; set; }
        public int AyakSayisi { get; set; }
        public int Eni { get; set; }
        public int Boyu{ get; set; }
        public string Islevi{ get; set; }
        public string Marka{ get; set; }
    }
}
