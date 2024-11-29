namespace WebSite.Models //tüm cloud işlemlerini tek bir yerden yönetebilmek için bi repostory açıuoprz
{
    public class Repository
    {
    private static readonly List<Product> _products =new();
    private static readonly List<Category> _catagories =new();

    static Repository(){
        _catagories.Add(new Category{CategoryId =1, Name="Küpe"});
        _catagories.Add(new Category{CategoryId =2, Name="Yüzük"});

        _products.Add(new Product{ProductId=1, Name="AşağıYukarı", Price=3333, Image="1.jpg", CategoryId=2});
        _products.Add(new Product{ProductId=2, Name="Blabla", Price=5555, Image="2.jpg", CategoryId=2});
        _products.Add(new Product{ProductId=3, Name="LagaLuga", Price=66666, Image="3.jpg", CategoryId=1});
        _products.Add(new Product{ProductId=4, Name="Çatpat", Price=7777, Image="4.jpg", CategoryId=1});


    }
    public static List<Product> Products{get{return _products;}}//sadece get özelliğini veriyorz verileri görüntüleyelim
     public static List<Category> Categories{get{return _catagories;}}
      public static void CreateProduct(Product entity){
            _products.Add(entity);
        }
         public static void EditProduct(Product updateProduct){
            var entity = _products.FirstOrDefault(p=>p.ProductId == updateProduct.ProductId);

            if(entity != null){
                entity.Name = updateProduct.Name;
                entity.Price = updateProduct.Price;
                entity.Image = updateProduct.Image;
                entity.CategoryId = updateProduct.CategoryId;
            }
        }
          public static void DeleteProduct(Product entitys){
            var entity = _products.FirstOrDefault(b=>b.ProductId == entitys.ProductId);
            if(entity != null){
                _products.Remove(entity);
            }
    
    }

 

}
}