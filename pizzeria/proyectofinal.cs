using System;

class Program
{
        // Capacidad máxima del inventario
    const int MAX = 100;

        // Arreglos paralelos
    static string[] nombres = new string[MAX];
    static double[] precios = new double[MAX];
    static int[] stock = new int[MAX];

    static int cantidadProductos = 0;

    static void Main()
    {
        int opcion = 0;

        do
        {
            MostrarMenu();

            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarProducto();
                    break;

                case 2:
                    ListarProductos();
                    break;

                case 3:
                    ActualizarStock();
                    break;

                case 4:
                    EliminarProducto();
                    break;

                case 5:
                    GenerarFactura();
                    break;

                case 6:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 6);
    }

    // ---------------- MENU ----------------

    static void MostrarMenu()
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine("   SISTEMA DE INVENTARIO");
        Console.WriteLine("        LA TIENDITA");
        Console.WriteLine("==============================");

        Console.WriteLine("1. Registrar producto");
        Console.WriteLine("2. Listar productos");
        Console.WriteLine("3. Actualizar stock");
        Console.WriteLine("4. Eliminar producto");
        Console.WriteLine("5. Generar factura");
        Console.WriteLine("6. Salir");

        Console.WriteLine("==============================");
    }

    // ---------------- REGISTRAR PRODUCTO ----------------

    static void RegistrarProducto()
    {
        if (cantidadProductos >= MAX)
        {
            Console.WriteLine("Inventario lleno.");
            return;
        }

        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Precio: ");
        double precio;

        if (!double.TryParse(Console.ReadLine(), out precio))
        {
            Console.WriteLine("Precio inválido.");
            return;
        }

        Console.Write("Cantidad en stock: ");
        int cantidad;

        if (!int.TryParse(Console.ReadLine(), out cantidad))
        {
            Console.WriteLine("Cantidad inválida.");
            return;
        }

        nombres[cantidadProductos] = nombre;
        precios[cantidadProductos] = precio;
        stock[cantidadProductos] = cantidad;

        cantidadProductos++;

        Console.WriteLine("Producto registrado correctamente.");
    }

    // ---------------- LISTAR PRODUCTOS ----------------

    static void ListarProductos()
    {
        if (cantidadProductos == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        Console.WriteLine("\n===== INVENTARIO =====");

        for (int i = 0; i < cantidadProductos; i++)
        {
            Console.WriteLine(
                (i + 1) + ". " +
                nombres[i] +
                " | Precio: $" +
                precios[i] +
                " | Stock: " +
                stock[i]
            );
        }
    }

    // ---------------- ACTUALIZAR STOCK ----------------

    static void ActualizarStock()
    {
        ListarProductos();

        if (cantidadProductos == 0)
            return;

        Console.Write("Seleccione el número del producto: ");
        int indice;

        if (!int.TryParse(Console.ReadLine(), out indice))
        {
            Console.WriteLine("Número inválido.");
            return;
        }

        indice--;

        if (indice < 0 || indice >= cantidadProductos)
        {
            Console.WriteLine("Producto no válido.");
            return;
        }

        Console.Write("Nuevo stock: ");
        int nuevoStock;

        if (!int.TryParse(Console.ReadLine(), out nuevoStock))
        {
            Console.WriteLine("Cantidad inválida.");
            return;
        }

        stock[indice] = nuevoStock;

        Console.WriteLine("Stock actualizado.");
    }

    // ---------------- ELIMINAR PRODUCTO ----------------

    static void EliminarProducto()
    {
        ListarProductos();

        if (cantidadProductos == 0)
            return;

        Console.Write("Seleccione el número del producto a eliminar: ");
        int indice;

        if (!int.TryParse(Console.ReadLine(), out indice))
        {
            Console.WriteLine("Número inválido.");
            return;
        }

        indice--;

        if (indice < 0 || indice >= cantidadProductos)
        {
            Console.WriteLine("Producto inválido.");
            return;
        }

        for (int i = indice; i < cantidadProductos - 1; i++)
        {
            nombres[i] = nombres[i + 1];
            precios[i] = precios[i + 1];
            stock[i] = stock[i + 1];
        }

        cantidadProductos--;

        Console.WriteLine("Producto eliminado.");
    }

    // ---------------- GENERAR FACTURA ----------------

    static void GenerarFactura()
    {
        if (cantidadProductos == 0)
        {
            Console.WriteLine("No hay productos en inventario.");
            return;
        }

        double total = 0;
        string factura = "";

        char continuar = 's';

        while (continuar == 's' || continuar == 'S')
        {
            ListarProductos();

            Console.Write("Seleccione el producto: ");
            int indice;

            if (!int.TryParse(Console.ReadLine(), out indice))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            indice--;

            if (indice < 0 || indice >= cantidadProductos)
            {
                Console.WriteLine("Producto inválido.");
                continue;
            }

            Console.Write("Cantidad: ");
            int cantidad;

            if (!int.TryParse(Console.ReadLine(), out cantidad))
            {
                Console.WriteLine("Cantidad inválida.");
                continue;
            }

            if (cantidad > stock[indice])
            {
                Console.WriteLine("Stock insuficiente.");
                continue;
            }

            double subtotal = cantidad * precios[indice];

            stock[indice] -= cantidad;

            factura += nombres[indice] +
                       " x" + cantidad +
                       " = $" + subtotal + "\n";

            total += subtotal;

            Console.Write("¿Agregar otro producto? (s/n): ");
            continuar = Convert.ToChar(Console.ReadLine());
        }

        Console.WriteLine("\n======= FACTURA =======");
        Console.WriteLine(factura);
        Console.WriteLine("TOTAL: $" + total);
        Console.WriteLine("=======================");
    }
}