using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        private static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", Description = "Classic cheese and tomato", Price = 8.99M },
            new Pizza { Id = 2, Name = "Pepperoni", Description = "Pepperoni and cheese", Price = 9.99M },
            // Additional record for assignment
            new Pizza { Id = 3, Name = "Veggie", Description = "Peppers, onions, mushrooms", Price = 10.49M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> Get() => Pizzas;

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null) return NotFound();
            return pizza;
        }

        [HttpPost]
        public ActionResult<Pizza> Post(Pizza pizza)
        {
            pizza.Id = Pizzas.Max(p => p.Id) + 1;
            Pizzas.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == id);
            if (index == -1) return NotFound();
            pizza.Id = id;
            Pizzas[index] = pizza;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null) return NotFound();
            Pizzas.Remove(pizza);
            return NoContent();
        }
    }
}