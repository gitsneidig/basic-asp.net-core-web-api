using System.Collections.Generic;
using ConsotoPizza.Services;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Pizza pizza) {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza) {
            var existingPizza = PizzaService.Get(id);
            if (id != pizza.Id || existingPizza is null) 
                return BadRequest();

            PizzaService.Update(pizza);

            return NoContent();
        }

        // DELETE action        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var pizza = PizzaService.Get(id);

            if (pizza is null) 
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }

    }
}