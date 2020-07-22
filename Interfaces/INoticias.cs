using System.Collections.Generic;
using EPlayersBackend.Models;
namespace EPlayersBackend.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias n);

         List<Noticias> ReadAll();

         void Update(Noticias n);
         
         void Delete(int IdNoticia);
    }
}