using backend_tema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend_tema.Controllers
{
    [ApiController]

    public class IngatlanController : ControllerBase
    {

        private readonly IngatlanContext ingatlanContext;

        public IngatlanController(IngatlanContext ingatlancontext)
        {
            ingatlanContext = ingatlancontext;
        }

        [HttpGet("/api/ingatlan")]
        public IActionResult GetAll()
        {
            return Ok(
                ingatlanContext.Set<IngatlanModel>().Include(i => i.Kategoria)
                .Select(i => new
                {
                    i.Id,
                    Kategoria = i.Kategoria.Nev,
                    i.Leiras,
                    HirdetesDatuma = i.HirdetesDatuma.ToString("yyyy-MM-dd"),
                    i.Tehermentes,
                    i.Ar,
                    i.KepUrl

                })
                );
        }

        [HttpPost("/api/ingatlan")]
        public IActionResult New(dynamic data)
        {
            try
            {
                var model = JsonSerializer.Deserialize<IngatlanModel>(data.ToString(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                ingatlanContext.Set<IngatlanModel>().Add(model);
                ingatlanContext.SaveChanges();
                return StatusCode(201, new
                {
                    model.Id
                });
            }
            catch
            {
                return BadRequest("Hiányos adatok!");
            }
        }

        [HttpDelete("/api/ingatlan/{id}")]
        public IActionResult Delete(int id)
        {
            var model = ingatlanContext.Set<IngatlanModel>().FirstOrDefault(i => i.Id == id);

            if (model == null)
            {
                return NotFound("Nincs ilyen ingatlan!");
            }

            ingatlanContext.Set<IngatlanModel>().Remove(model);
            ingatlanContext.SaveChanges();

            return NoContent();
        }


    }
}
