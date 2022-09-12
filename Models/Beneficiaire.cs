namespace LOFI.Models
{
    public partial class Beneficiaire
    {
        public int IdBenef { get; set; }
        public string NomBenef { get; set; }
        public string PrenomBenef { get; set; }
        public string TelBenef { get; set; }
        public string NumTransac { get; set; }
        public int IdPays { get; set; }
        public int IdPayement { get; set; }

        public virtual Methode Methode { get; set; } = null!;
        public virtual Pay Pays { get; set; } = null!;
    }
}
