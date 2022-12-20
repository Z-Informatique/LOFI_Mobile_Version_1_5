using LOFI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Historique
    {
        public int Id { get; set; }
        public int IdCompte { get; set; }
        public string IdTransaction { get; set; }
        public int IdPayement { get; set; }
        public string Operation { get; set; }
        public string Intitule { get; set; }
        public int Statut { get; set; }
        public DateTime DateOperation { get; set; }
        public decimal? Montant { get; set; }
        public int Flux { get; set; }
        public decimal? Frais { get; set; }
        public int? IdBenef { get; set; }
        public string Motif { get; set; }
        public Color Color
        {
            get
            {
                if (Operation == Links.Appro)
                {
                    return Color.FromHex(Links.ApproColor);
                }else if(Operation == Links.Retrait)
                {
                    return Color.FromHex(Links.RetraitColor);
                }else if (Operation == Links.Transfert)
                {
                    return Color.FromHex(Links.TransfertColor);
                }
                else
                {
                    return Color.FromHex(Links.PayementColor);
                }
            }
        }
        public virtual Compte Compte { get; set; } = null!;
        public virtual Operateur Operateur { get; set; } = null!;
    }
}
