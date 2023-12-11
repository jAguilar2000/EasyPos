using System.Collections.Generic;

namespace EasyPos.Models.ViewModels
{
    public class InventarioVM
    {
        public List<Inventario> InventarioList { get; set; }

        public int productoId { get; set; }
        public Producto descripcion { get; set; }
        //public UsuarioRol UsuarioRol { get; set; }
        public Inventario Inventario { get; set; }

        public Producto Producto { get; set; }

        public List<Producto> ProductoList { get; set; }

        //public bool estado { get; set; }

     
    }

}