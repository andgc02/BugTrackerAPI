using BugTrackerAPI.Models;
using BugTrackerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BugsController : ControllerBase
{
    private readonly BugContext _context;

    // Constructor to initialize the database context
    public BugsController(BugContext context)
    {
        _context = context;
    }

    // GET: api/bugs
    // Retrieves all bugs from the database
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bug>>> GetBugs()
    {
        return await _context.Bugs.ToListAsync();
    }

    // GET: api/bugs/{id}
    // Retrieves a specific bug by its ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Bug>> GetBug(int id)
    {
        var bug = await _context.Bugs.FindAsync(id);

        // If the bug is not found, return a 404 Not Found response
        if (bug == null)
        {
            return NotFound();
        }
        return bug;
    }

    // POST: api/bugs
    // Adds a new bug to the database
    [HttpPost]
    public async Task<ActionResult<Bug>> PostBug(Bug bug)
    {
        // Set the creation date to the current UTC time
        bug.CreatedAt = DateTime.UtcNow;

        // Add the bug to the context and save changes
        _context.Bugs.Add(bug);
        await _context.SaveChangesAsync();

        // Return a response with the created bug's details
        return CreatedAtAction(nameof(GetBug), new { id = bug.Id }, bug);
    }

    // PUT: api/bugs/{id}
    // Updates an existing bug by its ID
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBug(int id, Bug bug)
    {
        // Check if the provided ID matches the bug's ID
        if (id != bug.Id)
        {
            return BadRequest();
        }

        // Mark the bug entity as modified
        _context.Entry(bug).State = EntityState.Modified;

        // Save changes to the database
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/bugs/{id}
    // Deletes a bug by its ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBug(int id)
    {
        // Find the bug by its ID
        var bug = await _context.Bugs.FindAsync(id);

        // If the bug is not found, return a 404 Not Found response
        if (bug == null)
        {
            return NotFound();
        }

        // Remove the bug from the context and save changes
        _context.Bugs.Remove(bug);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}