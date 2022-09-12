using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Methode
    {
        public Methode()
        {
            Beneficiaires = new HashSet<Beneficiaire>();
        }
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Statut { get; set; }
        public virtual ICollection<Beneficiaire> Beneficiaires { get; set; }
    }
}
