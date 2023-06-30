using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;


namespace sistemadeventas.Data.Models;

public class VentaDetalle
{
    public VentaDetalle()
    {
        //Venta = new Venta();
        //Producto = new Producto();
    }

    [Key]
    public int Id { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioV { get; set; }

    public static VentaDetalle Crear(VentaDetalleRequest request)
    => new()
    {
        ProductoId = request.ProductoId,
        Cantidad = request.Cantidad,
        PrecioV = request.PrecioV,
    };


    #region Relaciones
    [ForeignKey(nameof(VentaId))]
    public virtual Venta Venta { get; set; }
    [ForeignKey(nameof(ProductoId))]
    public virtual Producto Producto { get; set; }
    #endregion

    [NotMapped]
    public decimal SubTotal => Cantidad * PrecioV;

    public VentaDetalleResponse ToResponse()
        => new()
        {
            Id = Id,
            Producto = Producto.ToResponse(),
            Cantidad = Cantidad,
            PrecioV = PrecioV,
            VentaId = VentaId
        };


}
