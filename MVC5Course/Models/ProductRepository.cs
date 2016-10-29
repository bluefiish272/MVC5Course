using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        //�z�Loverride��gAll API���޿�Cbase.All�OEFRepository<Product>�w�]���Cthis.All�h�O��OVERRIDE�᪺All����k�C
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.Is�R�� == false);
        }
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public override void Delete(Product product)
        {
            //base.Delete(entity);
            product.Is�R�� = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}