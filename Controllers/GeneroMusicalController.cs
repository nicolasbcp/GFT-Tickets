using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GFT_Tickets.Data;
using GFT_Tickets.DTO;
using GFT_Tickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFT_Tickets.Controllers
{
    public class GeneroMusicalController : Controller
    {
        private readonly ApplicationDbContext database;

        IHostingEnvironment _env;
        public GeneroMusicalController(ApplicationDbContext database, IHostingEnvironment environment) {
            this.database = database;
            _env = environment;
        }
        
        public IActionResult GeneroMusical()
        {
            var generomusical = database.GenerosMusicais.ToList();
            return View(generomusical);
        }

        public IActionResult Cadastrar() {
            return View();
        }

        private async Task<string> ImageUpload(IFormFile file) {
            if(file != null && file.Length > 0) {
                var imagePath = @"\Upload\Images\";
                var uploadPath = _env.WebRootPath + imagePath;

                // Cria diretório
                if(!Directory.Exists(uploadPath)) {
                    Directory.CreateDirectory(uploadPath);
                }

                // Cria nome do arquivo
                var uniqFileName = Guid.NewGuid().ToString();
                var fileName = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + fileName;

                imagePath = imagePath + @"\";
                var filePath = @".." + Path.Combine(imagePath, fileName);

                using (var fileStream = new FileStream(fullPath, FileMode.Create)) {
                    await file.CopyToAsync(fileStream);
                }

                return filePath;
            } 
            return string.Empty;
        }

        public IActionResult Editar(int id) {
            var generomusical = database.GenerosMusicais.First(generomusical => generomusical.Id == id);
            GeneroMusicalDTO generomusicalView = new GeneroMusicalDTO();
            generomusicalView.Id = generomusical.Id;
            generomusicalView.Nome = generomusical.Nome;
            return View(generomusicalView); 
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(GeneroMusicalDTO generomusicalTemp) {
            if(ModelState.IsValid) {
                GeneroMusical generomusical = new GeneroMusical();
                generomusical.Imagem = await ImageUpload(generomusicalTemp.Imagem);
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