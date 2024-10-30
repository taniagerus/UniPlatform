using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB;
using UniPlatform.DB.Entities;

namespace UniPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAssignmentsController : ControllerBase
    {
        private readonly PlatformDbContext _context;

        public TestAssignmentsController(PlatformDbContext context)
        {
            _context = context;
        }

        // GET: api/TestAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestAssignment>>> GetTestAssignments()
        {
            return await _context.TestAssignments.ToListAsync();
        }

        // GET: api/TestAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestAssignment>> GetTestAssignment(int id)
        {
            var testAssignment = await _context.TestAssignments.FindAsync(id);

            if (testAssignment == null)
            {
                return NotFound();
            }

            return testAssignment;
        }

        // PUT: api/TestAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestAssignment(int id, TestAssignment testAssignment)
        {
            if (id != testAssignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(testAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestAssignmentExists(id))
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

        // POST: api/TestAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestAssignment>> PostTestAssignment(TestAssignment testAssignment)
        {
            _context.TestAssignments.Add(testAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestAssignment", new { id = testAssignment.Id }, testAssignment);
        }

        // DELETE: api/TestAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAssignment(int id)
        {
            var testAssignment = await _context.TestAssignments.FindAsync(id);
            if (testAssignment == null)
            {
                return NotFound();
            }

            _context.TestAssignments.Remove(testAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestAssignmentExists(int id)
        {
            return _context.TestAssignments.Any(e => e.Id == id);
        }
    }
}
