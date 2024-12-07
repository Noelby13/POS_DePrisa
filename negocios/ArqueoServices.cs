using POS_DePrisa.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_DePrisa.negocios
{
    internal class ArqueoServices
    {

        private DArqueoCaja dArqueo;
        public ArqueoServices()
        {
            dArqueo = new DArqueoCaja();
        }
        

        //validar si existe un arqueo abierto
        /*public bool validarArqueoAbierto()
        {
            return dArqueo.ExisteArqueoCajaAbierto();
        }*/

        public bool guardarArqueo(entidades.ArqueoCaja arqueo)
        {
            return dArqueo.GuardarArqueoCaja(arqueo);
        }

        //inicia el arqueo de caja
        //1 = Abierto, 2 = Cerrado,
        public bool iniciarArqueo(entidades.ArqueoCaja arqueo)
        {
            return dArqueo.IniciarArqueoCaja(arqueo); 
        }

        //obtener arqueo de caja abierto
        public entidades.ArqueoCaja obtenerArqueoAbierto()
        {
            return dArqueo.ObtenerArqueoCajaAbierto();
        }
    }
}
