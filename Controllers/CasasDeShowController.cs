using System;
using GFT_Tickets.Data;
using Microsoft.AspNetCore.Mvc;
using GFT_Tickets.DTO;
using GFT_Tickets.Models;
using System.Linq;

namespace GFT_Tickets.Controllers
{
    public class CasasDeShowController : Controller
    {
        private readonly ApplicationDbContext database;

        public CasasDeShowController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Cadastrar() {
            return View();
        }

        public IActionResult CasasDeShow()
        {
            var casasdeshow = database.CasasDeShow.ToList();
            return View(casasdeshow);
        }

        [HttpPost]
        public IActionResult Salvar(CasaDeShowDTO casaTemp) {
            if(ModelState.IsValid) {
                CasaDeShow casadeshow = new CasaDeShow();
                casadeshow.Nome = casaTemp.Nome;
                casadeshow.Endereco = casaTemp.Endereco;
                database.CasasDeShow.Add(casadeshow);
                database.SaveChanges();
                return View(nameof(CasasDeShow));
            } else {
                return View("../CasasDeShow/Cadastrar");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(CasaDeShowDTO casaTemp) {
            if(ModelState.IsValid) {
                var casadeshow = database.CasasDeShow.First(casadeshow => casadeshow.Id == casaTemp.Id);
                casadeshow.Nome = casaTemp.Nome;
                casadeshow.Endereco = casaTemp.Endereco;
                database.SaveChanges();
                return View(nameof(CasasDeShow));
            } else {
                return View("../CasasDeShow/Editar");
            }
        }

        [HttpPost]
        public IActionResult Deletar(CasaDeShowDTO casaTemp) {
            var casadeshow = database.CasasDeShow.First(casadeshow => casadeshow.Id == casaTemp.Id);
            database.CasasDeShow.Remove(casadeshow);
            database.SaveChanges();
            return View(nameof(CasasDeShow));
        }
    }
}