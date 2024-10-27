using Core.Entities;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;


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

        public async Task<Datos_usuario> AddDatosUsuario(Datos_usuario datosUsuario, int userID)
        {
            Datos_usuario result = null;

            try
            {

                var response = await _client.PostAsJsonAsync($"DatosUsuario/{userID}", datosUsuario);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializar el producto devuelto
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Datos_usuario>(jsonResponse, new JsonSerializerOptions
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

        public async Task<Oferta> AddOferta(Oferta oferta,int userID, int productoID)
        {
            Oferta result = null;

            try
            {

                var response = await _client.PostAsJsonAsync($"Producto/{userID}/{productoID}", oferta);

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

        public async Task<Producto> AddProducto(Producto producto, int userID, int subastaID)
        {
            Producto result = null;

            try
            {

                var response = await _client.PostAsJsonAsync($"Producto/{userID}/{subastaID}", producto);

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
            Usuario result = null;

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
            Producto result = null;
            /*try
            {

                var response = await _client.PutAsync($"Producto/{userID}/{productoID}", null);

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
            }*/

            return result;
        }

        public async Task<Producto> DatosProducto(int productoID)
        {
            throw new NotImplementedException();
        }

        public async Task<Datos_usuario> DatosUsuario(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task<Oferta> DeleteOferta(int userID, int ofertaID)
        {
            throw new NotImplementedException();
        }  

        public async Task<Usuario> Deleteusuario(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCantidadOfertas(int productoID)
        {
            throw new NotImplementedException();
        }

        public async Task<Oferta> GetOfertaId(int ofertaID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Oferta>> GetOfertasGanadoras(int subastaID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Oferta>> GetOfertasUsuario(int usuarioID)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> GetProducto(int productoID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> GetProductoUsuario(int userID)
        {
            List<Producto> productos = null;
            try
            {
                var response = await _client.GetAsync($"Producto/Usuario/{userID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    productos = JsonSerializer.Deserialize<List<Producto>>(jsonResponse, new JsonSerializerOptions
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

            return productos;
        }

        public async Task<Subasta?> GetSubasta(int subastaID)
        {
            Subasta subasta = null;

            try
            {
                var response = await _client.GetAsync($"Subasta/{subastaID}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var subastaResponse = JsonSerializer.Deserialize<Subasta>(jsonResponse, new JsonSerializerOptions
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


            return subasta;
        }

        public async Task<Subasta?> GetSubastaProductos(int subastaID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subasta>> GetSubastasActivas()
        {
            List<Subasta> subasta = null;

            try
            {
                var response = await _client.GetAsync("Subasta/Activas");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    subasta = JsonSerializer.Deserialize<List<Subasta>>(jsonResponse, new JsonSerializerOptions
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

            return subasta;

        }

        public async Task<List<Subasta>> GetSubastasFinalizadas()
        {
            List<Subasta> subasta = null;

            try
            {
                var response = await _client.GetAsync("Subasta/Finalizadas");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    subasta = JsonSerializer.Deserialize<List<Subasta>>(jsonResponse, new JsonSerializerOptions
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

            return subasta;
        }

        public async Task<List<Subasta>> GetSubastasProximas()
        {
            List<Subasta> subasta = null;

            try
            {
                var response = await _client.GetAsync("Subasta/Proximas");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    subasta = JsonSerializer.Deserialize<List<Subasta>>(jsonResponse, new JsonSerializerOptions
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

            return subasta;
        }

        public async Task<Usuario> GetUsuario(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task<Oferta> UpdateOferta(Oferta oferta,int userID, int ofertaID)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario, int userID)
        {
            throw new NotImplementedException();
        }
    }
}
