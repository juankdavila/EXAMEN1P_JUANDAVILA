using EXAMEN1P_JUANDAVILA.COMUNES;
using EXAMEN1P_JUANDAVILA.MODELOS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXAMEN1P_JUANDAVILA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolistaController : ControllerBase
    {
        // GET: api/<FutbolistaController>
        [HttpGet]
        public List<Futbolista> Get()
        {
            return ConexionBD.GetFubolista();
        }

        //// GET api/<FutbolistaController>/5
        //[HttpGet("{id_futbolista}")]
        //public Futbolista Get(int id_futbolista)
        //{
        //    return ConexionBD.GetFutbolistas(id_futbolista);
        //}

        [HttpGet("Futbolista/{id_futbolista}/Historico")]
        public List<HistoricoEquipos> GetHistorico_Equipos(int id_futbolista)
        {
            return ConexionBD.GetHistorico_Equipos(id_futbolista);
        }

        // POST api/<EController>
        [HttpPost]
        public void Post([FromBody] Futbolista objfutbolista)
        {
            ConexionBD.PostFutbolista(objfutbolista);
        }

        // PUT api/<FutbolistaController>/5
        [HttpPut("{id_futbolista}")]
        public void Put(int id_futbolista, [FromBody] Futbolista objfutbolista)
        {
            ConexionBD.PutFutbolista(id_futbolista, objfutbolista);
        }

        // DELETE api/<FutbolistaController>/5
        [HttpDelete("{id_futbolista}")]
        public void Delete(int id_futbolista)
        {
            ConexionBD.DeleteFutbolista(id_futbolista);
        }
    }
}
