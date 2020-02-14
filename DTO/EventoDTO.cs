using System;
using System.ComponentModel.DataAnnotations;
using GFT_Tickets.Models;

namespace GFT_Tickets.DTO
{
    public class EventoDTO
    {
        [Required]
        public int Id {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        [StringLength(100, ErrorMessage="Limite de caracteres: 100.")]
        [MinLength(5, ErrorMessage="Mínimo de caracteres: 5.")]
        public string Nome {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public int Capacidade {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public DateTime Data {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public float ValorUnitario {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public CasaDeShow CasaDeShow {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public GeneroMusical GeneroMusical {get; set;}
    }
}