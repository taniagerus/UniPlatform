//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using UniPlatform.DB;
//using UniPlatform.DB.Entities;

//namespace UniPlatform.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AssistantsController : ControllerBase
//    {
//        private readonly PlatformDbContext _context;

//        public AssistantsController(PlatformDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Assistants
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Assistant>>> GetAssistants()
//        {
//            return await _context.Assistants.ToListAsync();
//        }

//        // GET: api/Assistants/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Assistant>> GetAssistant(string id)
//        {
//            var assistant = await _context.Assistants.FindAsync(id);

//            if (assistant == null)
//            {
//                return NotFound();
//            }

//            return assistant;
//        }

//        // PUT: api/Assistants/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAssistant(string id, Assistant assistant)
//        {
//            if (id != assistant.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(assistant).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AssistantExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Assistants
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Assistant>> PostAssistant(Assistant assistant)
//        {
//            _context.Assistants.Add(assistant);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (AssistantExists(assistant.Id))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetAssistant", new { id = assistant.Id }, assistant);
//        }

//        // DELETE: api/Assistants/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAssistant(string id)
//        {
//            var assistant = await _context.Assistants.FindAsync(id);
//            if (assistant == null)
//            {
//                return NotFound();
//            }

//            _context.Assistants.Remove(assistant);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool AssistantExists(string id)
//        {
//            return _context.Assistants.Any(e => e.Id == id);
//        }
//    }
//}
