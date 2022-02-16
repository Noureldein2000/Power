using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Power.Core.DTOs;
using Power.Core.Repository;
using Power.Core.Services;
using Power.Core.Services.Interface;
using Power.Data.Entities;
using Power.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Power.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService,
            IMapper mapper
            )
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet("GetAuthors")]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAll();
            return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(authors));
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_authorService.GetById(id));
        }

        [HttpPost("Create")]
        public IActionResult AddAuthor(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            var addedAuthor = _authorService.AddAuthor(author);
            return Ok(_mapper.Map<AuthorDTO>(addedAuthor));
        }
    }
}
