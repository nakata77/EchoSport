using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoSport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EchoSport.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EchoSport.Data.ApplicationDbContext _context;

        public IndexModel(EchoSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            Article = await _context.Article.ToListAsync();
        }
    }
}
