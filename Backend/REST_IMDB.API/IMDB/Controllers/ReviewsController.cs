using Microsoft.AspNetCore.Mvc;
using IMDB.Models.Request;
using IMDB.Services.Interfaces;
using System;

namespace IMDB.Controllers
{
    [Route("movies/{movieId}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult Create([FromRoute] int movieId, [FromBody] ReviewRequest review)
        {
            try
            {
                var id = _reviewService.Create(movieId, review);
                return Created("~/reviews/" + id, id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        [HttpGet]
        public IActionResult Get([FromRoute] int movieId)
        {
            try
            {
                return Ok(_reviewService.Get(movieId));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int movieId, [FromRoute] int id)
        {
            try
            {
                return Ok(_reviewService.Get(movieId, id));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int movieId, [FromRoute] int id, [FromBody] ReviewRequest review)
        {
            try
            {
                _reviewService.Update(movieId, id, review);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int movieId, [FromRoute] int id)
        {
            try
            {
                _reviewService.Delete(movieId, id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
