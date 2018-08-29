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
    ///Route default da minha aplicação para o endpoint JSON;
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioBusiness usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuario)
        {
            usuarioBusiness = usuario;
        }

        // GET: api/usuarios
        [HttpGet]
        public ActionResult Get()
        {
            IList<UsuarioEntity> usuarios = usuarioBusiness.ListarTodosUsuarios();
            return Ok(usuarios);
        }

        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public ActionResult<UsuarioEntity> Get(int id)
        {
            UsuarioEntity usuario = usuarioBusiness.ConsultarPorId(id);

            if (null == usuario
                || usuario.UsuarioId.Equals(0))
                return NotFound(
                    string.Format("Nenhum registro encontrado: {0}!"
                        , id));
            else
                return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioEntity usuario)
        {
            if (usuarioBusiness.InserirUsuario(usuario))
                return Ok();
            else
                ///Não foi possível resolver a requisição. E o registro não foi gerado;
                return BadRequest();
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioEntity usuario)
        {
            usuario.UsuarioId = id;
            if (usuarioBusiness.AtualizarUsuario(usuario))
                return Ok();
            else
                ///Não foi possível resolver a requisição. E o registro não foi atualizado;
                return BadRequest(
                 string.Format(@"Nenhum registro foi atualizado: {0} !"
                         , id));
        }

        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (usuarioBusiness.ExcluirUsuarioPorId(id))
                return NoContent();
            else
                ///Não foi possível resolver a requisição. E o registro não foi excluido;
                return BadRequest(
                    string.Format(@"Nenhum registro foi encontrado: {0} !"
                            , id));
        }
    }
}
