using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class User
    {
        public User()
        {
            Comptes = new HashSet<Compte>();
            Transactions = new HashSet<Transaction>();
            Transferts = new HashSet<Transfert>();
        }

        public int UserId { get; set; }
        public string NomUser { get; set; }
        public string PrenomUser { get; set; }
        public string Email { get; set; }
        public string PasswordUser { get; set; }
        public string TelUser { get; set; }
        public int? Code { get; set; }
        public int? UserRole { get; set; }
        public string Token { get; set; }
        public string ExpireToken { get; set; }
        public int? Statut { get; set; }
        public DateTime UCreatedAt { get; set; }
        public int IdPays { get; set; }
        public string Image { get; set; }
        public int IdCategorie { get; set; }

        public virtual Categorie Categorie { get; set; } = null!;
        public virtual Pay Pays { get; set; } = null!;
        public virtual ICollection<Compte> Comptes { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Transfert> Transferts { get; set; }

    }
}
