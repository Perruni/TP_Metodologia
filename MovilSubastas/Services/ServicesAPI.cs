using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;


namespace MovilSubastas.Services
{
    public class ServicesAPI : IServicesAPI
    {
        private readonly HttpClient _client;

        
        public ServicesAPI(HttpClient client)
        {
            _client = client;  
        }

        public Task<int> GetCantidadOfertas(int productoID)
        {
            throw new NotImplementedException();
        }

        public Task<Datos_usuario> GetDatosUsuario(int userID)
        {
            throw new NotImplementedException();
        }

        public Task<Oferta> GetOfertaId(int ofertaID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Oferta>> GetOfertasGanadoras(int subastaID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Oferta>> GetOfertasUsuario(int usuarioID)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetProducto(int productoID)
        {
            throw new NotImplementedException();
        }

        public Task<Subasta?> GetSubasta(int subastaID)
        {
            throw new NotImplementedException();
        }

        public Task<Subasta?> GetSubastaProductos(int subastaID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subasta>> GetSubastasActivas()
        {
            List<Subasta>? result = null;

            try
            {
                var response = await _client.GetAsync("Subasta/Activas");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<Subasta>>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;

        }


        public Task<List<Subasta>> GetSubastasFinalizadas()
        {
            throw new NotImplementedException();
        }

        public Task<List<Subasta>> GetSubastasProximas()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetUsuario(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
