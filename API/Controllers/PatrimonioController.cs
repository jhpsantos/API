﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Patrimonio.Business.Interface;
using Patrimonio.Entities;

namespace API.Controllers
{
    [Route("api/patrimonios")]
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
        public ActionResult Get()
        {
            IList<PatrimonioEntity> patrimonios = patrimonioBusiness.ListarTodosPatrimonios();
            return Ok(patrimonios);
        }

        // GET api/patrimonio/{id}
        [HttpGet("{id}")]
        public ActionResult<PatrimonioEntity> Get(int id)
        {
            PatrimonioEntity patrimonio = patrimonioBusiness.ConsultarPorId(id);

            if (null == patrimonio
                || patrimonio.PatrimonioId.Equals(0))
                return NotFound(
                    string.Format("Nenhum registro encontrado: {0}!"
                        , id));
            else
                return Ok(patrimonio);
        }

        // GET api/patrimonio/tombo/{nrTombo}
        [HttpGet("tombo/{nrTombo}")]
        public ActionResult<PatrimonioEntity> GetNrTombo(string nrTombo)
        {
            PatrimonioEntity patrimonio = patrimonioBusiness.ConsultarPorNumeroTombo(nrTombo);
            if (null == patrimonio
               || patrimonio.PatrimonioId.Equals(0))
                return NotFound(
                    string.Format("Nenhum registro encontrado: {0}!"
                        , nrTombo));
            else
                return Ok(patrimonio);
        }

        // POST api/patrimonio
        // Incluir um patrimonio
        [HttpPost]
        public ActionResult Post([FromBody] PatrimonioEntity entity)
        {
            if (patrimonioBusiness.InserirPatrimonio(entity))
                return Ok();
            else
                ///Não foi possível resolver a requisição. E o registro não foi gerado;
                return BadRequest();
        }

        // PUT api/patrimonio/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PatrimonioEntity entity)
        {
            entity.PatrimonioId = id;
            if (patrimonioBusiness.AtualizarPatrimonio(entity))
                return Ok();
            else
                ///Não foi possível resolver a requisição. E o registro não foi atualizado;
                return BadRequest(
                 string.Format(@"Nenhum registro foi atualizado: {0} !"
                         , id));
        }

        // DELETE api/patrimonio/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (patrimonioBusiness.ExcluirPatrimonioPorId(id))
                return NoContent();
            else
                ///Não foi possível resolver a requisição. E o registro não foi excluido;
                return BadRequest(
                    string.Format(@"Nenhum registro foi encontrado: {0} !"
                            , id));
        }

        // DELETE api/patrimonio/tombo/{nrTombo}
        [HttpDelete("tombo/{nrTombo}")]
        public ActionResult DeleteNrTombo(string nrTombo)
        {
            if (patrimonioBusiness.ExcluirPatrimonioPorNrTombo(nrTombo))
                return NoContent();
            else
                ///Não foi possível resolver a requisição. E o registro não foi excluido;
                return BadRequest(
                    string.Format(@"Nenhum registro foi encontrado: {0} !"
                            , nrTombo));
        }
    }
}
