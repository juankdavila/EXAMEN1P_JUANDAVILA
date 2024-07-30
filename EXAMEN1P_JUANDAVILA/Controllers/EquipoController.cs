using EXAMEN1P_JUANDAVILA.COMUNES;
using EXAMEN1P_JUANDAVILA.MODELOS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXAMEN1P_JUANDAVILA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        // GET: api/<EquiposController>
        [HttpGet]
        public List<Equipo> Get()
        {
            return ConexionBD.GetEquipos();
        }

        // GET api/<EquiposController>/5
        [HttpGet("{id_equipo}")]
        public Equipo Get(int id_equipo)
        {
            return ConexionBD.GetEquipo(id_equipo);
        }

        // POST api/<EquiposController>
        [HttpPost]
        public void Post([FromBody] Equipo objEquipo)
        {
            ConexionBD.PostEquipo(objEquipo);
        }

        // PUT api/<EquiposController>/5
        [HttpPut("{id_equipo}")]
        public void Put(int id_equipo, [FromBody] Equipo objequipo)
        {
            ConexionBD.PutEquipo(id_equipo, objequipo);
        }

        // DELETE api/<EquiposController>/5
        [HttpDelete("{id_equipo}")]
        public void Delete(int id_equipo)
        {
            ConexionBD.DeleteEquipo(id_equipo);
        }
    }
}
