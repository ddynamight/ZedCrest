using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZedCrest.Data.Interfaces;

namespace ZedCrest.Api.Controllers
{
     /// <summary>
     /// ValueChcker: Checks if a value is a multiple of 3 and/or 5
     /// </summary>
     [ApiController, Route("[controller]")]
     public class ValueCheckerController : ControllerBase
     {
          private readonly IValueCheckerRepository valueCheckerRepository;

          /// <summary>
          /// Provides access to the logic
          /// </summary>
          /// <param name="valueCheckerRepository"></param>
          public ValueCheckerController(IValueCheckerRepository valueCheckerRepository)
          {
               this.valueCheckerRepository = valueCheckerRepository;
          }

          /// <summary>
          /// Checks if a value is a multiple of 3 and/or 5
          /// </summary>
          /// <param name="value">parameter to check</param>
          /// <returns>a string value showing Fizz for 3, Buzz for 5 and FizzBuzz for 3 and 5 else return value </returns>

          [HttpGet("{value:int}", Name = "CheckValue"), ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
          public IActionResult CheckValue(int value)
          {
               return Ok(valueCheckerRepository.IsMultiple(value));
          }
     }
}
