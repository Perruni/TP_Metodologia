using Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shared.APITest
{


    using System.Text.Json.Serialization;

    public class SubastaAPI
    {
        [JsonPropertyName("subastaID")]
        public int SubastaID { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("fechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonPropertyName("fechaFinalizado")]
        public DateTime FechaFinalizado { get; set; }

        [JsonPropertyName("estadoSubasta")]
        public Estado EstadoSubasta { get; set; }

        [JsonPropertyName("metodosdePago")]
        public MetododePago MetodosdePago { get; set; }
    }

    public class SubastaResponse
    {
        [JsonPropertyName("$id")]
        public string Id { get; set; }

        [JsonPropertyName("$values")]
        public List<SubastaAPI> Values { get; set; }
    }


    public enum Estado
    {
        Proxima = 1,
        Activa = 2,
        Finalizadas = 3,
        Deshabilitado = 4,

    }

    public enum MetododePago
    {
        Tarjetas = 1,
        Transferencia = 2,
        Ambos = 3,
    }

}
