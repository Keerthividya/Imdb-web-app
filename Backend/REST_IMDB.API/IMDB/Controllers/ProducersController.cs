using Microsoft.AspNetCore.Mvc;
using IMDB.Models.Request;
using IMDB.Services.Interfaces;
using System;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace IMDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProducerRequest producer)
        {
            try
            {
                var id = _producerService.Create(producer);
                return Created("~/producers/" + id, id);
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
        public IActionResult Get()
        {
            try
            {
                return Ok(_producerService.Get());
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                return Ok(_producerService.Get(id));
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
        public IActionResult Update([FromRoute] int id, [FromBody] ProducerRequest producer)
        {
            try
            {
                _producerService.Update(id, producer);
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
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _producerService.Delete(id);
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

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {

            if (file == null || file.Length == 0)

                return Content("file not selected");

            var task = await new FirebaseStorage("vue-imdb-a74a3.appspot.com")
                .Child("producers")

                    .Child(Guid.NewGuid().ToString() + ".jpg")

                    .PutAsync(file.OpenReadStream());

            return Ok(task);

        }

    }
}
