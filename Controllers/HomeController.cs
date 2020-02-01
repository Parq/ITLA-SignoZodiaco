using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignoZodiaco.Models;

namespace SignoZodiaco.Controllers
{

    public class HomeController : Controller
    {
        //ajuste de controlador index para dirigir a vista de formulario
        public IActionResult Index()
        {
            return View("ZodiacForm");
        }

        //creacion de lista con signos de zodiaco y retorno de signo segun fecha
        public string GetSigno(DateTime Fecha)
        {
            //asumir el año de la fecha sometida por usuario
            var year = Fecha.Year;
            //sintaxis para crear coleccion (multiples objetos a lista)
            var list = new List<SignosZodiaco>()
            {
                new SignosZodiaco("Acuario", new DateTime(year, 01, 20), new DateTime(year, 02, 18)),
                new SignosZodiaco("Piscis", new DateTime(year,02,19), new DateTime(year,03,20)),
                new SignosZodiaco("Aries", new DateTime(year,03,21), new DateTime(year,04,19)),
                new SignosZodiaco("Tauro", new DateTime(year,04,20), new DateTime(year,05,20)),
                new SignosZodiaco("Géminis", new DateTime(year,05,21), new DateTime(year,06,20)),
                new SignosZodiaco("Cáncer", new DateTime(year,06,21), new DateTime(year,07,22)),
                new SignosZodiaco("Leo", new DateTime(year,07,23), new DateTime(year,08,22)),
                new SignosZodiaco("Virgo", new DateTime(year,08,23), new DateTime(year,09,22)),
                new SignosZodiaco("Libra", new DateTime(year,09,23), new DateTime(year,10,22)),
                new SignosZodiaco("Escorpio", new DateTime(year,10,23), new DateTime(year,11,21)),
                new SignosZodiaco("Sagitario", new DateTime(year,11,22), new DateTime(year,12,21)),
                new SignosZodiaco("Capricornio", new DateTime(year,12,22), new DateTime(year,01,19))
            };

            //metodo de linq que localiza el primer articulo de la lista que cumpla con la condicion
            //lambda especificada
            return list.FirstOrDefault(x => Fecha >= x.FechaInicio.Date && Fecha <= x.FechaFin.Date).Nombre;
        }

        //Inclusion de atributo post para indicar que este metodo debe ejecutarse cuando usuario realice post
        //El atributo http get esta por default
        [HttpPost]
        public IActionResult ZodiacForm(DateTime Fecha)
        {
            //creacion de objeto dinamico Viewbag (objeto que se le pueden asignar propiedades arbitrarias)
            //habilitando estos valores mas adelante. 
            //De esta manera invocamos el metodo getsigno y guardamos el valor del signo zodical
            ViewBag.Signo = this.GetSigno(Fecha);
            return View("ZodiacResult");
        }

        //inclusion de accion para cuando, desde el resultado, quieran volver al formulario
        public ViewResult ZodiacResult()
        {
            return View("ZodiacResult");
        }
    }

    /*NOTAS DE CLASE:
     * 1-Existe una diferencia entre viewresult y iactionresult. Iactionresult, a parte de permitir
     * el retorno de una vista, permite ingresar codigo para la logica del programa
     * El profesor indica que adentraremos mas en su uso mas adelante
     * 2-C# ignora el año cuando evalua un datetime 
     * 3-Datetime puede evaluarse como un numero
     * 4-Un truco para halar solo la fecha o el dia de un datetime es el siguiente:
     * var mesUsuario = Fecha.Month o Fecha.Day
     */
}
