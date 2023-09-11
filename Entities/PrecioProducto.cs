using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PrecioProducto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; } = 0;
        public string Color { get; set; } = "negro";
    }
}
