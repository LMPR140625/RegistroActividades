using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilAppActivitiesRegister.Models
{
    public class EstatusActividades
    {
        public int Estatus { get; set; }
        public int Cantidad { get; set; }

        public EstatusActividades(int _estatus, int _cantidad) 
        {
            Estatus = _estatus;
            Cantidad = _cantidad;  
        } 
    }
}
