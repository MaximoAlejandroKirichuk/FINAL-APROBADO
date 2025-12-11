using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Huesped
    {
        public Huesped(string nombreCompleto, string pasaporte, string email)
        {
            NombreCompleto = nombreCompleto;
            Pasaporte = pasaporte;
            Email = email;
        }
        public Huesped()
        {
            
        }

        public Huesped(int id, string nombreCompleto, string pasaporte, string email)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Pasaporte = pasaporte;
            Email = email;
        }

        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Pasaporte { get; set; }
        public string Email { get; set; }

    }
}
