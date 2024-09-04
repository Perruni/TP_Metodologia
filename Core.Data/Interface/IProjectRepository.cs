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
}
