using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Componente
    {
        public virtual void AgregarHijo(Adicionales c) { }
        public virtual void EliminarHijo(Adicionales c) { }
        public abstract decimal ObtenerCosto();

    }
}
