using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryProductDal : IProductDal
	{
		// in memory ama veri varmış gibi kullanacağımız için liste oluşturalım
		List<Product> _products; // class içinde methodlar dışında tanımladık, yani global değişken. bu yüzden başına alt tre eklenir.
		// proje başlayınca bir liste oluştursun istiyoruz
		public InMemoryProductDal()
		{
			_products = new List<Product> { 
				new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
				new Product{ProductId=2,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=15},
				new Product{ProductId=3,CategoryId=2,ProductName="Mouse",UnitPrice=15,UnitsInStock=15},
				new Product{ProductId=4,CategoryId=3,ProductName="Telefon",UnitPrice=1500,UnitsInStock=15},
				new Product{ProductId=5,CategoryId=3,ProductName="Kamera",UnitPrice=15000,UnitsInStock=15}
			};
		}
		public void Add(Product product)
		{
			_products.Add(product);
		}

		public void Delete(Product product)
		{
			// sadece remove ile listeden silemeyiz bu yüzden LINQ kullanıyoruz.
			// yorum satırı olan kısım LINQ kullanılmamış hali ;
			//Product productToDelete = null; // hata vermesin diye öncelikle boş gösteriyoruz.
			//foreach (var p in _products)
			//{
			//	if(product.ProductId==p.ProductId)
			//	{
			//		productToDelete = p;
			//	}
			//}
			// singleordefault foreach işini yapıyor, hepsini geziyor, p de takma isim
			Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
			_products.Remove(productToDelete);
		}

		public List<Product> GetAll()
		{
			return _products;
		}

		public List<Product> GetAllByCategory(int categoryId)
		{
			// where içindeki tüm kurallara uyanları yeni listeye ekler
			return _products.Where(p => p.CategoryId == categoryId).ToList();
		}

		public void Update(Product product)
		{
			// gönderdiğim ürün idsine sahip olan listedeki ürünü bul.
			Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
			productToUpdate.ProductName = product.ProductName;
			productToUpdate.CategoryId = product.CategoryId;
			productToUpdate.UnitPrice = product.UnitPrice;
			productToUpdate.UnitsInStock = product.UnitsInStock;
		}
	}
}
