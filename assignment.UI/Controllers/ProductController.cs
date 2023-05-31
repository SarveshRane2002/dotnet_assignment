using assignment.data.Models.Domain;
using assignment.data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace assignment.UI.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepo;

    public ProductController(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }
    public IActionResult Add()
    {

        return View();
    }

    [HttpPost]
   [HttpPost]
public async Task<IActionResult> Add(Product product)
{
    try
    {
        if (!ModelState.IsValid)
            return View(product);
        
        bool addProductResult = await _productRepo.AddAsync(product);
        
        if (addProductResult)
                
            TempData["msg"] = "!! Successfully Added";
        else
            TempData["msg"] = "!Could Not Be Added ";
    }
    catch (Exception)
    {
        TempData["msg"] = "Could Not Be Added ";
    }
    
    return RedirectToAction(nameof(Add));
}

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        //if (product == null)
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        try
        {
            if (!ModelState.IsValid)
                return View(product);

            var updateResult = await _productRepo.UpdateAsync(product);

            if (updateResult)
            {
                TempData["msg"] = "! Updated Successfully";
                return RedirectToAction(nameof(DisplayAll));
            }
            else
            {
                TempData["msg"] = "! Could Not Be Updated ";
                return View(product);
            }
        }
        catch (Exception)
        {
            TempData["msg"] = "Could Not Be Updated ";
            return View(product);
        }

        
    }

    //public async Task<IActionResult> GetById(int id )
    //{
    //    return View();
    //}

    public async Task<IActionResult> DisplayAll()
    {
        var items = await _productRepo.GetAllAsync();
        return View(items);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var deleteResult = await _productRepo.DeleteAsync(id);
        return RedirectToAction(nameof(DisplayAll));
    }
}
