using Microsoft.AspNetCore.Mvc;
using PatternArch.Business;
using PatternArch.Persistence.Models;
using ReelTalkReviews.ErrorInfo;

namespace PatternArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly UserInfo _user;
        public UserDataController(UserInfo user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var response = _user.GetUserDetail();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int Id)
        {
            var response = _user.GetUserDetailId(Id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateEmployee(UserDetail userdetails)
        {
        
            _user.CreateUser(userdetails);
           
            return Ok("Created Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult EditEmployee(int id, UserDetail userdetails)
        {
            if (id != userdetails.Id)
            {
                throw new BadRequestException("User not found");
            }
            _user.UpdateUser(userdetails);
          
            return Ok("Updated succfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id, UserDetail userdetails)
        {
            if (id != userdetails.Id)
            {
                throw new BadRequestException("User not found");
            }
            _user.DeleteUser(userdetails);
          
            return Ok("Deleted Successfully");
        }
    }
}
