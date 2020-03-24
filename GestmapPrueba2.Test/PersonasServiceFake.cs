using GestampPrueba2.Infrastructure;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestmapPrueba2.Test
{
   public class PersonasServiceFake: IPersonasService
    {
        private readonly List<Personas3> _personas;
        public PersonasServiceFake()
        {

            _personas = new List<Personas3>()
            {
                new Personas3() {Id = 1, Nombre = "Potato", Apellido = "Casero", Edad = 16},
                new Personas3() {Id = 2, Nombre = "Marcos", Apellido = "Castro", Edad = 80},
                new Personas3() {Id = 3, Nombre = "Alejandro", Apellido = "Hernandez", Edad = 50}
            };
        }

        public IEnumerable<Personas3> GetAllPersonas()
        {
            return _personas;
        }

        public Personas3 PostPersonas3(Personas3 newPersona)
        {
            newPersona.Id = 20;
            _personas.Add(newPersona);
            return newPersona;
        }

        public  Personas3 GetById(int id)
        {
                return _personas.Where(a => a.Id == id)
                    .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _personas.First(a => a.Id == id);
            _personas.Remove(existing);
        }
    }
}
