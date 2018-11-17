using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TO.Commands.Interface.Create;

namespace TO.Presentation.API.Controllers
{
    public class InterfaceController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(InterfaceViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody]CreateInterfaceCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction("Create", new { Id = id }, id);
        }
    }

    public class InterfaceViewModel
    {
        public int Id { get; set; }
    }
}
