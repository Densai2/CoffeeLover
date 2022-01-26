﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoffeeLover.Data;
using CoffeeLover.Models;

namespace CoffeeLover.Pages.OrderItem
{
    public class DeleteModel : PageModel
    {
        private readonly CoffeeLover.Data.ApplicationDbContext _context;

        public DeleteModel(CoffeeLover.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderItems OrderItems { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderItems = await _context.OrderItems.FirstOrDefaultAsync(m => m.OrderID == id);

            if (OrderItems == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderItems = await _context.OrderItems.FindAsync(id);

            if (OrderItems != null)
            {
                _context.OrderItems.Remove(OrderItems);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
