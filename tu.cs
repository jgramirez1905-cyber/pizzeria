using System;

namespace MiPrimeraApp 
{
    internal class NewBaseType
    {
        static void Main(string[] args)
        {
            
        }
    }

    internal class NewBaseType : NewBaseType
    {
        class Program : NewBaseType
    {
        class BellaNapoli
{
    static void Main(string[] args)
    {
        // ==========================================
        // 🍕 BIENVENIDA AL SISTEMA
        // ==========================================
        Console.WriteLine("=======================================");
        Console.WriteLine("   🍕 Bienvenido a Bella Napoli 🍕    ");
        Console.WriteLine("=======================================");
        Console.WriteLine();
        Console.WriteLine("Todas nuestras pizzas incluyen:");
        Console.WriteLine("🍅 Tomate");
        Console.WriteLine("🧀 Mozzarella");
        Console.WriteLine();

        // ==========================================
        // 📌 PASO 1: PREGUNTAR TIPO DE PIZZA
        // ==========================================
        Console.WriteLine("¿Qué tipo de pizza deseas?");
        Console.WriteLine("1 - Vegetariana 🫑");
        Console.WriteLine("2 - No Vegetariana 🍖");
        Console.Write("Selecciona una opción (1 o 2): ");

        string opcionTipo = Console.ReadLine();

        // Variable para guardar el tipo de pizza
        string tipoPizza = "";

        // Variable para guardar el ingrediente adicional
        string ingredienteAdicional = "";

        Console.WriteLine(); // Espacio visual

        // ==========================================
        // 📌 PASO 2: MOSTRAR MENÚ SEGÚN ELECCIÓN
        // ==========================================

        if (opcionTipo == "1")
        {
            tipoPizza = "Vegetariana";

            Console.WriteLine("Has elegido una pizza VEGETARIANA 🫑");
            Console.WriteLine();
            Console.WriteLine("Ingredientes adicionales disponibles:");
            Console.WriteLine("1 - 🫑 Pimiento");
            Console.WriteLine("2 - 🧊 Tofu");
            Console.Write("Elige un ingrediente (1 o 2): ");

            string opcionIngrediente = Console.ReadLine();

            // ==========================================
            // 📌 PASO 3: VALIDAR INGREDIENTE VEGETARIANO
            // ==========================================

            if (opcionIngrediente == "1")
            {
                ingredienteAdicional = "Pimiento";
            }
            else if (opcionIngrediente == "2")
            {
                ingredienteAdicional = "Tofu";
            }
            else
            {
                Console.WriteLine("❌ Opción inválida. Se seleccionará Pimiento por defecto.");
                ingredienteAdicional = "Pimiento";
            }
        }
        else if (opcionTipo == "2")
        {
            tipoPizza = "No Vegetariana";

            Console.WriteLine("Has elegido una pizza NO VEGETARIANA 🍖");
            Console.WriteLine();
            Console.WriteLine("Ingredientes adicionales disponibles:");
            Console.WriteLine("1 - 🍕 Peperoni");
            Console.WriteLine("2 - 🍖 Jamón");
            Console.WriteLine("3 - 🐟 Salmón");
            Console.Write("Elige un ingrediente (1, 2 o 3): ");

            string opcionIngrediente = Console.ReadLine();

            // ==========================================
            // 📌 PASO 3: VALIDAR INGREDIENTE NO VEGETARIANO
            // ==========================================

            if (opcionIngrediente == "1")
            {
                ingredienteAdicional = "Peperoni";
            }
            else if (opcionIngrediente == "2")
            {
                ingredienteAdicional = "Jamón";
            }
            else if (opcionIngrediente == "3")
            {
                ingredienteAdicional = "Salmón";
            }
            else
            {
                Console.WriteLine("❌ Opción inválida. Se seleccionará Peperoni por defecto.");
                ingredienteAdicional = "Peperoni";
            }
        }
        else
        {
            // ==========================================
            // ❌ SI EL USUARIO NO ELIGE 1 O 2
            // ==========================================
            Console.WriteLine("❌ Opción inválida.");
            Console.WriteLine("Se preparará una pizza Vegetariana con Pimiento por defecto.");

            tipoPizza = "Vegetariana";
            ingredienteAdicional = "Pimiento";
        }

        Console.WriteLine();
        Console.WriteLine("=======================================");
        Console.WriteLine("        📋 RESUMEN DEL PEDIDO         ");
        Console.WriteLine("=======================================");
        Console.WriteLine();
        Console.WriteLine("Tipo de pizza: " + tipoPizza);
        Console.WriteLine();
        Console.WriteLine("Ingredientes:");
        Console.WriteLine("- Tomate 🍅");
        Console.WriteLine("- Mozzarella 🧀");
        Console.WriteLine("- " + ingredienteAdicional);
        Console.WriteLine();
        Console.WriteLine("✅ ¡Gracias por ordenar en Bella Napoli!");
        Console.WriteLine("Tu pizza está en preparación... 🍕🔥");
    }
}



        }
    }
}
    
