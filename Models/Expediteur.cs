using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Expediteur
    {
        public int IdExp { get; set; }
        public string NomExp { get; set; }
        public string PrenomExp { get; set; }
        public string TelExp { get; set; }
        public string AdresseExp { get; set; }
        public string NumTransac { get; set; }
    }
}
