using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCrudEf.Models;

namespace WebAppCrudEF2.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioContext _context;

        public FuncionarioController(FuncionarioContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }



        // GET: Funcionario/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Funcionario());
            else
                return View(_context.Funcionarios.Find(id));
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("FuncionarioId,NomeCompleto,FunCode,Posicao,Cargo")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                if (funcionario.FuncionarioId == 0)
                    _context.Add(funcionario);
                else
                    _context.Update(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }


        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
