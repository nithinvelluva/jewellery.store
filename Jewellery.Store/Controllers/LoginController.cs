using Jewellery.Store.Services;
using Jewellery.Store.ViewModels.Mapper;
using Jewellery.Store.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewellery.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUserMapper _userMapper;
        public LoginController(ILoginService loginService, IUserMapper userMapper)
        {
            _loginService = loginService;
            _userMapper = userMapper;
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public UserViewModel Get(int id)
        {
            var user = _loginService.GetUserInfo(id);
            var result = _userMapper.Encode(user);
            return result;
        }

        // POST: api/Login
        [HttpPost]
        public UserViewModel Post(CredentialsViewModel credentials)
        {
            var user = _loginService.LoginAsync(credentials);
            var result = _userMapper.Encode(user);
            return result;
        }
    }
}
