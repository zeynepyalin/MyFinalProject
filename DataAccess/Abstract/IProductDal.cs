using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IProductDal
	{
		// product ile ilgili veritabanında yapılacak operasyonların olduğu yer
		List<Product> GetAll(); // hepsini getir
		void Add(Product product);
		void Delete(Product product);
		void Update(Product product);

		// kategoriye göre listele
		List<Product> GetAllByCategory(int categoryId);
	}
}
