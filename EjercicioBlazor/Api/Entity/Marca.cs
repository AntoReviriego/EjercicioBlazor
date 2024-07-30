using System;
using System.Collections.Generic;

namespace Api.Entity;

public partial class Marca
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Enable { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
