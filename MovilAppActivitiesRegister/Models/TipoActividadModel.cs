using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilAppActivitiesRegister.Models
{
    public class TipoActividadModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string tipoActividad { get; set; }
        public string descripcion { get; set; }
    }
}
