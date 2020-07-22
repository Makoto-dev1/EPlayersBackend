using System;
using Microsoft.AspNetCore.Mvc;
using EPlayersBackend.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EPlayersBackend.Controllers
{
    public class NoticiasController : Controller
    {

        Noticias noticiaModel = new Noticias();

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }
         public IActionResult Cadastrar(IFormCollection form)
        {   
            Noticias noticia = new Noticias();
            noticia.IdNoticia = Int32.Parse( form["IdNoticia"] );
            noticia.Titulo   = form["Titulo"];   
            noticia.Texto = form["Texto"];
            //Upload da imagem
            
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                noticia.Imagem   = file.FileName;
            }
            else
            {
                noticia.Imagem   = "padrao.png";
            }
            //Fim do upload
            noticiaModel.Create(noticia);

            //Redirecionamento
            return LocalRedirect("~/Noticias");
        }

        [Route("[controller]/{id}")]
        public IActionResult excluir(int id)
        {
            noticiaModel.Delete(id);
            return LocalRedirect("~/Noticias");
        }
    }
}