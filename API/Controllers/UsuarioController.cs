using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patrimonio.Business.Interface;
using Patrimonio.Entities;

namespace Patrimonios.API.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioBusiness usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuario)
        {
            usuarioBusiness = usuario;
        }

        // GET: api/Usuario
        [HttpGet]
        public IList<UsuarioEntity> Get()
        {
            return usuarioBusiness.ListarTodosUsuarios();
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public UsuarioEntity Get(int id)
        {
            return usuarioBusiness.ConsultarPorId(id);
        }

        // POST: api/Usuario
        [HttpPost]
        public void Post([FromBody] UsuarioEntity usuario)
        {
            usuarioBusiness.InserirUsuario(usuario);
        }

        // PUT: api/Usuario/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UsuarioEntity usuario)
        {
            usuario.UsuarioId = id;
            usuarioBusiness.AtualizarUsuario(usuario);
        }

        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            usuarioBusiness.ExcluirUsuarioPorId(id);
        }
    }
}
