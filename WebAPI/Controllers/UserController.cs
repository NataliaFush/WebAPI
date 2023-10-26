using Core.Entities;
using Core.Interface;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class UserController : Controller
    {
        protected readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<IUser> GetAllUsers()
        {
            return _userService.GetAllUser();
        }

        [HttpGet("{id}")]
        public IUser GetUserById(Guid id) 
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("email/{email}")]
        public IUser? GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }


        [HttpPut("Update")]
        public bool UpdateUser([FromBody] UserApiModel user)
        {
            var iUser = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Password = user.Password,
                Address = user.Address != null ? new Address()
                {
                    City = user.Address.City,
                    PostalCode = user.Address.PostalCode,
                    Street = user.Address.Street
                } : null,
            };

            return _userService.UpdateUser(iUser);
        }
    }
}
