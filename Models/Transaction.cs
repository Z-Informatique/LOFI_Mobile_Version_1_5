using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Transaction
    {
        public int IdTransac { get; set; }
        public string NumTransac { get; set; }
        public decimal? MontantTransac { get; set; }
        public int? UserIdTransac { get; set; }
        public decimal? FraisRetraitTransac { get; set; }
        public DateTime DateTransac { get; set; }
        public string OptionEnvoiTransac { get; set; }
        public string ObservationTransac { get; set; }
        public bool? DirectTransac { get; set; }
        public int? StatutTransac { get; set; }
        public decimal? FraisRetrait { get; set; }
        public string Operateur { get; set; }
        public virtual User User { get; set; }
    }
}
