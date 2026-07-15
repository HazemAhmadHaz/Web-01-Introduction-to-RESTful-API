using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPIController.Controllers
{
    //Swagger is a client that test this server
    [Route("api/[controller]")] // Route go to controller which is a placeholder that get the name of the Class and remove the controller part from it (Dynamic)
    [Route("api/[ServerSideCode]")] // Route go to ServerSideCode and use it as the name of the class (Hard Coded), so if you change the name of the class in the future the name that will be printed in Swagger will noy change
    [ApiController]
    public class MyFirstAPIController : ControllerBase
    {
        [HttpGet("MyName", Name = "My Name")]
        public string GetMyName()
        {
            // Return the server-side code as a string
            return "Hazem Ahmad";

        }
        [HttpGet("YourName", Name = "your Name")]
        public string GetYourName()
        {
            // Return the server-side code as a string
            return "Ahmad Hazem";

        }
        [HttpGet("Sum/{Num1}/{Num2}")]
        public int Sum2Nums(int Num1, int Num2)
        {
            return Num1 + Num2;

        }
        [HttpGet("Multi/{Num1}/{Num2}")]
        public int Multiply2Nums(int Num1, int Num2)
        {
            return Num1 * Num2;

        }
    }
}
