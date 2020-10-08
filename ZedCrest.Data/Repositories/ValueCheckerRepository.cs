using ZedCrest.Data.Interfaces;

namespace ZedCrest.Data.Repositories
{
     public class ValueCheckerRepository : IValueCheckerRepository
     {
          public string IsMultiple(int value)
          {
               // Check if Value is Between 1 and 100
               if (value < 1 || value > 100) return value.ToString();
               if (value % 3 == 0 && value % 5 == 0)
               {
                    return "FizzBuzz";
               }
               if (value % 3 == 0)
               {
                    return "Fizz";
               }
               if (value % 5 == 0)
               {
                    return "Buzz";
               }
               return value.ToString();
          }
     }
}