using AutoMapper;
using DTOs;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfiles
{
    public class PersonaPerfil: Profile
    {
        public PersonaPerfil()
        {
            CreateMap<PersonaDTO, Persona>().ReverseMap();
            CreateMap<PersonaCreacionDTO, Persona>().ReverseMap();

        }

    }

}
