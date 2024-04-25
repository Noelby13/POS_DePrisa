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
