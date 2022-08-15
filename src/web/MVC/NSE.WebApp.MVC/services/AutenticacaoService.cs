using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NSE.WebApp.MVC.ViewModels;

namespace NSE.WebApp.MVC.services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpCliente;

        public AutenticacaoService(HttpClient httpCliente)
        {
            _httpCliente = httpCliente;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(usuarioLogin),
                Encoding.UTF8,
                "Application/json"
            );
            var response = await _httpCliente.PostAsync("https://localhost:5001/api/identidade/autenticar", loginContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(
                JsonSerializer.Serialize(usuarioRegistro),
                Encoding.UTF8,
                "Application/json"
            );
            var response = await _httpCliente.PostAsync("https://localhost:5001/api/identidade/registrar", registroContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}