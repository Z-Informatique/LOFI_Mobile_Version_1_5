using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class Config
    {
        public int Id { get; set; }
        public string Telephone { get; set; }
        public string TypeOp { get; set; }
        public int IdPays { get; set; }

        public virtual Pay Pays { get; set; } = null!;
    }
}
