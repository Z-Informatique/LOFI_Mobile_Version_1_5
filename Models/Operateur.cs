using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Operateur
    {
        public Operateur()
        {
            Historiques = new HashSet<Historique>();
        }

        public int Id { get; set; }
        public string Operateur1 { get; set; }
        public string Method { get; set; }
        public string Numero { get; set; }
        public int IdPays { get; set; }
        public int Statut { get; set; }
        public string ActionKey { get; set; }
        public string Type { get; set; }

        public virtual Pay Pays { get; set; } = null!;
        public virtual ICollection<Historique> Historiques { get; set; }
    }
}
