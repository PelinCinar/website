using Microsoft.AspNetCore.Mvc;
using website.Data;

namespace website.Controllers
{
  public class BlogController : Controller
  {
    private readonly DataContext _context;
    public BlogController(DataContext context)
    {
      _context = context; //proje ayağa kalktığında verileri eşitle diyoruz

    }
   
        public IActionResult Create()
    {
      return View();
    }

    [HttpPost] //default olarak yazdığımız actionlar gettir. Benzer başlıkta açtıklarımızda ise post işlemi için modelle alman lazım
    public async Task<IActionResult> Create(Blog model)//veritabanı işlemleri varsa async yapı gelir karşınaa. Aynı anda birden fazla create işlemi gerçkleşebilr
    {
      _context.Blogs.Add(model);
      await _context.SaveChangesAsync();

      return RedirectToAction("Index","Home");
    }
  }
}