using EntityProjects.Data;
using Microsoft.AspNetCore.Mvc;
using EntityProjects.Models;

namespace EntityProjects.Controllers;

public class HomeController : Controller
{
    private readonly TodoContext _context;

    public HomeController(TodoContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Todos.ToList());
    }

    public IActionResult Add(Todo model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Eksik veya hatalı form.";
            return RedirectToAction("Index");
        }

        _context.Todos.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult MarkCompleted(int id)
    {
        var todo = _context.Todos.Find(id);

        if (todo != null)
        {
            todo.IsCompleted = true;
            _context.Todos.Update(todo);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult MarkUncompleted(int id)
    {
        var todo = _context.Todos.Find(id);

        if (todo != null)
        {
            todo.IsCompleted = false;
            _context.Todos.Update(todo);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var todo = _context.Todos.Find(id);

        if (todo != null)
        {
            _context.Todos.Remove(todo);
            _context.SaveChanges();

            TempData["SuccesMessage"] = "Silindi!";
        }

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var todo = _context.Todos.Find(id);

        if (todo != null)
        {
            return View(todo);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(int id, string task)
    {
        // if (!ModelState.IsValid)
        // {
        //     TempData["ErrorMessage"] = "Eksik veya hatalı form.";
        //     return RedirectToAction("Index");
        // }

        var todo = _context.Todos.Find(id);
        todo.Task = task;
        todo.UpdatedDate = DateTime.Now;
        
        // _context.Todos.Update(model);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}