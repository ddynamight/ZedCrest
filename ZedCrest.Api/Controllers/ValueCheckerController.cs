using Microsoft.AspNetCore.Mvc;
using ZedCrest.Data.Interfaces;

namespace ZedCrest.Api.Controllers
{
     [ApiController, Route("[controller]")]
     public class ValueCheckerController : ControllerBase
     {
          private readonly IValueCheckerRepository valueCheckerRepository;

          public ValueCheckerController(IValueCheckerRepository valueCheckerRepository)
          {
               this.valueCheckerRepository = valueCheckerRepository;
          }


          [HttpGet("{value:int}", Name = "CheckValue")]
          public IActionResult CheckValue(int value)
          {
               return Ok(valueCheckerRepository.IsMultiple(value));
          }
     }
}
