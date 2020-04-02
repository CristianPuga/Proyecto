using AutoMapper;
using GestampPrueba.Application.DTOs;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestmapPrueba2.Test
{
    public static class Setup
    {
        public static IMapper MapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuarios2, UsuariosDTO>().ReverseMap();
                cfg.CreateMap<Usuarios2, UsuariosDetailsDTO>().ReverseMap();
                cfg.CreateMap<Usuarios2, UsuariosEditDTO>().ReverseMap();
                cfg.CreateMap<Usuarios2, UsuariosPostDTO>().ReverseMap();
                cfg.CreateMap<Usuarios2, UsuariosEditDTO>().ReverseMap();
                cfg.CreateMap<Usuarios2, UsuariosPostDTO>().ReverseMap();
                cfg.CreateMap<Personas3, PersonasDTO>().ReverseMap();
                cfg.CreateMap<Personas3, PersonasDetailsDTO>().ReverseMap();
            });
            return config.CreateMapper();
        }
    }
}
