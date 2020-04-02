using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestampPrueba.Application
{
    public interface IUsuariosRepository: IDisposable
    {
        bool UsuariosExist(int id);
        void metodoChorra();
        void Save();
    }
}
