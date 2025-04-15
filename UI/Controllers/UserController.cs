using Business.Abstract;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.TGetAll();
        return Ok(users);
    }

    [HttpGet("{id}")] 
    public IActionResult GetById(int id)
    {
        var user = _userService.TGetById(id);
        if (user == null)
        {
            return NotFound(new { Message = "User not found." });
        }
        return Ok(user);
    }

    [HttpPost] 
    public IActionResult Add([FromBody] User user)
    {
        if (user == null) return BadRequest(new { Message = "Invalid user data." });

        _userService.TInsert(user);
        return Ok(new { Message = "User added successfully." });
    }

    [HttpPut] 
    public IActionResult Update([FromBody] User user)
    {
        if (user == null) return BadRequest(new { Message = "Invalid user data." });

        var existingUser = _userService.TGetById(user.UserID);
        if (existingUser == null)
        {
            return NotFound(new { Message = "User not found." });
        }

        _userService.TUpdate(user);
        return Ok(new { Message = "User updated successfully." });
    }

    [HttpDelete("{id}")] 
    public IActionResult Delete(int id)
    {
        var user = _userService.TGetById(id);
        if (user == null)
        {
            return NotFound(new { Message = "User not found." });
        }

        _userService.TDelete(user);
        return Ok(new { Message = "User deleted successfully." });
    }
}
