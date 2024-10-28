//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using UniPlatform.Models;
//using UniPlatform.Models.DTO;
//using UniPlatform.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using System.Data;


//namespace UniPlatform.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private readonly AuthService _authService;

//        public AccountController(AuthService authService)
//        {
//            _authService = authService;
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> RegisterStudent([FromBody] StudentRegistrationDTO dto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var (succeeded, userId) = await _authService.RegisterUserAsync(dto);

//            if (succeeded)
//            {
//                var token = _authService.GenerateJwtToken(userId, UserRoleEnum.Student);
//                return Ok(new { message = "Student registered successfully", token });
//            }

//            return BadRequest(new { message = "Registration failed" });
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
//        {
//            var (succeeded, userId) = await _authService.LoginAsync(dto);

//            if (succeeded)
//            {
//                var token = _authService.GenerateJwtToken(userId, UserRoleEnum.Student);
//                return Ok(new { message = "Login successful", token });
//            }

//            return Unauthorized(new { message = "Invalid credentials" });
//        }

//        [Authorize(Roles = "Administrator")]
//        [HttpPost("add-role")]
//        public IActionResult AddRole([FromBody] string role)
//        {
//            // Логіка для додавання ролей
//            return Ok(new { message = "Role added successfully" });
//        }
//    }
//}
