using AutoMapper;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Models.DTOs
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
          CreateMap<Usuarios2, Usuarios2>();
           CreateMap<Usuarios2, Usuarios2>();
        }
    }
}