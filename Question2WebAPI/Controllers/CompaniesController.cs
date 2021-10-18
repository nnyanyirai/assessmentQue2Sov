using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Question2WebAPI.Data;
using SingleDotNetCoreWebApp.Models;

namespace Question2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly Question2WebAPIContext _context;
        private readonly ILogger<CompaniesController> _logger;
       
        public CompaniesController(Question2WebAPIContext context, ILogger<CompaniesController> logger)
        {
            _context = context;
               _logger = logger;
        }
    
        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
        {
            try
            {
                _logger.LogInformation("Called GetCompanies method");
                return await _context.Company.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(long id)
        {
            try
            {
                _logger.LogInformation("Called GetCompany by id method");
                var company = await _context.Company.FindAsync(id);

                if (company == null)
                {
                    return NotFound();
                }

                return company;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }
           
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(long id, Company company)
        {
            try
            {
                _logger.LogInformation("Called PutCompany method");
                if (id != company.Id)
                {
                    return BadRequest();
                }

                _context.Entry(company).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(id))
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
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }
           
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            try
            {
                _logger.LogInformation("Called PostCompany method");
                _context.Company.Add(company);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCompany", new { id = company.Id }, company);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }
            
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(long id)
        {
            try
            {
                _logger.LogInformation("Called DeleteCompany method");
                var company = await _context.Company.FindAsync(id);
                if (company == null)
                {
                    return NotFound();
                }

                _context.Company.Remove(company);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }
        }

        private bool CompanyExists(long id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
    }
}
