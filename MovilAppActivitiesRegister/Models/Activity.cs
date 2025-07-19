using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MovilAppActivitiesRegister.Models
{
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        public int IdActivity { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string TypeActivity { get; set; }
        
        public string Usuario { get; set; }
        
        public int DuracionHoras { get; set; }        
        public int DuracionMinutos { get; set; }
        public int DuracionTotal { get; set; }
        public int DuracionTiempoExtra { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaINI { get; set; }
        
        public DateTime FechaFIN { get; set; }
        public int version { get; set; }
        public string Detail { get; set; }
        public bool IsOnBoardTime { get; set; }
        public int Status { get; set; }
        public string usuarioActualiza { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
