using JsonDeserializeTest.JsonDeserializeTest;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace JsonDeserializeTest
{

    namespace JsonDeserializeTest
    {
        public class SubastaDTO
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
            public int EstadoSubasta { get; set; }

            [JsonPropertyName("metodosdePago")]
            public int MetodosdePago { get; set; }
        }

        public class SubastaResponse
        {
            [JsonPropertyName("$id")]
            public string Id { get; set; }

            [JsonPropertyName("$values")]
            public List<SubastaDTO> Values { get; set; }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // Configura HttpClient
            using HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7073/api/") // Cambia a la URL de tu API
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Llama a la API y deserializa la respuesta
            try
            {
                HttpResponseMessage response = await client.GetAsync("Subasta/Activa");
                response.EnsureSuccessStatusCode(); // Lanza una excepción si el código de estado no es exitoso

                // Lee el contenido de la respuesta
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserializar el JSON a un objeto de tipo SubastaResponse
                var subastaResponse = JsonSerializer.Deserialize<SubastaResponse>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Verificar si la deserialización fue exitosa y hay valores
                if (subastaResponse != null && subastaResponse.Values != null)
                {
                    Console.WriteLine("Deserialización exitosa:");
                    foreach (var subasta in subastaResponse.Values)
                    {
                        Console.WriteLine($"ID: {subasta.SubastaID}, Título: {subasta.Titulo}, Fecha Inicio: {subasta.FechaInicio}, Estado: {subasta.EstadoSubasta}");
                    }
                }
                else
                {
                    Console.WriteLine("La deserialización devolvió nulo o no contiene valores.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al llamar a la API: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar: {ex.Message}");
            }
        }
    }
}