using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Entities.Subasta;
using Newtonsoft.Json;

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

    public class SubastaResponse
    {

        [JsonProperty("$id")]
        public string Id { get; set; }

        [JsonProperty("$values")]
        public List<SubastaDTO> Values { get; set; }

    }


    

}
