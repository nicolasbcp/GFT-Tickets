using System.Linq;
using GFT_Tickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GFT_Tickets.DTO;
using GFT_Tickets.Models;

namespace GFT_Tickets.Controllers
{
    public class VendasController : Controller
    {
        private readonly ApplicationDbContext database;

        public VendasController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Vendas(int id)
        {
            var evento = database.Eventos.FirstOrDefault(e => e.Id == id);

            var venda = new Venda() {
                Evento = evento
            };
            return View(venda);
        }

        public IActionResult Historico() {
            var historico = database.Vendas.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Comprar(VendaDTO vendaTemp) {
            if(ModelState.IsValid) {
                Venda venda = new Venda();
                venda.Evento = database.Eventos.First(evento => evento.Id == vendaTemp.EventoID);
                venda.QuantidadeTicket = vendaTemp.QuantidadeTicket;
                database.Vendas.Add(venda);
                database.SaveChanges();
                return RedirectToAction("Vendas", "Historico");
            } else {
                return View("../Eventos/Eventos");
            }
        }
    }
}