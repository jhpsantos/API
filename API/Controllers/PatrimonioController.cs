using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Patrimonio.Business.Interface;
using Patrimonio.Entities;

namespace API.Controllers
{
    [Route("api/Patrimonio")]
    [ApiController]
    public class PatrimonioController : ControllerBase
    {
        IPatrimonioBusiness patrimonioBusiness;

        public PatrimonioController(IPatrimonioBusiness patrimonio)
        {
            patrimonioBusiness = patrimonio;
        }

        // GET api/patrimonio
        //Listar todos os patrimonios;
        [HttpGet]
        public IList<PatrimonioEntity> Get()
        {
            return patrimonioBusiness.ListarTodosPatrimonios();
        }

        // GET api/patrimonio/{id}
        [HttpGet("{id}")]
        public PatrimonioEntity Get(int id)
        {
            return patrimonioBusiness.ConsultarPorId(id);
        }

        // GET api/patrimonio/GetNrTombo/{nrTombo}
        [HttpGet("{nrTombo}")]
        [Route("GetNrTombo/{nrTombo}")]
        public PatrimonioEntity GetNrTombo(string nrTombo)
        {
            return patrimonioBusiness.ConsultarPorNumeroTombo(nrTombo);
        }

        // POST api/patrimonio
        // Incluir um patrimonio
        [HttpPost]
        public void Post([FromBody] PatrimonioEntity entity)
        {
            patrimonioBusiness.InserirPatrimonio(entity);
        }

        // PUT api/patrimonio/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PatrimonioEntity entity)
        {
            entity.PatrimonioId = id;
            patrimonioBusiness.AtualizarPatrimonio(entity);
        }

        // DELETE api/patrimonio/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            patrimonioBusiness.ExcluirPatrimonioPorId(id);
        }

        // DELETE api/patrimonio/GetNrTombo/{nrTombo}
        [HttpDelete("{nrTombo}")]
        [Route("DeleteNrTombo/{nrTombo}")]
        public void DeleteNrTombo(string nrTombo)
        {
            patrimonioBusiness.ExcluirPatrimonioPorNrTombo(nrTombo);
        }

    }
}
