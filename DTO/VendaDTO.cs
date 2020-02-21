using System;
using System.ComponentModel.DataAnnotations;
using GFT_Tickets.Models;

namespace GFT_Tickets.DTO
{
    public class VendaDTO
    {
        [Required]
        public int Id {get; set;}

        public int EventoID {get; set;}

        public int QuantidadeTicket {get; set;}

        public float TotalVenda {get; set;}

        public DateTime DataVenda {get; set;}
    }
}