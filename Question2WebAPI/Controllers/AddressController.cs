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
    public class AddressController : ControllerBase
    {
        private readonly Question2WebAPIContext _context;

        private readonly ILogger<AddressController> _logger;
        public AddressController(Question2WebAPIContext context, ILogger<AddressController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            try
            {
                _logger.LogInformation("Called GetAddress method");
                return await _context.Address.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(long id)
        {
            try
            {
                _logger.LogInformation("Called GetAddress by id method");
                var address = await _context.Address.FindAsync(id);

                if (address == null)
                {
                    return NotFound();
                }

                return address;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }
        }

        // PUT: api/Address/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(long id, Address address)
        {
            try
            {
                _logger.LogInformation("Called PutAddress method");
                if (id != address.Id)
                {
                    return BadRequest();
                }

                _context.Entry(address).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(id))
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

        // POST: api/Address
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            try
            {
                _logger.LogInformation("Called PostAddress method");
                _context.Address.Add(address);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAddress", new { id = address.Id }, address);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }
        }

        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(long id)
        {
            try
            {
                _logger.LogInformation("Called DeleteAddress method");
                var address = await _context.Address.FindAsync(id);
                if (address == null)
                {
                    return NotFound();
                }

                _context.Address.Remove(address);
                await _context.SaveChangesAsync();

                return address;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured: " + ex);
                throw;
            }

        }
        private bool AddressExists(long id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
