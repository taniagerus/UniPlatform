using System.Web.Http.ModelBinding;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniPlatform.Authorization;
using UniPlatform.DB;
using UniPlatform.DB.Entities;
using UniPlatform.Interfaces;
using UniPlatform.Services;

namespace uniplatform.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly PlatformDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UsersController(
            UserManager<User> userManager,
            PlatformDbContext context,
            ITokenService tokenService,
            ILogger<UsersController> logger,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                _mapper.Map<User>(request),
                request.Password
            );

            if (result.Succeeded)
            {
                request.Password = "";
                return CreatedAtAction(nameof(Register), request);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email!);
            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(
                managedUser,
                request.Password!
            );
            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (userInDb is null)
            {
                return Unauthorized();
            }

            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();

            return Ok(
                new AuthResponse
                {
                    //Username = userInDb.UserName,
                    Email = userInDb.Email,
                    Token = accessToken,
                }
            );
        }
    }
}
