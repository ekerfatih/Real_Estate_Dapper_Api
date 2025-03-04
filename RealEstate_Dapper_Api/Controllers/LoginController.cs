using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(Context context) : ControllerBase {
        private readonly Context _context = context;

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto) {
            string query = "select * from AppUser where Username=@username and Password=@password";
            string query2 = "select UserId from AppUser where Username=@username and Password=@password";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@username", createLoginDto.Username);
            parameters.Add("@password", createLoginDto.Password);
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                var values2 = await connection.QueryFirstOrDefaultAsync<GetAppUserIdDto>(query2, parameters);
                if (values != null) {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.Username = values.Username;
                    model.Id = values2.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else {
                    return BadRequest();
                }
            }
        }
    }
}
