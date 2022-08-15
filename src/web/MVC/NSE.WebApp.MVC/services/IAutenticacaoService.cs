using System.Threading.Tasks;
using NSE.WebApp.MVC.ViewModels;

namespace NSE.WebApp.MVC.services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuario);
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}