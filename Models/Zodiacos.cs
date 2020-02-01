using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignoZodiaco.Models
{
    //clase para almacenar signos de zodiaco
    public class SignosZodiaco
    {
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        

        //constructor para incluir parametros
        public SignosZodiaco(string Nombre, DateTime FechaInicio, DateTime FechaFin)
        {
            this.Nombre = Nombre;
            this.FechaInicio = FechaInicio;
            this.FechaFin = FechaFin;
        }
    }
}
