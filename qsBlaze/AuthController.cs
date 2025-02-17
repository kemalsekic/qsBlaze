//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Google;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace qsBlaze
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        [HttpGet("/signin-google")]
//        public async Task<ActionResult> Google()
//        {
//            var properties = new AuthenticationProperties
//            {
//                RedirectUri = "/signin-google"
//            };

//            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
//        }
//    }
//}
