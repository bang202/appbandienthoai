using CuaHangOnline.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CuaHangOnline.Controllers
{
	[ViewComponent(Name = "_Category")]
	public class _CategoryViewComponets:ViewComponent
	{
		private readonly CuaHangOnlineContext _context;

		public _CategoryViewComponets(CuaHangOnlineContext context)
		{
			_context = context;
		}
		
	}
}
