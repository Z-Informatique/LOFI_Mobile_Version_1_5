using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Models
{
    public partial class PriceList
    {
        public int Id { get; set; }
        public decimal? Born1 { get; set; }
        public decimal? Born2 { get; set; }
        public decimal? SendCost { get; set; }
        public decimal? ReceiveCost { get; set; }
        public decimal? TransfertCostUba { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? TotalClientCost { get; set; }
    }
}
