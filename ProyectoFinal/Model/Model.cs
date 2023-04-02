using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Model
{
    public class Consumable
    {
        public Consumable() { }

        public Consumable(int codigo, int precio, int cantidad, string nombre)
        {
            this.codigo = codigo;
            this.precio = precio;
            this.cantidad = cantidad;
            this.nombre = nombre;
        }

        public int codigo { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
        public string nombre { get; set; }
    }
}