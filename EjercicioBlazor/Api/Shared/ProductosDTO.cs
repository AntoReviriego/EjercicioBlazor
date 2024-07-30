namespace Api.Shared
{
    public class ProductosDTO
    {
        public long Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public string Marca { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public DateTime InsertDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool Enable { get; set; }
    }
}
