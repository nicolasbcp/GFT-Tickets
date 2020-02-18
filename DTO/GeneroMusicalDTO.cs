using System.ComponentModel.DataAnnotations;
using GFT_Tickets.Models;
using Microsoft.AspNetCore.Http;

namespace GFT_Tickets.DTO
{
    public class GeneroMusicalDTO
    {
        [Required]
        public int Id {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        [StringLength(100, ErrorMessage="Limite de caracteres: 100.")]
        [MinLength(3, ErrorMessage="Mínimo de caracteres: 3.")]
        public string Nome {get; set;}
        public IFormFile Imagem {get; set;}
    }
}