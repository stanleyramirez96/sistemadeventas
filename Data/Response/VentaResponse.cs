using sistemadeventas.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Response
{

    public class VentaResponse
    {
        [Key]
        public int ID { get; set; }
        public string? NombreP { get; set; }
        public string? DetalleV { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Total { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }

}

