using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EchoSport.Data;
using EchoSport.Models;
using Microsoft.AspNetCore.Authorization;

namespace EchoSport.Pages.Articles
{
    [Authorize(Roles = "Administrator")]
    public class CreateModel : PageModel
    {
        private readonly EchoSport.Data.ApplicationDbContext _context;

        public CreateModel(EchoSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Article.PublishDate = DateTime.UtcNow;

            _context.Article.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}