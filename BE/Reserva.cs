using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reserva : Componente
    {
        public int Id { get; set; }
        public int HuespedId { get; set; }
        public int HabitacionId { get; set; }
        public DateTime FechaCheckIn { get; set; }
        public decimal CostoFinal { get; set; }

        public List<Adicionales> Adicionales { get; set; }
        public override void AgregarHijo(Adicionales c)
        {
            Adicionales.Add(c);
        }
        public override decimal ObtenerCosto()
        {
            decimal total = 0m;
            foreach (var item in Adicionales)
            {
                total += item.ObtenerCosto();
            }
            return total;
        }
    }
}
