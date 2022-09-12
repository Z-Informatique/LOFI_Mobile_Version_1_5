using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Transfert
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Type { get; set; }
        public DateTime? DateTransfert { get; set; }
        public decimal? Montant { get; set; }
        public decimal? Frais { get; set; }
        public int? Statut { get; set; }
        public string Telephone { get; set; }
        public string IdTransaction { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
