using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    public class HuespedBLL : IABM<Huesped>, ISujeto
    {
        private HuespedMPP mppHuesped = new HuespedMPP();
        private List<IObservador> observadores = new List<IObservador>();
        public bool Agregar(Huesped objeto)
        {
            return mppHuesped.Agregar(objeto);
        }

        public bool Eliminar(int id)
        {
            return mppHuesped.Eliminar(id);
        }

        public bool Modificar(Huesped objeto)
        {
            return mppHuesped.Modificar(objeto);
        }

        public List<Huesped> ListarTodos()
        {
            return mppHuesped.Listar();
        }

        public void Suscribir(IObservador observador)
        {
            observadores.Add(observador);
        }

        public void Desuscribir(IObservador observador)
        {
            observadores.Remove(observador);
        }

        public void NotificarTodos()
        {
            foreach (var o in observadores)
            {
                o.Actualizar();
            }
        }

        public void Importar(string ruta)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Huesped));
            using(StreamReader sr = new StreamReader(ruta))
            {
                var huesped = (Huesped)xml.Deserialize(sr);
                Agregar(huesped);
                NotificarTodos();
            }
        }

        public void Exportar(string ruta, Huesped huesped)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Huesped));
            using(StreamWriter sw = new StreamWriter(ruta))
            {
                serializer.Serialize(sw, huesped);
            }
        }
    }
}
