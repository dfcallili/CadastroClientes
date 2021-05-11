using Cadastro.Ciente.Dto;
using Cadastro.Cliente.Service.Contracts;
using Cadastro.Cliente.Service.Contracts.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cadastro.Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IArmazenadorDeCliente _armazenadorDeCliente;
        private readonly IConsultadorDeClientes _consultadorDeClientes;
        private readonly IRemovedorDeCliente _removedorDeCliente;
        private readonly IDomainNotificationHandler _notificacaoDeDominio;
        public ClienteController(IDomainNotificationHandler notificacaoDeDominio,
            IArmazenadorDeCliente armazenadorDeCliente,
            IConsultadorDeClientes consultadorDeClientes,
            IRemovedorDeCliente removedorDeCliente)
        {
            _notificacaoDeDominio = notificacaoDeDominio;
            _armazenadorDeCliente = armazenadorDeCliente;
            _consultadorDeClientes = consultadorDeClientes;
            _removedorDeCliente = removedorDeCliente;

        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _consultadorDeClientes.Consultar());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _consultadorDeClientes.Consultar(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteCrmallDto clienteCrmallDto)
        {
            try
            {
                await _armazenadorDeCliente.Armazenar(clienteCrmallDto);

                if (_notificacaoDeDominio.HasNotifications())
                    return BadRequest(_notificacaoDeDominio.GetNotifications().Select(n => n));

                return Ok(clienteCrmallDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteCrmallDto clienteCrmallDto)
        {
            try
            {
                await _armazenadorDeCliente.Armazenar(clienteCrmallDto);

                if (_notificacaoDeDominio.HasNotifications())
                    return BadRequest(_notificacaoDeDominio.GetNotifications().Select(n => n));

                return Ok(clienteCrmallDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _removedorDeCliente.Remover(id);

                if (_notificacaoDeDominio.HasNotifications())
                    return BadRequest(_notificacaoDeDominio.GetNotifications().Select(n => n));

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
