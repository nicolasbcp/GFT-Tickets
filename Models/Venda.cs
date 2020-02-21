using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GFT_Tickets.Models
{
    public class Venda
    {
        public int Id {get; set;}
        [ForeignKey("EventoID")]
        public Evento Evento {get; set;}
        public int EventoID {get; set;}
        public int QuantidadeTicket {get; set;}
        public float TotalVenda {get {
            return QuantidadeTicket * Evento.ValorUnitario;
        }}
        public DateTime DataVenda {get; set;}
    }
}