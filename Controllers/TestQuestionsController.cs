using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB;
using UniPlatform.DB.Entities;
using UniPlatform.ViewModels;

namespace UniPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestQuestionsController : ControllerBase
    {
        private readonly PlatformDbContext _context;

        public TestQuestionsController(PlatformDbContext context)
        {
            _context = context;
        }

        // GET: api/TestQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestQuestion>>> GetTestQuestions()
        {
            return await _context.TestQuestions.ToListAsync();
        }

        // GET: api/TestQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestQuestion>> GetTestQuestion(int id)
        {
            var testQuestion = await _context.TestQuestions.FindAsync(id);

            if (testQuestion == null)
            {
                return NotFound();
            }

            return testQuestion;
        }

        // PUT: api/TestQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestQuestion(int id, TestQuestion testQuestion)
        {
            if (id != testQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(testQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestQuestionExists(id))
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

        // POST: api/TestQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<TestQuestion>> PostTestQuestion(QuestionVIewModel testQuestion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var result = new TestQuestion
        //    {
        //        QuestionText = testQuestion.QuestionText,
        //        Category = testQuestion.Category,
        //        CorrectAnswer = testQuestion.CorrectAnswer,
        //        Type = testQuestion.Type,
        //        //Options = testQuestion.Options.Select(o => new TestOption
        //        //{
        //        //    OptionText = o.OptionText,
        //        //}).ToList()
        //    };
        //    _context.TestQuestions.Add(result);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTestQuestion", new { id = result.Id }, testQuestion);
        //}
        public async Task<ActionResult<TestQuestion>> PostTestQuestionWithMultipleOptions(QuestionVIewModel testQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var options =  testQuestion.Options;
            var result = new TestQuestion
            {
                QuestionText = testQuestion.QuestionText,
                Category = testQuestion.Category,
                CorrectAnswer = testQuestion.CorrectAnswer,
                Type = testQuestion.Type,
                Options = string.Join(",", options)
            }; 
            _context.TestQuestions.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestQuestion", new { id = result.Id }, testQuestion);
        }

        // DELETE: api/TestQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestQuestion(int id)
        {
            var testQuestion = await _context.TestQuestions.FindAsync(id);
            if (testQuestion == null)
            {
                return NotFound();
            }

            _context.TestQuestions.Remove(testQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestQuestionExists(int id)
        {
            return _context.TestQuestions.Any(e => e.Id == id);
        }
    }
}
