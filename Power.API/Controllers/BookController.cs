using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Power.Core.DTOs;
using Power.Core.Repository;
using Power.Core.Services;
using Power.Core.Services.Interface;
using Power.Data.Entities;
using Power.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet("GetBooks")]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks();
            var dtos = _mapper.Map<IEnumerable<BookDTO>>(books);
            return Ok(dtos);
        }

        [HttpPost("Create")]
        public IActionResult AddBooks(AddBookDTO dto)
        {
            var entity = _mapper.Map<Book>(dto);
            var addedBook = _bookRepository.AddSpecialBooks(entity);
            return Ok(_mapper.Map<BookDTO>(addedBook));
        }

    }
}
