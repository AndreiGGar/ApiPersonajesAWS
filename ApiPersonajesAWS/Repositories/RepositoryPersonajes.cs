using ApiPersonajesAWS.Context;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
{
    public class RepositoryPersonajes
    {
        private DataContext context;

        public RepositoryPersonajes(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        /*private int GetMaxIdPersonaje()
        {
            return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
        }*/

        /*public async Task CreatePersonaje(string nombre, string imagen)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonaje();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }*/

        public async Task CreatePersonajeAsync(string nombre, string imagen)
        {
            var query = $"CALL SP_INSERT_PERSONAJE('{nombre}', '{imagen}')";
            await this.context.Database.ExecuteSqlRawAsync(query);

            /*Personaje personaje = new Personaje();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();*/
        }

        public async Task UpdatePersonajeAsync(int id, string nombre, string imagen)
        {
            var query = $"CALL SP_UPDATE_PERSONAJE({id}, '{nombre}', '{imagen}')";
            await this.context.Database.ExecuteSqlRawAsync(query);

            /*Personaje personaje = await FindPersonajeAsync(id);
            if (personaje != null)
            {
                personaje.IdPersonaje = id;
                personaje.Nombre = nombre;
                personaje.Imagen = imagen;
                await this.context.SaveChangesAsync();
            }*/
        }

        public async Task DeletePersonajeAsync(int id)
        {
            var query = $"CALL SP_DELETE_PERSONAJE({id})";
            await this.context.Database.ExecuteSqlRawAsync(query);

            /*Personaje personaje = await this.context.Personajes.FindAsync(id);
            if (personaje != null)
            {
                this.context.Personajes.Remove(personaje);
                await this.context.SaveChangesAsync();
            }*/
        }
    }
}
