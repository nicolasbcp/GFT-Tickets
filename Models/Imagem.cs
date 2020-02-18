using System.ComponentModel.DataAnnotations.Schema;

namespace GFT_Tickets.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Caminho { get; set; }
        public int GeneroMusicalID { get; set; }
        [ForeignKey("GeneroMusicalID")]
        public virtual GeneroMusical GeneroMusical { get; set; }
    }
}