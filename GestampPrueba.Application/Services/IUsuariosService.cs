using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application
{
    public interface IUsuariosService
    {
        IEnumerable<Usuarios2> GetAll();
        void Insert(Usuarios2 newUsuario);
        Usuarios2 GetById(int id);
        void Delete(int id);
        void Update(Usuarios2 modUsuario);
        void metodoChorra();
    }
}
