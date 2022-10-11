namespace API.Models
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
    }
}