using System.Linq;
using GFT_Tickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GFT_Tickets.DTO;
using GFT_Tickets.Models;
using System;
using Microsoft.AspNetCore.Authorization;

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
                Evento = evento,
                EventoID = id
            };
            return View(venda);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Comprar(Venda vendaTemp) {
            if(ModelState.IsValid) {
                Venda venda = new Venda();
                venda.Evento = database.Eventos.FirstOrDefault(evento => evento.Id == vendaTemp.EventoID);
                venda.QuantidadeTicket = vendaTemp.QuantidadeTicket;
                venda.DataVenda = DateTime.Now;
                database.Vendas.Add(venda);
                database.SaveChanges();
                return RedirectToAction("Historico", "Vendas");
            } else {
                return View("../Eventos/Eventos");
            }
        }

        [Authorize]
        public IActionResult Historico() {
            var historico = database.Vendas.Include(historico => historico.Evento).ToList();
            return View(historico);
        }
    }
}