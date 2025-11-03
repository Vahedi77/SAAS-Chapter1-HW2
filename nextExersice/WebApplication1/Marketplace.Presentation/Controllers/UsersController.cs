using Microsoft.AspNetCore.Mvc;
using Marketplace.Application.Interfaces;
using Marketplace.Presentation.DTOs.RequestModels;
using Marketplace.Presentation.DTOs.ResponseModels;

[ApiController]
[Route("user-apis")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("get-user-summary/{id}")]
    public ActionResult<UserSummaryResponseModel> GetUserFunction(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        var response = new UserSummaryResponseModel
        {
            Id = user.Id,
            Username = user.Username
        };

        return Ok(response);
    }

    [HttpPost("login")]
    public ActionResult<string> LoginUser([FromBody] LoginRequestModel loginRequest)
    {
        var user = _userService.GetUserByUsername(loginRequest.Username);
        if (user == null || user.Password != loginRequest.Password)
            return Unauthorized("Invalid username or password");

        return Ok("Login successful");
    }
}