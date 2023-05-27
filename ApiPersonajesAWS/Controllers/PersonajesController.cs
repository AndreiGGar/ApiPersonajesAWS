using ApiPersonajesAWS.Models;
using ApiPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        [Route("create/{nombre}/{imagen}")]
        public async Task<ActionResult> CreatePersonaje(string nombre, string imagen)
        {
            await this.repo.CreatePersonajeAsync(nombre, imagen);
            return Ok();
        }

        [HttpPut]
        [Route("update/{id}/{nombre}/{imagen}")]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonajeAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        }
    }
}
