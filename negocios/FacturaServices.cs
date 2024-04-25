using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using POS_DePrisa.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.negocios
{
    internal class FacturaServices
    {
        DFactura dFactura;

        public FacturaServices()
        {
            dFactura = new DFactura();
        }

        public bool guardarFactura(entidades.Factura factura)
        {
            return dFactura.GuardarFactura(factura);
        }

        public ResultadoOperacion guardarFactura(entidades.Factura factura, List<entidades.DetalleFactura> detallesFactura)
        {
           ResultadoOperacion resultado = new ResultadoOperacion();
            if (!dFactura.GuardarFactura(factura))
            {
                resultado.Mensaje = "Error al guardar la factura";
                resultado.IsExitoso = false;
                return resultado;
            }

            if (!dFactura.GuardarDetallesFactura(detallesFactura))
            {
                resultado.Mensaje = "Error al guardar los detalles de la factura";
                resultado.IsExitoso = false;
                return resultado;
            }

            //disminuir stock

            DProducto dProducto = new DProducto();
            var resultado1 = false;
            String errorMessage = "Error al disminuir el stock del producto: \n";
            foreach (var detalle in detallesFactura)
            {
                resultado1 = dProducto.disminuirStock(detalle.IdProducto, detalle.Cantidad);

                if(!resultado1)
                {
                    errorMessage +=  + detalle.IdProducto + "\n";
                }
            }

            if (errorMessage != "Error al disminuir el stock del producto: \n")
            {
                resultado.Mensaje = $"Ocurrio un error al disminuir el stock del producto, pero la venta fue realizada.\n Contacte a su administrador de sistema\n {errorMessage }";
                resultado.IsExitoso = false;
                return resultado;
            }
            

            resultado.Mensaje = "Factura guardada con éxito";
            resultado.IsExitoso = true;
            return resultado;
        }

        public int obtenerIdUltimaFactura()
        {
            return dFactura.ObtenerIdUltimaFactura();
        }

        public bool guardarDetalleFactura(entidades.DetalleFactura detalleFactura)
        {
            return dFactura.GuardarDetalleFactura(detalleFactura);
        }

        public bool guardarDetalleFactura(List<entidades.DetalleFactura> detallesFactura)
        {
            return dFactura.GuardarDetallesFactura(detallesFactura);
        }

    }
}
