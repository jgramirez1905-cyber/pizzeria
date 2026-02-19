using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        
        Console.Write("Fecha de nacimiento (yyyy-MM-dd): "); //2008-05-15
        DateTime nacimiento = DateTime.Parse(Console.ReadLine());
        DateTime ahora = DateTime.Now; //2024-06-01

        TimeSpan vida = ahora - nacimiento;
        Console.WriteLine($"Tienes {vida.Days} días de vida.");
        Console.WriteLine($"Hoy es: {ahora.ToString("dddd, dd MMMM yyyy", new CultureInfo("es-ES"))}");

        Console.WriteLine("\n--");

        
        Console.Write("Nombre completo: "); // Jeremy Ramirez
        string nombre = Console.ReadLine().Trim().ToUpper();
        Console.WriteLine($"BIENVENIDO, {nombre}");

        Console.WriteLine("\n------------------");

        
        Console.Write("Correo electrónico: "); //alumno@itla.edu.do
        string correo = Console.ReadLine().Trim();

        string[] partes = correo.Split('@');
        string dominio = partes[1];

        Console.WriteLine($"El dominio es: {dominio}");
        Console.WriteLine($"Primeras 3 letras del usuario: {partes[0].Substring(0, 3)}");

        Console.WriteLine("\n------------------");

        
        StringBuilder sb = new StringBuilder();
        sb.Append("Resumen: ");
        sb.Append($"{nombre} vive desde {nacimiento.Year}. ");

        DateTime en7Dias = ahora.AddDays(7);
        sb.Append($"En 7 días será {en7Dias.ToString("dd/MM/yyyy")}.");

        Console.WriteLine(sb.ToString());
    }
}