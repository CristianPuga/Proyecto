﻿using GestampPrueba2.Infrastructure;
using GestampPrueba2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestmapPrueba2.Test
{
   public class PersonasServiceFake: ControllerBase, IPersonasRepository
    {
        private readonly IEnumerable<Personas3> _personas;

        public PersonasServiceFake()
        {

            _personas = new List<Personas3>()
            {
                new Personas3() {Id = 1, Nombre = "Potato", Apellido = "Casero", Edad = 16},
                new Personas3() {Id = 2, Nombre = "Marcos", Apellido = "Castro", Edad = 80},
                new Personas3() {Id = 3, Nombre = "Alejandro", Apellido = "Hernandez", Edad = 50}
            };
        }

        public Task<IEnumerable<Personas3>> GetAllPersonas()
        {
            return  Task.FromResult(_personas);
            //return await _personas.ToList();
            //return null;
        }
        
        public Task<ActionResult<Personas3>> PostPersonas3(Personas3 newPersona)
        {
            //newPersona.Id = 78;
             _personas.Append(newPersona);
            //return Task.CompletedTask();
            //return CreatedAtAction("GetPersonas3", new { id = personas3.Id }, personas3);
            return null;
        }

        public Task<ActionResult<Personas3>> PutPersonas3(int id, Personas3 newPersona)
        {
            /*newPersona.Id = 78;
             _personas.Add(newPersona);
             return newPersona;*/
            return null;
        }

        public async Task<ActionResult<Personas3>> GetById(int id)
        {

            var personas3 = _personas.Where(a => a.Id == id);

            if (personas3 == null)
            {
                return NotFound();
            }

            return Ok(personas3);
            //return _personas.Where(a => a.Id == id)
            //    .FirstOrDefault();
            //return null;
        }

        public async Task<ActionResult<Personas3>> DeletePersona(int id)
        {

            var personas3 =  _personas.First(a=> a.Id == id);
            var existing = _personas.ToList();
             if (personas3 == null)
             {
                 return NotFound();
             }
            existing.Remove(personas3);
            _personas.Append(personas3);
            //return Task.FromResult(personas3);
            return null;
        }
    }
}
