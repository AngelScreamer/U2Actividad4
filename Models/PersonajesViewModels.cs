using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unidad2Actividad4.Models
{
    public class PersonajesViewModels
    {
        public PersonajesViewModels()
        {
            Apariciones = new HashSet<Apariciones>();
        }
        public string NombrePelicula { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public string Descripcion { get; set; }
        public string NombreOriginal { get; set; }
        public int Id { get; set; }
        public IEnumerable<Apariciones> Apariciones { get; set; }
    }
}
