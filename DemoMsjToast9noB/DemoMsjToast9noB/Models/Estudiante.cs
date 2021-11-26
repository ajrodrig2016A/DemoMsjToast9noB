using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DemoMsjToast9noB.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        [MaxLength(50)]
        public string Nombre { set; get; }

        [MaxLength(30)]
        public string Usuario { set; get; }

        public string Contrasenia { set; get; }

    }
}
