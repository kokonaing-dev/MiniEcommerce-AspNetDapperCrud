using ECommerceApp.DTOs;
using ECommerceApp.Repositories;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _service.GetCategoriesAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _service.CategoryDetailAsync(id);
        if (product == null) return NotFound();

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await _service.GetCategoriesAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = await _service.GetCategoriesAsync();
            return View(dto);
        }

        await _service.CreateCategoryAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _service.CategoryDetailAsync(id);
        if (product == null) return NotFound();

        var dto = new UpdateCategoryDto
        {
            Name = product.Name,
        };

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, UpdateCategoryDto dto)
    {
       
        await _service.UpdateCategoryAsync(id, dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _service.CategoryDetailAsync(id);
        if (product == null) return NotFound();

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteCategoryAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
