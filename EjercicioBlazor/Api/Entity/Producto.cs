using System;
using System.Collections.Generic;

namespace Api.Entity;

public partial class Producto
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public long IdMarca { get; set; }

    public long IdCategoria { get; set; }

    public DateTime InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Enable { get; set; }

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
