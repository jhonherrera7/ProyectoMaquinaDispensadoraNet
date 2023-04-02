using ProyectoFinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Controller
{
    public class ConsumableController
    {
        public Consumable[] productos { get; set; }
        public ConsumableController(Consumable[] productos)
        {
            this.productos = productos;
        }

        public Consumable[] TraerProducto()
        {
            return this.productos;

        }

        public void ActProductos(int codigo, int nuevoProducto)
        {
            bool productoEncontrado = false;

            foreach (Consumable dato in this.productos)
            {
                if (dato.codigo == codigo)
                {
                    dato.cantidad += nuevoProducto;
                    productoEncontrado = true;
                    break;
                }
            }

            if (!productoEncontrado)
            {
                Console.WriteLine("El código no es correcto");
            }
        }
      
        public void AgrProducto(Consumable producto)
        {
            int CodigoProdAgr = this.productos.Length + 1;
            Consumable[] nuevosProductos = new Consumable[CodigoProdAgr];
            Array.Copy(this.productos, nuevosProductos, this.productos.Length);
            nuevosProductos[CodigoProdAgr - 1] = producto;
            this.productos = nuevosProductos;
        }
     
        public void ProductoVendido(int codigo)
        {
            bool vendido = false;
            int i = 0;
            while (i < this.productos.Length)
            {
                if (this.productos[i].codigo == codigo && this.productos[i].cantidad > 0)
                {
                    this.productos[i].cantidad--;
                    vendido = true;
                    break;
                }
                else if (this.productos[i].cantidad == 0)
                {
                    Console.WriteLine("Este producto ya no se encuentra disponible");
                    break;
                }
                i++;
            }
            if (!vendido)
            {
                Console.WriteLine("El código ingresado no existe");
            }
        }
     
        public Consumable VerificarProducto(int codigo)
        {
            foreach (Consumable dato in this.productos)
            {
                if (dato.codigo == codigo)
                {
                    return dato;
                }
            }

            return null;
        }

        public string CambioMonedas(int precio, int monedaIngresada)
        {
            string cambio = "";
            int monedaVuelto = monedaIngresada - precio;

            do
            {
                if (monedaVuelto % 500 == 0)
                {
                    cambio += " 500 ";
                    monedaVuelto -= 500;
                    break;
                }
                else if (monedaVuelto % 200 == 0)
                {
                    cambio += " 200 ";
                    monedaVuelto -= 200;
                    break;
                }
                else if (monedaVuelto % 100 == 0)
                {
                    cambio += " 100 ";
                    monedaVuelto -= 100;
                    break;
                }
            } while (monedaVuelto > 0);

            return cambio;
        }

    }
}