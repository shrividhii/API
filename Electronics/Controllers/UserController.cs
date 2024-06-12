using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Electronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Common Correct Code
        //private readonly ElectronicsStoreContext _context;
        //private readonly IConfiguration _configuration;
        //private readonly IMapper _mapper;

        //public UserController(ElectronicsStoreContext context, IConfiguration configuration, IMapper mapper)
        //{
        //    _context = context;
        //    _configuration = configuration;
        //    _mapper = mapper;
        //}
        #endregion

        #region Mistake in Mapping
        //[HttpPost("UserDetails")]
        //public async Task<IActionResult> UserDetails([FromBody] UserDetails login)
        //{
        //    if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
        //    {
        //        return BadRequest("Invalid client request");
        //    }

        //    // Map UserDetails (User) to UserDetails (Entity)
        //    var userEntity = _mapper.Map<Common.EntityClass.UserDetails>(login);

        //    // Validate credentials
        //    var user = await _context.UserDetails
        //        .FirstOrDefaultAsync(u => u.Username == userEntity.Username && u.Password == userEntity.Password);

        //    if (user != null)
        //    {
        //        // Generate JWT token
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
        //        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //        var tokenOptions = new JwtSecurityToken(
        //            issuer: _configuration["JWT:Issuer"],
        //            audience: _configuration["JWT:Audience"],
        //            claims: new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, user.Username)
        //                // Add more claims if needed
        //            },
        //            expires: DateTime.Now.AddMinutes(60),
        //            signingCredentials: signingCredentials);

        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //        return Ok(new { Token = tokenString });
        //    }

        //    return Unauthorized();
        //}
        #endregion


        #region Corect Mapping
        //[HttpPost("UserDetails")]
        //public async Task<IActionResult> UserDetails([FromBody] Common.UserModel.UserDetails login)
        //{
        //    if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
        //    {
        //        return BadRequest("Invalid client request");
        //    }

        //    // Validate credentials
        //    var user = await _context.UserDetails
        //        .FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

        //    if (user != null)
        //    {
        //        // Map user entity to view model
        //        var userViewModel = _mapper.Map<Common.UserModel.UserDetails>(user);

        //        // Log the userViewModel to verify its contents
        //        Console.WriteLine("Mapped UserViewModel: " + System.Text.Json.JsonSerializer.Serialize(userViewModel));

        //        // Generate JWT token
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
        //        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //        var tokenOptions = new JwtSecurityToken(
        //            issuer: _configuration["JWT:Issuer"],
        //            audience: _configuration["JWT:Audience"],
        //            claims: new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, user.Username)
        //            },
        //            expires: DateTime.Now.AddMinutes(60),
        //            signingCredentials: signingCredentials);

        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //        return Ok(new { Token = tokenString, User = userViewModel });
        //    }

        //    return Unauthorized();
        //}

        #endregion


        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("UserDetails")]
        public async Task<IActionResult> UserDetails([FromBody] Common.UserModel.UserDetails login)
        {
            if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Invalid client request");
            }

            var userViewModel = await _userService.AuthenticateAsync(login);
            if (userViewModel != null)
            {
                var token = _userService.GenerateJwtToken(_mapper.Map<Common.DBEntityClass.UserDetail>(userViewModel));
                return Ok(new { Token = token, User = userViewModel });
            }

            return Unauthorized();
        }
    }
}

