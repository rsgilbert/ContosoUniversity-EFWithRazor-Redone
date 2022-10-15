using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(ContosoUniversity.Data.SchoolContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Student Student { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            Student = await _context.Student.FirstOrDefaultAsync(m => m.ID == id);

            var  errorMessage = $"No student found with ID {id}";
            if (Student == null)
                return RedirectToPage("./Index", new { errorMessage });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return RedirectToPage("./Index");

            Student = await _context.Student.FindAsync(id);
            _logger.LogInformation("Found student is", Student);
            if (Student == null)
            {
                var errorMessage = $"Failed to delete student with ID {id}. Student does not exist";
                return RedirectToPage("./Index", new { errorMessage });
            }

            _context.Student.Remove(Student);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
