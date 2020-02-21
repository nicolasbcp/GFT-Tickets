using System;
using GFT_Tickets.Data;
using Microsoft.AspNetCore.Mvc;
using GFT_Tickets.DTO;
using GFT_Tickets.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GFT_Tickets.Controllers
{
    [Authorize(Policy="AdminGFT")]
    public class CasasDeShowController : Controller
    {
        private readonly ApplicationDbContext database;

        public CasasDeShowController(ApplicationDbContext database) {
            this.database = database;
        }
        
        public IActionResult CasasDeShow()
        {
            var casasdeshow = database.CasasDeShow.ToList();
            return View(casasdeshow);
        }

        public IActionResult Cadastrar() {
            return View();
        }

        public IActionResult Editar(int id) {
            var casadeshow = database.CasasDeShow.First(casadeshow => casadeshow.Id == id);
            CasaDeShowDTO casadeshowView = new CasaDeShowDTO();
            casadeshowView.Id = casadeshow.Id;
            casadeshowView.Nome = casadeshow.Nome;
            casadeshowView.Endereco = casadeshow.Endereco;
            return View(casadeshowView); 
        }

        [HttpPost]
        public IActionResult Salvar(CasaDeShowDTO casaTemp) {
            if(ModelState.IsValid) {
                CasaDeShow casadeshow = new CasaDeShow();
                casadeshow.Nome = casaTemp.Nome;
                casadeshow.Endereco = casaTemp.Endereco;
                database.CasasDeShow.Add(casadeshow);
                database.SaveChanges();
                return RedirectToAction("CasasDeShow", "CasasDeShow");
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
                return RedirectToAction("CasasDeShow", "CasasDeShow");
            } else {
                return View("../CasasDeShow/Editar");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id) {
                var casadeshow = database.CasasDeShow.First(casadeshow => casadeshow.Id == id);
                database.CasasDeShow.Remove(casadeshow);
                database.SaveChanges();
                return RedirectToAction("CasasDeShow", "CasasDeShow");
        }
    }
}