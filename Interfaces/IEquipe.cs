using System.Collections.Generic;
using EPlayersBackend.Models;

namespace EPlayersBackend.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);

         List<Equipe> ReadAll();

         void Update(Equipe e);
         
         void Delete(int IdEquipe);
    }
}