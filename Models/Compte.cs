using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Compte
    {
        public Compte()
        {
            Historiques = new HashSet<Historique>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public string TypeCompte { get; set; }
        public decimal? Solde { get; set; }
        public bool Statut { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Historique> Historiques { get; set; }
    }
}
