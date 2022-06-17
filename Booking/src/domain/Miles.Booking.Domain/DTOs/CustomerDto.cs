using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miles.Booking.Domain.DTOs
{
    public class CustomerDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
