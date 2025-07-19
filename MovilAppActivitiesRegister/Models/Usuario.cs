using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilAppActivitiesRegister.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        [MaxLength(50)]
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Contraseña { get; set; }

        public Usuario() { }
        
        public Usuario(string nombreUsuario, string nombre, string apellidPaterno
                      , string apellidoMaterno, string contraseña)
        {
            NombreUsuario= nombreUsuario;
            Nombre= nombre;
            ApellidoMaterno = apellidoMaterno;
            ApellidPaterno=apellidPaterno;
            Contraseña = contraseña;
            FechaRegistro = DateTime.Now;
        }
    }
}
