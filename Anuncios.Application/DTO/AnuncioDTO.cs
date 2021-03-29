using System;

namespace Anuncios.Application.DTO
{
    public class AnuncioDTO : BaseDTO
    {
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public Int64 CountExibicao { get; set; }
    }
}