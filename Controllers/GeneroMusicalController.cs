using System.Linq;
using GFT_Tickets.Data;
using GFT_Tickets.DTO;
using GFT_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace GFT_Tickets.Controllers
{
    public class GeneroMusicalController : Controller
    {
        private readonly ApplicationDbContext database;

        public GeneroMusicalController(ApplicationDbContext database) {
            this.database = database;
        }
        
        public IActionResult GeneroMusical()
        {
            var generomusical = database.GenerosMusicais.ToList();
            return View(generomusical);
        }

        public IActionResult Cadastrar() {
            return View();
        }

        public IActionResult Editar(int id) {
            var generomusical = database.GenerosMusicais.First(generomusical => generomusical.Id == id);
            GeneroMusicalDTO generomusicalView = new GeneroMusicalDTO();
            generomusicalView.Id = generomusical.Id;
            generomusicalView.Nome = generomusical.Nome;
            return View(generomusicalView); 
        }

        [HttpPost]
        public IActionResult Salvar(GeneroMusicalDTO generomusicalTemp) {
            if(ModelState.IsValid) {
                GeneroMusical generomusical = new GeneroMusical();
                generomusical.Nome = generomusicalTemp.Nome;
                database.GenerosMusicais.Add(generomusical);
                database.SaveChanges();
                return RedirectToAction("GeneroMusical", "GeneroMusical");
            } else {
                return View("../GeneroMusical/GeneroMusical");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(GeneroMusicalDTO generomusicalTemp) {
            if(ModelState.IsValid) {
                var generomusical = database.GenerosMusicais.First(generomusical => generomusical.Id == generomusicalTemp.Id);
                generomusical.Nome = generomusicalTemp.Nome;
                database.SaveChanges();
                return RedirectToAction("GeneroMusical", "GeneroMusical");
            } else {
                return View("../GeneroMusical/Editar");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id) {
                var generomusical = database.GenerosMusicais.First(generomusical => generomusical.Id == id);
                database.GenerosMusicais.Remove(generomusical);
                database.SaveChanges();
                return RedirectToAction("GeneroMusical", "GeneroMusical");
        }
    }    
}