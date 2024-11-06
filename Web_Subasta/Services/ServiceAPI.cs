using Core.Entities;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using Core.Shared.DTOs.Producto;
using Core.Shared.DTOs.Oferta;
using Core.Shared.DTOs.Usuario;
using Core.Shared.DTOs.Subastas;


namespace Web_Subasta.Services
{
    public class ServiceAPI : IServiceAPI
    {
        private readonly HttpClient _client;
        private static string _baseurl;

        public ServiceAPI() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;

            _client = new HttpClient
            {
                BaseAddress = new Uri(_baseurl)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<Datos_usuarioDTO> AddDatosUsuario(Datos_usuarioDTO datosUsuario, int userID)
        {
            Datos_usuarioDTO? result = null;

            try
            {

                var response = await _client.PostAsJsonAsync($"DatosUsuario/{userID}", datosUsuario);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializar el producto devuelto
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Datos_usuarioDTO>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Console.WriteLine($"Error al añadir la oferta: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }

        public async Task<OfertaDTO> AddOferta(OfertaDTO oferta,int userID, int productoID)
        {
            OfertaDTO? result = null;

            try
            {

                var response = await _client.PostAsJsonAsync($"oferta/{userID}/{productoID}", oferta);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializar el producto devuelto
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<OfertaDTO>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Console.WriteLine($"Error al añadir la oferta: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }

        public async Task<ProductoDTO> AddProducto(ProductoDTO producto, int userID, int subastaID)
        {
            ProductoDTO? result = null;

            try
            {

                var response = await _client.PostAsJsonAsync($"Producto/{userID}/{subastaID}", producto);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializar el producto devuelto
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<ProductoDTO>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Console.WriteLine($"Error al añadir el producto: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            Usuario? result = null;

            try
            {             

                var response = await _client.PostAsJsonAsync($"Usuario", usuario);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializar el producto devuelto
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Usuario>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Console.WriteLine($"Error al añadir el usuario: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }

        public async Task<Producto> CancelarProducto(int userID, int productoID)
        {
            Producto? result = null;
            try
            {

                var response = await _client.PutAsync($"Producto/{userID}/{productoID}", null);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializar el producto devuelto
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Producto>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Console.WriteLine($"Error al cancerlar el prducto: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }        

        public async Task<Datos_usuario> GetDatosUsuario(int userID)
        {
            Datos_usuario? datos = null;

            try
            {
                var response = await _client.GetAsync($"DatosUsuario/{userID}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var subastaResponse = JsonSerializer.Deserialize<Datos_usuario>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return datos;
        }

        public async Task<Oferta> DeleteOferta(int userID, int ofertaID)
        {
            Oferta? result = null;

            try
            {

                var response = await _client.DeleteAsync($"Oferta/{userID}/{ofertaID}");

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializar el producto devuelto
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Oferta>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Console.WriteLine($"Error al añadir el usuario: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }  

        public async Task<Usuario> Deleteusuario(int userID)
        {
            Usuario? result = null;
            try
            {

                var response = await _client.DeleteAsync($"Usuario/{userID}");

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializar el producto devuelto
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Usuario>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Console.WriteLine($"Error al eliminar el usuario: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }

        public async Task<int> GetCantidadOfertas(int productoID)
        {
            int result = 0;
            try
            {
                var response = await _client.GetAsync($"Oferta/{productoID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<int>(jsonResponse, new JsonSerializerOptions
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

        public async Task<Oferta> GetOfertaId(int ofertaID)
        {
            Oferta? result = null;
            try
            {
                var response = await _client.GetAsync($"Oferta/ID/{ofertaID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Oferta>(jsonResponse, new JsonSerializerOptions
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

        public async Task<List<Oferta>> GetOfertasGanadoras(int subastaID)
        {
            List<Oferta>? result = null;
            try
            {
                var response = await _client.GetAsync($"Oferta/Resultados/{subastaID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<Oferta>>(jsonResponse, new JsonSerializerOptions
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

        public async Task<List<Oferta>> GetOfertasUsuario(int userID)
        {
            List<Oferta>? result = null;
            try
            {
                var response = await _client.GetAsync($"Oferta/Usuario/{userID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<Oferta>>(jsonResponse, new JsonSerializerOptions
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

        public async Task<Producto> GetProducto(int productoID)
        {
            Producto? result = null;
            try
            {
                var response = await _client.GetAsync($"Producto/{productoID}");
     if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Producto>(jsonResponse, new JsonSerializerOptions
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

        public async Task<List<Producto>> GetProductoUsuario(int userID)
        {
            List<Producto>? result = null;
            try
            {
                var response = await _client.GetAsync($"Producto/Usuario/{userID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<Producto>>(jsonResponse, new JsonSerializerOptions
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

        public async Task<Subasta?> GetSubasta(int subastaID)
        {
            Subasta? result = null;

            try
            {
                var response = await _client.GetAsync($"Subasta/{subastaID}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }

        public async Task<Subasta?> GetSubastaProductos(int subastaID)
        {
            Subasta? result = null;
            try
            {
                var response = await _client.GetAsync($"Subasta/Productos/{subastaID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions
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

        public async Task<List<Subasta>> GetSubastasFinalizadas()
        {
            List<Subasta>? result = null;

            try
            {
                var response = await _client.GetAsync("Subasta/Finalizadas");
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

        public async Task<List<Subasta>> GetSubastasProximas()
        {
            List<Subasta>? result = null;

            try
            {
                var response = await _client.GetAsync("Subasta/Proximas");
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

        public async Task<Usuario> GetUsuario(int userID)
        {
            Usuario? result = null;
            try
            {
                var response = await _client.GetAsync($"Usuario/{userID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Usuario>(jsonResponse, new JsonSerializerOptions
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

        public async Task<Oferta> UpdateOferta(Oferta oferta,int userID, int ofertaID)
        {
            Oferta? result = null;
            try
            {
                var response = await _client.PutAsJsonAsync($"Oferta/{userID}/{ofertaID}",oferta);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Oferta>(jsonResponse, new JsonSerializerOptions
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

        public async Task<Usuario> UpdateUsuario(Usuario usuario, int userID)
        {
            Usuario? result = null;
            try
            {
                var response = await _client.PutAsJsonAsync($"Usuario/{userID}", usuario);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Usuario>(jsonResponse, new JsonSerializerOptions
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
    }
}
