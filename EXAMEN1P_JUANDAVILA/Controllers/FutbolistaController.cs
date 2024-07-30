using EXAMEN1P_JUANDAVILA.COMUNES;
using EXAMEN1P_JUANDAVILA.MODELOS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXAMEN1P_JUANDAVILA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolistasController : ControllerBase
    {
        // GET: api/<FutbolistaController>
        [HttpGet]
        public List<Futbolista> Get()
        {
            return ConexionBD.GetFutbolista();
        }

        //// GET api/<FutbolistaController>/5
        //[HttpGet("{id_futbolista}")]
        //public Futbolista Get(int id_futbolista)
        //{
        //    return ConexionBD.GetFutbolistas(id_futbolista);
        //}

        [HttpGet("{id_futbolistaHistorial}")]
        public List<HistoricoEquipos> GetHistoricoEquipos(int id_futbolistaHistorial)
        {
            return ConexionBD.GetHistorico_Equipos(id_futbolistaHistorial);
        }

        // POST api/<FutbolistaController>
        [HttpPost]
        public void Post([FromBody] Futbolista objFutbolista)
        {
            ConexionBD.PostFutbolista(objFutbolista);
        }

        // PUT api/<FutbolistaController>/5
        [HttpPut("{id_futbolista}")]
        public void Put(int id_futbolista, [FromBody] Futbolista objFutbolista)
        {
            ConexionBD.PutFutbolista(id_futbolista, objFutbolista);
        }

        // DELETE api/<FutbolistaController>/5
        [HttpDelete("{id_futbolista}")]
        public void Delete(int id_futbolista)
        {
            ConexionBD.DeleteFutbolista(id_futbolista);
        }
    }
}
