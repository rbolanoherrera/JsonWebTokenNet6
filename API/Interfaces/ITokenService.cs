using API.Models;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string GenerarToken(Usuario usuario);
    }
}