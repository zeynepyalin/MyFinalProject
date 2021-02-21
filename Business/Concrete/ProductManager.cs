using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		// soyut olarak çözeceğiz, in memory ve entity framework adları geçmeden, sonradan baska yöntem eklenirse zorlanmamak için
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public List<Product> GetAll()
		{
			// iş kodları 
			return _productDal.GetAll();
		}
	}
}
