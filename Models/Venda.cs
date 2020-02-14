using System;

namespace GFT_Tickets.Models
{
    public class Venda
    {
        public int Id {get; set;}
        public Usuario Usuario {get; set;}
        public Evento Evento {get; set;}
        public int QuantidadeTicket {get; set;}
        public float TotalVenda {get; set;}
        public DateTime DataVenda {get; set;}
    }
}