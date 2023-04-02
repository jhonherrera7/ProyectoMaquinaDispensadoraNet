using ProyectoFinal.Controller;
using ProyectoFinal.Model;
using System;

namespace View
{
    class View
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la maquina dispensadora");

            ConsumableController controller = new ConsumableController(new Consumable[2] { new Consumable(1, 1500, 3, "Galletas Chokis"), new Consumable(2, 800, 5, "Chocolatina yet") });
            Console.WriteLine("Es usted Proveedor o Cliente?");
            Console.WriteLine("[1] Proveedor\n[2] Cliente\n");


            int TipoUsuario = Int32.Parse(Console.ReadLine());


            switch (TipoUsuario)
            {
                
                case 1:
                    Console.WriteLine("Usted eligió proveedor\n");
                    Console.WriteLine("Los productos disponibles son: ");

                    foreach (Consumable dato in controller.TraerProducto())
                    {
                        
                        Console.WriteLine("------------------------------------------\nCodigo:" + dato.codigo + "\nPrecio: " + dato.precio + "\nCantidad: " + dato.cantidad + "\nNombre: " + dato.nombre + "\n------------------------------------------");
                    }
                    Console.WriteLine("------------------------------------------\n");
                    Console.WriteLine("Señor proveedor que desea hacer:\n[1] Actualizar cantidad de producto \n[2] Agregar nuevo producto");

                    int OpcionProveedor = Int32.Parse(Console.ReadLine());

                    switch (OpcionProveedor)
                    {
                        case 1:
                            Console.WriteLine("Ha elegido actualizar cantidad de producto\n ");

                            Console.WriteLine("Ingrese codigo del producto: ");

                            int codigoProducto = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Ingrese cantidad: ");

                            int cantidadProducto = Convert.ToInt32(Console.ReadLine());

                            controller.ActProductos(codigoProducto, cantidadProducto);

                            
                            break;
                        case 2:
                            Console.WriteLine("Ha elegido agregar nuevo producto\n ");
                            Console.WriteLine("Por favor ingrese el codigo del producto a agregar: ");

                            int ProductoAgregado = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Por favor ingrese el precio: ");

                            int PrecioProducto = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Por favor ingrese la cantidad: ");

                            int CantidadProducto = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Por favor ingrese el nombre: ");

                            String NombreProducto = Console.ReadLine();

                            controller.AgrProducto(new Consumable(ProductoAgregado, PrecioProducto, CantidadProducto, NombreProducto));
                            break;

                        default:
                            Console.WriteLine("Opción inválida");
                            break;
                    }

                    break;

                case 2:
                    Console.WriteLine("Usted eligió cliente\n");
                    Console.WriteLine("Productos disponibles: \n");

                    foreach (Consumable dato in controller.TraerProducto())
                    {
                        Console.WriteLine("------------------------------------------\nCodigo: " + dato.codigo + "\n Precio: " + dato.precio + "\n Cantidad: " + dato.cantidad + "\n Nombre: " + dato.nombre + "\n------------------------------------------");
                    }

                    Console.WriteLine("Ingrese el codigo del producto que deseaa consumir: ");

                    int OpcionCliente = Convert.ToInt32(Console.ReadLine());

                    Consumable productoConsumo = controller.VerificarProducto(OpcionCliente);

                    Console.WriteLine("El valor del producto es: " + productoConsumo.precio);

                    Console.WriteLine(" ");
                    
                    Console.WriteLine("Digite el valor con el que desea pagar:");
                    int valorIngresado = Convert.ToInt32(Console.ReadLine());
                    
                    while (valorIngresado >= productoConsumo.precio)
                    {
                        controller.ProductoVendido(OpcionCliente);

                        String vuelto = controller.CambioMonedas(productoConsumo.precio, valorIngresado);

                        Console.WriteLine("\nEl producto comprado es: " + productoConsumo.nombre + "\n Su cambio es: " + vuelto);
                        
                        if (valorIngresado < productoConsumo.precio)
                        {
                            Console.WriteLine("El valor ingresado no es suficiente para pagar el producto. Por favor ingrese un valor mayor o igual al precio del producto.");
                        }
                        break;
                    }
                    break;

                default:
                    Console.WriteLine("Tipo de usuario inválido");
                    break;
            }

            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("\nLa cantidad de productos actual es:  ");

            foreach (Consumable dato in controller.TraerProducto())
            {
                Console.WriteLine("------------------------------------------\nCodigo:" + dato.codigo + "\nPrecio: " + dato.precio + "\nCantidad: " + dato.cantidad + "\nNombre: " + dato.nombre + "\n------------------------------------------");
            }

            
        }

    }
}