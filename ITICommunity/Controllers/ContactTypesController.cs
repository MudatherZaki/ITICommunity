﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITICommunity.Models;

namespace ITICommunity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypesController : ControllerBase
    {
        private readonly ITICommunityContext _context;

        public ContactTypesController(ITICommunityContext context)
        {
            _context = context;
        }

        // GET: api/ContactTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactType>>> GetContactType()
        {
            return await _context.ContactType.ToListAsync();
        }

        // GET: api/ContactTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactType>> GetContactType(int id)
        {
            var contactType = await _context.ContactType.FindAsync(id);

            if (contactType == null)
            {
                return NotFound();
            }

            return contactType;
        }

        // PUT: api/ContactTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactType(int id, ContactType contactType)
        {
            if (id != contactType.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactTypeExists(id))
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

        // POST: api/ContactTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ContactType>> PostContactType(ContactType contactType)
        {
            _context.ContactType.Add(contactType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactType", new { id = contactType.Id }, contactType);
        }

        // DELETE: api/ContactTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactType>> DeleteContactType(int id)
        {
            var contactType = await _context.ContactType.FindAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }

            _context.ContactType.Remove(contactType);
            await _context.SaveChangesAsync();

            return contactType;
        }

        private bool ContactTypeExists(int id)
        {
            return _context.ContactType.Any(e => e.Id == id);
        }
    }
}
