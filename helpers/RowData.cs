using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.helpers
{
    public class RowData
    {
        public RowData(int idProducto, string codigoBarra, string nombre, string descripcion, double precio, int cantidad, bool tieneIva, bool tieneKit, double descuentoMaximo, bool estado, int idcategoria)
        {
            IdProducto = idProducto;
            CodigoBarra = codigoBarra;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
            TieneIva = tieneIva;
            TieneKit = tieneKit;
            DescuentoMaximo = descuentoMaximo;
            this.estado = estado;
            this.idcategoria = idcategoria;
        }

        public RowData()
        {
            descuentoAplicado = 0;
        }

        public int IdProducto { get; set; }
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Importe => Cantidad * Precio;
        public bool TieneIva { get; set; }
        public bool TieneKit { get; set; }
        public double DescuentoMaximo { get; set; }

        public double descuentoAplicado { get; set; }
        public bool estado { get; set; }
        public int idcategoria { get; set; }


    }
}
