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
        public string Color
        {
            get
            {
                if (Operation == Links.Appro)
                {
                    return Links.ApproColor;
                }else if(Operation == Links.Retrait)
                {
                    return Links.RetraitColor;
                }else if (Operation == Links.Transfert)
                {
                    return Links.TransfertColor;
                }
                else
                {
                    return Links.PayementColor;
                }
            }
            set { Operation = value; }
        }
        public virtual Compte Compte { get; set; } = null!;
        public virtual Operateur Operateur { get; set; } = null!;
    }
}
