using GestampPrueba.Application.DTOs;
using GestampPrueba2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestampPrueba.Application
{
    public interface IUsuariosService
    {
        IEnumerable<UsuariosDTO> GetAll();
        void Insert(UsuariosPostDTO newUsuario);
        UsuariosDetailsDTO GetById(int id);
        void Delete(int id);
        void Update(UsuariosEditDTO modUsuario);
        void UpdateActivo(UsuariosActivoDTO modActivo);
        void MetodoChorra();
        bool UsuariosExist(int id);
    }
}
