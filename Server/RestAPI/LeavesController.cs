using AspCoreServer.Data;
using AspCoreServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreServer.Controllers
{
  [Route("api/[controller]")]
  public class LeavesController : Controller
  {
    private readonly SpaDbContext _context;

    public LeavesController(SpaDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int currentPageNo = 1, int pageSize = 20)
    {
      var leaves = await _context.Leaf
          .OrderByDescending(l => l.ItemCreatedDate)
          .Skip((currentPageNo - 1) * pageSize)
          .Take(pageSize)
          .ToArrayAsync();

      if (!leaves.Any())
      {
        return NotFound("Leaves not Found");
      }
      else
      {
        return Ok(leaves);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var leaf = await _context.Leaf
          .Where(l => l.ID == id)
          .AsNoTracking()
          .SingleOrDefaultAsync(m => m.ID == id);

      if (leaf == null)
      {
        return NotFound("Leaf not Found");
      }
      else
      {
        return Ok(leaf);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Leaf leaf)
    {
      if (!string.IsNullOrEmpty(leaf.ItemName))
      {
        _context.Add(leaf);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Leaf", leaf);
      }
      else
      {
        return BadRequest("Leaf name was not given");
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]Leaf leafUpdateValue)
    {
      try
      {
        leafUpdateValue.ItemCreatedDate = DateTime.Now;

        var leafToEdit = await _context.Leaf
          .AsNoTracking()
          .SingleOrDefaultAsync(m => m.ID == id);

        if (leafToEdit == null)
        {
          return NotFound("Could not update leaf as it was not Found");
        }
        else
        {
          _context.Update(leafUpdateValue);
          await _context.SaveChangesAsync();
          return Ok("Updated leaf - " + leafUpdateValue.ItemName);
        }
      }
      catch (DbUpdateException)
      {
        //Log the error (uncomment ex variable name and write a log.)
        ModelState.AddModelError("", "Unable to save changes. " +
            "Try again, and if the problem persists, " +
            "see your system administrator.");
        return NotFound("Leaf not Found");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var leafToRemove = await _context.Leaf
          .AsNoTracking()
      .SingleOrDefaultAsync(m => m.ID == id);
      if (leafToRemove == null)
      {
        return NotFound("Could not delete leaf as it was not Found");
      }
      else
      {
        _context.Leaf.Remove(leafToRemove);
        await _context.SaveChangesAsync();
        return Ok("Deleted leaf - " + leafToRemove.ItemName);
      }
    }
  }
}
