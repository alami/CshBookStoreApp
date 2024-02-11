using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAppAPI.Data;
using BookStoreAppAPI.Models.Author;
using AutoMapper;
using BookStoreAppAPI.Static;
using AutoMapper.QueryableExtensions;
using BookStoreAppAPI.Repositories;

namespace BookStoreAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;
        private readonly ILogger<AuthorsController> logger;

        public AuthorsController(IAuthorRepository authorRepository, IMapper mapper, ILogger<AuthorsController> logger)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
            this.logger = logger;            
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAuthors()
        {
            logger.LogInformation($"my:Request to {nameof(GetAuthors)}");
            try
            {
                var authorDto = mapper.Map<IEnumerable<AuthorReadOnlyDto>>(
                 await authorRepository.GetAllAsync());
                return Ok(authorDto);
            } catch (Exception ex)
            {
                logger.LogError(ex, $"my:Error Performing GET in {nameof(GetAuthors)}");
                //return BadRequest();// throw;
                return StatusCode(500, Messages.Eror500Message);
            }
            
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsDto>> GetAuthor(int id)
        {
            try
            {
                var author = await authorRepository.GetAuthorDetailsAsync(id);

                if (author == null)
                {
                    return NotFound();
                }
                var authorDto = mapper.Map<AuthorReadOnlyDto>(author);
                return Ok(authorDto);
            } catch (Exception ex) { 
                logger.LogError(ex, $"Error Performing  GET in {nameof(GetAuthor)}");
                return StatusCode(500, Messages.Eror500Message);
            }
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDto authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }

            var author = await authorRepository.GetAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            mapper.Map(authorDto, author);

            try
            {
                await authorRepository.UpdateAsync(author);                
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    logger.LogError(ex,$"Error Performing GET in {nameof(PutAuthor)}");
                    return StatusCode(500, Messages.Eror500Message);
                }
            }

            return NoContent();
        }

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorCreateDto>> PostAuthor(AuthorCreateDto authorDto)
        {
            try
            {
                var author = mapper.Map<Author>(authorDto);
                /*new Author() {
        FirstName = authorDto.FirstName,
        LastName = authorDto.LastName,
        Bio = authorDto.Bio,
    };*/

                await authorRepository.AddAsync(author);

                return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
            }catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing POST in {nameof(PostAuthor)}", authorDto);
                return StatusCode(500, Messages.Eror500Message);
            }
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await authorRepository.GetAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            await authorRepository.DeleteAsync(id);            

            return NoContent();
        }

        private async Task<bool> AuthorExists(int id)
        {
            return await authorRepository.Exist(id);
        }
    }
}
