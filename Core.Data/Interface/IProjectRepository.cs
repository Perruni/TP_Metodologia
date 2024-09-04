using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interface
{
    public interface IProjectRepository
    {
        public void AddSubasta(Subasta subasta);
        public void DeleteSubasta(int subastaId);
        public List<Subasta> GetAllSubasta();
        public Subasta GetSubastabyID(int id);
        public void UpdateSubasta(Subasta subasta, int subastaId);
        public void HabilitarSubasta(int subastaID, int estadoSubasta);

    }
        public List<Producto> GetAll();
        public void GetProducto(int ProductoID);
        public void AddProducto(Producto producto);
        public void UpdateProducto(Producto producto);
        public void HabilitarProducto(int PrudctoID, int habilitacionProducto);
        public void DeleteProducto(int ProductoID);

     }
}
