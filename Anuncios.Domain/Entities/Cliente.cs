namespace Anuncios.Domain.Entities
{
    public class Cliente : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}