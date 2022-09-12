using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public int Statut { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
