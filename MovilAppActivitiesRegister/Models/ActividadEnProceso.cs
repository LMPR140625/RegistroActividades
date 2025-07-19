using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilAppActivitiesRegister.Models
{
    public  class ActividadEnProceso
    {
        public int IdActividad { get; set; }
        public string Usuario { get; set; }

        public ActividadEnProceso(int IdActividad, string Usuario)
        {
            this.IdActividad = IdActividad;
            this.Usuario = Usuario;
        }
    }
}
