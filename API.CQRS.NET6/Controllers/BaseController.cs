using CQRS.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    public class BaseController : ControllerBase
    {
        #region Success
        public ObjectResult Success<T>(T data, string? message = null)
            => new ObjectResult(new ResponseAPI<T>(true, message, data)) { StatusCode = StatusCodes.Status200OK };
        public ObjectResult Success(object data, string? message = null)
            => new ObjectResult(new ResponseAPI(true, message, data)) { StatusCode = StatusCodes.Status200OK };
        public ObjectResult NoContent(object data, string? message = null)
            => new ObjectResult(new ResponseAPI(true, message, data)) { StatusCode = StatusCodes.Status204NoContent };
        #endregion

        #region Erros
        public ObjectResult InternalServerError(List<string> messages)
            => new ObjectResult(new ResponseErrorAPI(false, "Um erro interno ocorreu ao tentar realizar a operação!", messages)) { StatusCode = StatusCodes.Status500InternalServerError };
        public ObjectResult BadRequestError(string message, List<string> messages)
            => new ObjectResult(new ResponseErrorAPI(false, message, messages)) { StatusCode = StatusCodes.Status400BadRequest };
        public ObjectResult BadRequestError(List<string> messages)
            => new ObjectResult(new ResponseErrorAPI(false, "Ocorreu um erro ao realizar a operação!", messages)) { StatusCode = StatusCodes.Status400BadRequest };
        #endregion
    }
}
