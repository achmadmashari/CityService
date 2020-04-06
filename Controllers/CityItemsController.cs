
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceCity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCity.Controllers
{
    // [Route("api/[Controller]")]
    [Route("api/CityItemsController")]
    [ApiController]
    public class CityItemsController : ControllerBase
    {
        private readonly CityContext _context;

        public CityItemsController(CityContext context)
        {
            _context = context;
        }


        //// GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityItem>>> GetCityItem()
        {
            return await _context.cityitem.ToListAsync();

            //return await _context.cityitem.Select(x => cityitemdto(x))
            //    .ToListAsync();
        }

        //// GET: api/TodoItems/"CGK"
        [HttpGet("{id}")]
        public async Task<ActionResult<CityItem>> GetCityItem(int Id)
        {
            var cityitem = await _context.cityitem.FindAsync(Id);

            if (cityitem == null)
            {
                return NotFound();
            }

            return cityitem;
        }


        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityItem(long id, CityItem cityItem)
        {
            if (id != cityItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cityItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityItemExists(id))
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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatecityItem(long id, CityItem cityitemdto)
        //{
        //    if (id != cityitemdto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var cityItem = await _context.cityitem.FindAsync(id);
        //    if (cityItem == null)
        //    {
        //        return NotFound();
        //    }

        //    cityItem.Name = cityitemdto.Name;
        //    cityItem.IsComplete = cityitemdto.IsComplete;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException) when (!Cityitemexists(id))
        //    {
        //        return NoContent();
        //        //return NotFound();
        //    }
        //    return NotFound();

        //}

        //// POST: api/TodoItems
        //[HttpPost]
        //public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        //{
        //    _context.TodoItems.Add(todoItem);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        //    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        //}

        [HttpPost]
        public async Task<ActionResult<CityItem>> CreateCityItem(CityItem cityitemInput)
        {
            var cityitemOutput = new CityItem
            {
                IsComplete = cityitemInput.IsComplete,
                Name = cityitemInput.Name,
                Code = cityitemInput.Code
            };

            _context.cityitem.Add(cityitemOutput);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCityItem),
                new { id = cityitemOutput.Id,cityitemOutput.Code, cityitemOutput.Name }
                );
        }



        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CityItem>> DeleteCityItem(int id)
        {
            var cityItem = await _context.cityitem.FindAsync(id);
            if (cityItem == null)
            {
                return NotFound();
            }

            _context.cityitem.Remove(cityItem);
            await _context.SaveChangesAsync();

            return cityItem;
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> deletecityitem(long id)
        //{
        //    var cityItem = await _context.cityitem.FindAsync(id);

        //    if (cityItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.cityitem.Remove(cityItem);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}




        //private bool TodoItemExists(long id)
        //{
        //    return _context.TodoItems.Any(e => e.Id == id);
        //}


        private bool CityItemExists(long id) =>
             _context.cityitem.Any(e => e.Id == id);

        //private static CityItem cityitemdto(CityItemDto cityitem) =>
        //    new CityItem
        //    {
        //        Id = cityitem.Id,
        //        Name = cityitem.Name,
        //        IsComplete = cityitem.IsComplete
        //    };
    }
}

