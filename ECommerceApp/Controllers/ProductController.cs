using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

using ECommerceApp.DTOs;
using Microsoft.AspNetCore.Mvc;
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProductsAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.ProductDetailAsync(id);
        if (product == null) return NotFound();

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await _categoryService.GetCategoriesAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View(dto);
        }

        await _productService.CreateProductAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.ProductDetailAsync(id);
        if (product == null) return NotFound();

        var dto = new UpdateProductDto
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId
        };

        ViewBag.Categories = await _categoryService.GetCategoriesAsync();
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, UpdateProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View(dto);
        }

        await _productService.UpdateProductAsync(id, dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.ProductDetailAsync(id);
        if (product == null) return NotFound();

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

