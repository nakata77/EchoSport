﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoSport.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EchoSport.Pages.Articles
{
    [Authorize]
    public class FootballModel : PageModel
    {
       
        private readonly EchoSport.Data.ApplicationDbContext _context;

        public FootballModel(EchoSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; }

        public async Task OnGetAsync()
        {
            var articles = from a in _context.Article
                select a;

            articles = articles.Where(s => s.Sport.Contains("Football"));
                  
            Article = await articles.ToListAsync();
        }
        
    }
}