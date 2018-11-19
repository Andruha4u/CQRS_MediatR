using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BS.Commands.Store.Create;
using BS.Queries.Store.Get;

namespace BS.Presentation.API.Controllers
{
    public class BookStroeController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(BookStoreViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody]CreateBookStoreCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction("Create", new { Id = id }, id);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookStoreViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetBookStoreQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
