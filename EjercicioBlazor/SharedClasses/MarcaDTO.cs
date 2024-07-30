using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses
{
    public class MarcaDTO
    {
        public long Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public DateTime InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool Enable { get; set; }
    }
}
