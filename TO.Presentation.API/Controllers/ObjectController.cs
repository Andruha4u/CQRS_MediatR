using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TO.Commands.Object.Create;
using TO.Queries.Object.Get;

namespace TO.Presentation.API.Controllers
{
    public class ObjectController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ObjectItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody]CreateObjectItemCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction("Create", new { Id = id }, id);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ObjectItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetObjectItemQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
