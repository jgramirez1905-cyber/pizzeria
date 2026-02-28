using System;
using System.Collections.Generic;

class Reserva
{
    public string Nombre;
    public int Personas;
    public string Restaurante;
    public string Turno;
}

class Program
{
    static Dictionary<string, int> capacidad = new Dictionary<string, int>()
    {
        {"Ember",3},
        {"Zao",4},
        {"Grappa",2},
        {"Larimar",3}
    };

    static List<Reserva> reservas = new List<Reserva>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== SISTEMA DE RESERVAS SENATOR =====");
            Console.WriteLine("1. Realizar Reservación");
            Console.WriteLine("2. Eliminar Reserva");
            Console.WriteLine("3. Ver Disponibilidad");
            Console.WriteLine("4. Imprimir Listado");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RealizarReserva();
                    break;

                case "2":
                    EliminarReserva();
                    break;

                case "3":
                    VerDisponibilidad();
                    break;

                case "4":
                    ImprimirListado();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void RealizarReserva()
    {
        Console.Write("Nombre del cliente: ");
        string nombre = LimpiarNombre(Console.ReadLine());

        Console.Write("Cantidad de personas: ");
        int personas = int.Parse(Console.ReadLine());

        Console.Write("Restaurante (Ember, Zao, Grappa, Larimar): ");
        string restaurante = Console.ReadLine();

        Console.Write("Turno (A = 6-8PM, B = 8-10PM): ");
        string turno = Console.ReadLine().ToUpper();

        if (!capacidad.ContainsKey(restaurante))
        {
            Console.WriteLine("Restaurante inválido.");
            return;
        }

        int ocupados = ContarReservas(restaurante, turno);

        if (ocupados >= capacidad[restaurante])
        {
            Console.WriteLine("❌ FULL: No quedan cupos en ese horario.");
            return;
        }

        Reserva nueva = new Reserva()
        {
            Nombre = nombre,
            Personas = personas,
            Restaurante = restaurante,
            Turno = turno
        };

        reservas.Add(nueva);

        Console.WriteLine("✅ Reserva confirmada.");
    }

    static void EliminarReserva()
    {
        Console.Write("Nombre del cliente a eliminar: ");
        string nombre = LimpiarNombre(Console.ReadLine());

        Reserva encontrada = reservas.Find(r => r.Nombre == nombre);

        if (encontrada != null)
        {
            reservas.Remove(encontrada);
            Console.WriteLine("Reserva eliminada.");
        }
        else
        {
            Console.WriteLine("No se encontró la reserva.");
        }
    }

    static void VerDisponibilidad()
    {
        Console.Write("Turno (A o B): ");
        string turno = Console.ReadLine().ToUpper();

        Console.WriteLine("\nDisponibilidad:");

        foreach (var r in capacidad)
        {
            int ocupados = ContarReservas(r.Key, turno);
            int disponibles = r.Value - ocupados;

            Console.WriteLine($"{r.Key} -> {disponibles} grupos disponibles");
        }
    }

    static void ImprimirListado()
    {
        Console.Write("Restaurante: ");
        string restaurante = Console.ReadLine();

        Console.Write("Turno (A o B): ");
        string turno = Console.ReadLine().ToUpper();

        Console.WriteLine("\nListado de reservas:");

        foreach (var r in reservas)
        {
            if (r.Restaurante == restaurante && r.Turno == turno)
            {
                Console.WriteLine($"Cliente: {r.Nombre} | Personas: {r.Personas}");
            }
        }
    }

    static int ContarReservas(string restaurante, string turno)
    {
        int contador = 0;

        foreach (var r in reservas)
        {
            if (r.Restaurante == restaurante && r.Turno == turno)
                contador++;
        }

        return contador;
    }

    static string LimpiarNombre(string nombre)
    {
        nombre = nombre.Trim();
        nombre = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre.ToLower());
        return nombre;
    }
}