using Microsoft.AspNetCore.Mvc;

namespace Teste
{
    public class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result,
            });
        }

        protected ActionResult NotificarErro(string mensagem)
        {
            return BadRequest(new
            {
                success = false,
                data = mensagem,
            });
        }
    }
}
