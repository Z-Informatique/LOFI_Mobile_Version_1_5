using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Pay
    {
        public Pay()
        {
            Beneficiaires = new HashSet<Beneficiaire>();
            Configs = new HashSet<Config>();
            Operateurs = new HashSet<Operateur>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Code { get; set; }
        public string Indicatif { get; set; }
        public int Statut { get; set; }

        public virtual ICollection<Beneficiaire> Beneficiaires { get; set; }
        public virtual ICollection<Config> Configs { get; set; }
        public virtual ICollection<Operateur> Operateurs { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
