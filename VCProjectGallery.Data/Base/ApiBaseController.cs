using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VCProjectGallery.Models.Base;

namespace VCProjectGallery.Data.Base
{
	[ApiController]
	[Route("Api/[controller]/[action]")]

	public abstract class ApiBaseController<T> : ControllerBase
		where T : PublicBaseClass
	{
		private readonly ApplicationDbContext _context;
		public ApiBaseController(ApplicationDbContext context)
		{
			this._context = context;
		}

		[HttpGet]
		public virtual object Get()
		{
			return _context.Set<T>()
				.Where(p => p.IsDeleted==false);
		}

		[HttpGet("{key}")]
		public virtual ActionResult<T> Get(Guid key)
		{

			if (EntityExists(key))
			{
				var result = _context.Set<T>()
					.Where(p => p.ID == key)
					.Where(p => p.IsDeleted==false).ToList()
					.First();

				return Ok(result);
			}
			else
			{
				return BadRequest("Entity not Found");
			}
		}

		[HttpPost]
		public virtual async Task<IActionResult> Post([FromBody] T entity)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			this.SetCreatedByUser(entity);

			await _context.Set<T>().AddAsync(entity);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
			return Created(nameof(entity), entity);
		}

		[HttpPatch("{key}")]
		public virtual async Task<IActionResult> Patch(Guid key, [FromBody] JsonPatchDocument<T> update)
		{
			if (!EntityExists(key))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			//var updateInfo = update.GetChangedPropertyNames().ToArray();
			var entity = await _context.Set<T>().FindAsync(key);
			try
			{
				update.ApplyTo(entity, ModelState);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EntityExists(key))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return Ok(entity);
		}

		[HttpPut("{key}")]
		public virtual async Task<IActionResult> Put(Guid key, [FromBody] T entity)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var _entity = await _context.Set<T>().FindAsync(key);
			this.SetUpdatedByUser(entity);

			_context.Set<T>().Remove(_entity);
			_context.Set<T>().Add(entity);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
			return Ok(entity);
		}

		[HttpDelete("{key}")]
		public virtual async Task<IActionResult> Delete(Guid key)
		{
			var entity = await _context.Set<T>().FindAsync(key);

			if (entity == null)
				return NotFound();
			this.SetDeletedByUser(entity);

			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
			return StatusCode((int)HttpStatusCode.NoContent);
		}

		protected bool EntityExists(Guid key)
		{
			return _context.Set<T>().Any(x => x.ID == key && x.IsDeleted == false);
		}

	}
}
