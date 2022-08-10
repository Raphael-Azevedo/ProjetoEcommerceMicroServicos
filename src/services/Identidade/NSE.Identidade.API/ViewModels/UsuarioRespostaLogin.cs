using System.Collections.Generic;

namespace NSE.Identidade.API.ViewModels
{
    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; } 
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }
}