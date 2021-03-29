namespace Anuncios.Domain.Entities
{
    public class Anuncio : Base
    {
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
    }
}