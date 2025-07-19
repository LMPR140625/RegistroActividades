using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilAppActivitiesRegister.Models
{
    public class RegistroInicioSession
    {
        [PrimaryKey,AutoIncrement]
        public int IdRegistro { get; set; }
        [MaxLength(50)]
        public string  Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool estatusAttemp { get; set; } // true -> accedio , false -> intento fallido
    }
}
