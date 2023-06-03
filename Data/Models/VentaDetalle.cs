using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using sistemadeventas.Data.Models;
namespace sistemadeventas.Data.Models;

public class VentaDetalle
{
    public VentaDetalle()
    {
        Venta = new Venta();
        Producto = new Producto();
    }
    [Key]
    public int ID { get; set; }
    public int VentaId { get; set; }
    
    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }

    #region Relaciones
    [ForeignKey(nameof(VentaId))]
    public virtual Venta Venta { get; set; }
    [ForeignKey(nameof(ProductoId))]
    public virtual Producto Producto { get; set; }
    #endregion
}
