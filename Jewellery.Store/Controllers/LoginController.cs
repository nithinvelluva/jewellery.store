using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewellery.Store.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jewellery.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }       

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = _loginService.GetUserInfo(id);
            return new JsonResult(result);
        }

        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post(CredentialsViewModel credentials)
        {
            var result = _loginService.LoginAsync(credentials);
            return new JsonResult(result);
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
