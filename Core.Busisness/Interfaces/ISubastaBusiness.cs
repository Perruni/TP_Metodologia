using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness.Interfaces
{
    public interface ISubastaBusiness
    {
        public void AddSubasta (Subasta subastaNueva);
        public List<Subasta> GetAllSubasta ();
        public Subasta GetSubastabyID (int id);
        public void UpdateSubasta (Subasta subasta, int id);
        public void DeleteSubastabyID (Subasta subasta);

    }
}
