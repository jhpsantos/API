using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patrimonio.Business.Interface;
using Patrimonio.Entities;

namespace Patrimonios.API.Controllers
{
    ///Lacrando os serviços para exigir a autenticação no IdentityServer;
    [Authorize]
    [Route("api/marcas")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        IMarcaBusiness marcaBusiness;

        public MarcaController(IMarcaBusiness marca)
        {
            marcaBusiness = marca;
        }

        // GET: api/marcas
        [HttpGet]
        public ActionResult Get()
        {
            IList<MarcaEntity> marcas = marcaBusiness.ListarTodasMarcas();
            return Ok(marcas);
        }

        // GET: api/marcas/{marcaId}
        [HttpGet("{marcaId}")]
        public ActionResult<MarcaEntity> Get(int marcaId)
        {
            MarcaEntity marca = marcaBusiness.ConsultarPorId(marcaId);

            if (null == marca
                || marca.MarcaId.Equals(0))
                return NotFound(
                    string.Format("Nenhum registro encontrado: {0}!"
                        , marcaId));
            else
                return Ok(marca);
        }

        // POST: api/marcas
        [HttpPost]
        public ActionResult Post(string nome)
        {
            if (marcaBusiness.InserirMarca(nome))
                return Ok();
            else
                ///Não foi possível resolver a requisição. E o registro não foi gerado;
                return BadRequest();
        }

        // GET: api/marcas/{id}
        [HttpGet("{marcaId}/patrimonios")]
        public ActionResult GetPatrimoniosPorMarcaId(int marcaId)
        {
            IList<PatrimonioEntity> patrimonios 
                = marcaBusiness.ConsultarPatrimoniosPorMarcaId(marcaId);

            if (null == patrimonios
                || patrimonios.Equals(0))
                return NotFound(
                    string.Format("Nenhum registro encontrado: {0}!"
                        , marcaId));
            else
                return Ok(patrimonios);
        }

        // PUT: api/marcas/{id}
        [HttpPut()]
        public ActionResult Put(int marcaId, string nome)
        {
            if (marcaBusiness.AtualizarMarca(marcaId, nome))
                return Ok();
            else
                ///Não foi possível resolver a requisição. E o registro não foi atualizado;
                return BadRequest(
                 string.Format(@"Nenhum registro foi atualizado: {0} !"
                         , marcaId));
        }

        // DELETE: api/marcas/{id}
        [HttpDelete("{marcaId}")]
        public ActionResult Delete(int marcaId)
        {
            if (marcaBusiness.ExcluirMarcaPorId(marcaId))
                return NoContent();
            else
                ///Não foi possível resolver a requisição. E o registro não foi excluido;
                return BadRequest(
                    string.Format(@"Nenhum registro foi encontrado: {0} !"
                            , marcaId));
        }
    }
}
