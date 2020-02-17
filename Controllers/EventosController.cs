using System.Linq;
using GFT_Tickets.Data;
using GFT_Tickets.DTO;
using GFT_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GFT_Tickets.Controllers
{
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext database;

        public EventosController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Eventos()
        {
            var eventos = database.Eventos.Include(eventos => eventos.CasaDeShow).Include(eventos => eventos.GeneroMusical).ToList();
            return View(eventos);
        }

        public IActionResult Cadastrar() {
            ViewBag.CasasDeShow = database.CasasDeShow.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome }).ToList();
            ViewBag.GeneroMusical = database.GenerosMusicais.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome }).ToList();
            return View();
        }

        public IActionResult Editar(int id) {
            var evento = database.Eventos.Include(evento => evento.CasaDeShow).Include(eventos => eventos.GeneroMusical).First(evento => evento.Id == id);
            EventoDTO eventoView = new EventoDTO();
            eventoView.Id = evento.Id;
            eventoView.Nome = evento.Nome;
            eventoView.Capacidade = evento.Capacidade;
            eventoView.Data = evento.Data;
            eventoView.ValorUnitario = evento.ValorUnitario;
            eventoView.CasaDeShowID = evento.CasaDeShowID;
            eventoView.GeneroMusicalID = evento.GeneroMusicalID;
            ViewBag.CasasDeShow = database.CasasDeShow.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome }).ToList();
            ViewBag.GeneroMusical = database.GenerosMusicais.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome }).ToList();
            return View(eventoView); 
        }

        [HttpPost]
        public IActionResult Salvar(EventoDTO eventoTemp) {
            if(ModelState.IsValid) {
                Evento evento = new Evento();
                evento.Nome = eventoTemp.Nome;
                evento.Capacidade = eventoTemp.Capacidade;
                evento.Data = eventoTemp.Data;
                evento.ValorUnitario = eventoTemp.ValorUnitario;
                evento.CasaDeShow = database.CasasDeShow.First(casadeshow => casadeshow.Id == eventoTemp.CasaDeShowID);
                evento.GeneroMusical = database.GenerosMusicais.First(generomusical => generomusical.Id == eventoTemp.GeneroMusicalID);
                database.Eventos.Add(evento);
                database.SaveChanges();
                return RedirectToAction("Eventos", "Eventos");
            } else {
                ViewBag.CasasDeShow = database.CasasDeShow.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome }).ToList();
                ViewBag.GeneroMusical = database.GenerosMusicais.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome }).ToList();
                return View("../Eventos/Cadastrar");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(EventoDTO eventoTemp) {
            if(ModelState.IsValid) {
                var evento = database.Eventos.Include(evento => evento.CasaDeShow).Include(evento => evento.GeneroMusical).First(evento => evento.Id == eventoTemp.Id);
                evento.Nome = eventoTemp.Nome;
                evento.Capacidade = eventoTemp.Capacidade;
                evento.Data = eventoTemp.Data;
                evento.ValorUnitario = eventoTemp.ValorUnitario;
                evento.CasaDeShow = database.CasasDeShow.First(casadeshow => casadeshow.Id == eventoTemp.CasaDeShowID);
                evento.GeneroMusical = database.GenerosMusicais.First(generomusical => generomusical.Id == eventoTemp.GeneroMusicalID);
                database.SaveChanges();
                return RedirectToAction("Eventos", "Eventos");
            } else {
                ViewBag.CasasDeShow = database.CasasDeShow.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome }).ToList();
                ViewBag.GeneroMusical = database.GenerosMusicais.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nome }).ToList();
                return View("../Eventos/Editar");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id) {
                var evento = database.Eventos.First(evento => evento.Id == id);
                database.Eventos.Remove(evento);
                database.SaveChanges();
                return RedirectToAction("Eventos", "Eventos");
        }
    }
}