using System;
using System.ComponentModel.DataAnnotations;
using GFT_Tickets.Models;

namespace GFT_Tickets.DTO
{
    public class VendaDTO
    {
        [Required]
        public int Id {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public Usuario Usuario {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public int EventoID {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public int QuantidadeTicket {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public float TotalVenda {get; set;}
        [Required(ErrorMessage="Este campo é obrigatório.")]
        public DateTime DataVenda {get; set;}
    }
}