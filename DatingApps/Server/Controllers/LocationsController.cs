using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApps.Server.Data;
using DatingApps.Shared.Domain;
using DatingApps.Server.IRepository;

namespace DatingApps.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var User = await _unitOfWork.User.GetAll();
            return Ok(User);
        }
        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _unitOfWork.User.Get(q => q.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }
        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            _unitOfWork.User.Update(User);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            await _unitOfWork.User.Insert(User);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetUser", new { id = User.Id }, User);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var User = await _unitOfWork.User.Get(q => q.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            await _unitOfWork.User.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> UserExistsAsync(int id)
        {
            var User = await _unitOfWork.User.Get(q => q.Id == id);
            return User != null;
        }
    }
}