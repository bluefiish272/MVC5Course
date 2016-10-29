using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        //透過override改寫All API的邏輯。base.All是EFRepository<Product>預設的。this.All則是取OVERRIDE後的All的方法。
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.Is刪除 == false);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public override void Delete(Product product)
        {
            //base.Delete(entity);
            product.Is刪除 = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}