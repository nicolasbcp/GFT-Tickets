using System;

namespace GFT_Tickets.Models
{
    public class Evento
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public int Capacidade {get; set;}
        public DateTime Data {get; set;}
        public float ValorUnitario {get; set;}
        public CasaDeShow CasaDeShow {get; set;}
        public GeneroMusical GeneroMusical {get; set;}
        
    }
}