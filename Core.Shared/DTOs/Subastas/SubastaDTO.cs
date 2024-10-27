using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Entities.Subasta;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Core.Shared.DTOs.Subastas
{
    public class SubastaDTO
    {
        public int subastaID { get; set; }
        public string titulo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinalizado { get; set; }
        public EstadoSubasta estadoSubasta { get; set; }
        public MetodosdePago metodosdePago { get; set; }
    }


    public class SubastaResponseDTO
    {
        public string Id { get; set; }

        public List<SubastaDTO> Values { get; set; }
    }


}
