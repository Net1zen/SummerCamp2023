using AutoMapper;
using DTOs;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Repositorios;

namespace Backend.Controllers
{

    [Route("api/Personas")] //Que no cambie nunca


    //+2-Indicar que es controlador API
    [ApiController]
    public class PersonasController: ControllerBase
    {

        private readonly IRepositorioPersonas _repositorioPersonas;
        private readonly IMapper _mapper;

        public PersonasController( IRepositorioPersonas repositorioPersonas,
            IMapper mapper)
        {
            
            _repositorioPersonas = repositorioPersonas; 
            _mapper = mapper;
        }


        //api/Personas
        [HttpPost]
        public async Task<ActionResult<PersonaDTO>> crearPersona(
            PersonaCreacionDTO persona)
        {

            var personaEntidad = _mapper.Map<Persona>(persona);

            bool fail = await _repositorioPersonas.AltaPersonaAsync(personaEntidad);

            if (fail) return BadRequest("The object already exists.");

            var personaToReturn = _mapper.Map<PersonaDTO>(personaEntidad);
            await _repositorioPersonas.SaveAsync();

            return personaToReturn;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetPaises()
        {
            var lista = await _repositorioPersonas.Obtener10PersonasCondicionAsync();
            var listaDTO = new List<PersonaDTO>();

            foreach (var persona in lista)
            {
                listaDTO.Add(_mapper.Map<PersonaDTO>(persona));
            }

            return Ok(listaDTO);
        }

    }
}
