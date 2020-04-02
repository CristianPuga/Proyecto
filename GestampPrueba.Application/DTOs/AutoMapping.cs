using AutoMapper;
using GestampPrueba2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestampPrueba.Application.DTOs
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Usuarios2, UsuariosDetailsDTO>().ReverseMap();
            CreateMap<UsuariosEditDTO, Usuarios2>().AfterMap((src,dest) => dest.Activo = true);
            CreateMap<Usuarios2, UsuariosDTO>().ReverseMap();
            CreateMap<UsuariosPostDTO, Usuarios2>().ReverseMap();
            CreateMap<UsuariosActivoDTO, Usuarios2>().AfterMap((src, dest) => dest.NombreUsuario = "Hola").AfterMap((src, dest) => dest.Contrasena = "Hola").AfterMap((src, dest) => dest.Email = "Hola").AfterMap((src, dest) => dest.Img = "Hola");
            CreateMap<Personas3, PersonasDetailsDTO>().ReverseMap();
            CreateMap<Personas3, PersonasDTO>().ReverseMap();
        }
    }
}