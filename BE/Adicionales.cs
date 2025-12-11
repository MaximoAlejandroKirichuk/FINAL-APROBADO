using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Adicionales :  Componente
    {
        public decimal Costo { get; set; }
        public string Nombre { get; set; }

        public Adicionales(string nombre, decimal costo)
        {
            Nombre = nombre;
            Costo = costo;
        }
        public override decimal ObtenerCosto()
        {
            return Costo;
        }
    }
}
