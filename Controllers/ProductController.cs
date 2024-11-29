using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using website.Data;

namespace website.Controllers
{
  public class ProductController : Controller
  {
    private readonly DataContext _context;
    public ProductController(DataContext context)
    {
      _context = context; //proje ayağa kalktığında verileri eşitle diyoruz

    }

    public async Task<IActionResult> Index()
    {
      var products = await _context.Products.ToListAsync();
      return View(products);
    }
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost] //default olarak yazdığımız actionlar gettir. Benzer başlıkta açtıklarımızda ise post işlemi için modelle alman lazım
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)//veritabanı işlemleri varsa async yapı gelir karşınaa. Aynı anda birden fazla create işlemi gerçkleşebilr
    {
      _context.Products.Add(model);
      await _context.SaveChangesAsync();
      var allowedExtensions = new[]{".jpg","png","jpeg"};

      return RedirectToAction("Index");//bulunduğu controllerın index sayfasına gider knk
    }
  
    [HttpGet] //
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      //var prd = await _context.Products.FindAsync(id);
      var prd = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
      if (prd == null)
      {
        return NotFound();
      }
      return View(prd);
    }


    [HttpPost]//form üzeindense postluyoruz
    [ValidateAntiForgeryToken]//token kontorlü için çağırıyoruz
    public async Task<IActionResult> Edit(int id, Product model)
    {

      if (id != model.ProductId)
      {
        return NotFound();
      }
      if (ModelState.IsValid)
      {
        //validasyon hatası var mı yok mu diyelimm
        try
        {
          _context.Update(model);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)//aynı anda birden fazla APİıden  veri güncelleme isteği geldiğinde devereye gir ve iptal et dedik
        {
          if (!_context.Products.Any(p => p.ProductId == model.ProductId))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction("Index");//modelstatte herhangi bir sıkıntı yoksa indexe gönderelim hocam
      }
      return View(model);
    }

    [HttpGet]//ürün bilgisini sayfaya yollayalım hcoam
    public async Task<IActionResult>Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var product = await _context.Products.FindAsync(id);
      if (product == null)
      {
        return NotFound();
      }
      return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm]int id){//Model Binding işlemi kullanırsan delete.cshtml içerisnde value yazmalısın
      var product = await _context.Products.FindAsync(id);
      if(product==null){
        return NotFound();
      }
      _context.Products.Remove(product);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");

    }

    
  }
}