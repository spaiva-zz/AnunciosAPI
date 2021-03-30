using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anuncios.Application.DTO
{
    public class AnuncioDTO : BaseDTO
    {
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [NotMapped]
        public string ImagemBase64 { get; set; }
        public Int64 CountExibicao { get; set; }
    }
}