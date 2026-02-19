# esta es mi practica
#
#
using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        // Datos automáticos
        DateTime nacimiento = new DateTime(2008, 5, 15);
        string nombre = "Jeremy Ramirez";
        string correo = "alumno@itla.edu.do";

        DateTime ahora = DateTime.Now;

        TimeSpan vida = ahora - nacimiento;
        Console.WriteLine($"Tienes {vida.Days} días de vida.");
        Console.WriteLine($"Hoy es: {ahora.ToString("dddd, dd MMMM yyyy", new CultureInfo("es-ES"))}");

        string nombreFormateado = nombre.Trim().ToUpper();
        Console.WriteLine($"BIENVENIDO, {nombreFormateado}");

        string[] partes = correo.Split('@');
        string dominio = partes[1];

        Console.WriteLine($"El dominio es: {dominio}");
        Console.WriteLine($"lo pedido: {partes[0].Substring(0, 3)}");


        Console.WriteLine("esto aprendi en unos videos que eh visto hace un año en mi antiguo curso");
    }
}