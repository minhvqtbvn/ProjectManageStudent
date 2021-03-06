﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManageStudent.Models;

namespace ProjectManageStudent.Controllers
{
    using System.Net;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Extensions;

    public class ClassroomsController : Controller
    {
        private readonly ProjectManageStudentContext _context;

        public ClassroomsController(ProjectManageStudentContext context)
        {
            _context = context;
        }
        public bool checkSession()
        {
            var ck = false;
            string currentLogin = HttpContext.Session.GetString("currentLogin");
            var account = this._context.Account.SingleOrDefault(a => a.Email == currentLogin);
            if (currentLogin == null || account.checkRoleST())
            {
                ck = true;
            }
                return (ck);
        }
        // GET: Classrooms
        public async Task<IActionResult> Index()
        {
            if (this.checkSession())
            {
                Response.StatusCode = 403;
                return Redirect("/Authentication/Login?Url=" + WebUtility.UrlEncode(Request.GetDisplayUrl()));
            }
            return View(await _context.Classroom.ToListAsync());
        }

        // GET: Classrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (this.checkSession())
            {
                Response.StatusCode = 403;
                return Redirect("/Authentication/Login?Url=" + WebUtility.UrlEncode(Request.GetDisplayUrl()));
            }
            var classroom = await _context.Classroom.Include(s=>s.Accounts)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // GET: Classrooms/Create
        public IActionResult Create()
        {
            if (this.checkSession())
            {
                Response.StatusCode = 403;
                return Redirect("/Authentication/Login?Url=" + WebUtility.UrlEncode(Request.GetDisplayUrl()));
            }
            return View();
        }

        // POST: Classrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classroom);
        }

        // GET: Classrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (this.checkSession())
            {
                Response.StatusCode = 403;
                return Redirect("/Authentication/Login?Url=" + WebUtility.UrlEncode(Request.GetDisplayUrl()));
            }
            var classroom = await _context.Classroom.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return View(classroom);
        }

        // POST: Classrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedAt,UpdatedAt")] Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassroomExists(classroom.Id))
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
            return View(classroom);
        }

        // GET: Classrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (this.checkSession())
            {
                Response.StatusCode = 403;
                return Redirect("/Authentication/Login?Url=" + WebUtility.UrlEncode(Request.GetDisplayUrl()));
            }
            var classroom = await _context.Classroom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // POST: Classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classroom = await _context.Classroom.FindAsync(id);
            _context.Classroom.Remove(classroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classroom.Any(e => e.Id == id);
        }
    }
}
