using Departemen_Matematika.Models;
using Departemen_Matematika.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Departemen_Matematika.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MahasiswaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mahasiswa
        public async Task<IActionResult> Index()
        {
            var listdata = await _context.Mahasiswa.ToListAsync();

            //return View(await _context.tblMahasiswa.ToListAsync());
            return View(listdata);
        }

        // GET: Mahasiswa/Create

        public IActionResult Create()
        {
            // var model = new GenderList();
            // model.Gender = getGenderList();
            return View();
        }

        // POST: Mahasiswa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NIM,Nama,Gender,Telephone,Address,Join_Date,Graduation_Date,Dosen_Wali,Fakultas_Code,Department_Code")] Mahasiswa mahasiswa)
        {
            if (mahasiswa.Gender == "0")
            {
                // ModelState.AddModelError("Gender", "Please select gender!");
                // TempData["Message"] = "Please select gender!";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(mahasiswa);
                    await _context.SaveChangesAsync();

                    TempData["AlertMessage"] = "Data created successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswa/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mahasiswa = await _context.Mahasiswa.FindAsync(id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswa/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NIM,Nama,Gender,Telephone,Address,Join_Date,Graduation_Date,Dosen_Wali,Fakultas_Code,Department_Code")] Mahasiswa mahasiswa)
        {
            if (id != mahasiswa.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mahasiswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Mahasiswa.Any(e => e.ID == mahasiswa.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswa/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mahasiswa = await _context.Mahasiswa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswa/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mahasiswa = await _context.Mahasiswa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswa/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mahasiswa = await _context.Mahasiswa.FindAsync(id);

            if (mahasiswa == null)
            {
                return NotFound();
            }
            _context.Mahasiswa.Remove(mahasiswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}