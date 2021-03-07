using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using AspNetCoreWebApiIntro.Data;
using AspNetCoreWebApiIntro.Dtos;
using AspNetCoreWebApiIntro.Models;

namespace AspNetCoreWebApiIntro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppRepo _repo;
        private readonly IMapper _mapper;

        public UsersController(AppRepo repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> Index()
        {
            IEnumerable<User> users = this._repo.GetAllUsers();
            return Ok(this._mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpGet("{id}", Name = "Show")]
        public ActionResult<UserReadDto> Show(int id)
        {
            User user = this._repo.GetUserById(id);

            if (user != null)
                return Ok(this._mapper.Map<UserReadDto>(user));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            this._repo.CreateUser(user);
            this._repo.SaveChanges();

            return CreatedAtRoute(nameof(Show), new { Id = user.Id }, user);
        }

        [HttpPatch("{id}")]
        public ActionResult Update(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            User user = this._repo.GetUserById(id);

            if (user != null)
            {
                UserUpdateDto userToUpdate = this._mapper.Map<UserUpdateDto>(user);
                patchDoc.ApplyTo(userToUpdate, ModelState);

                if (!TryValidateModel(userToUpdate))
                {
                    return ValidationProblem(ModelState);
                }

                this._mapper.Map(userToUpdate, user);
                this._repo.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            User user = this._repo.GetUserById(id);

            if (user != null)
            {
                this._repo.DeleteUser(user);
                this._repo.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }
    }
}
