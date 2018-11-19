using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BS.Commands.Book.Create;
using BS.Queries.Book.Get;

namespace BS.Presentation.API.Controllers
{
    public class BookController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody]CreateBookCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction("Create", new { Id = id }, id);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetBookQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
