using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Name);
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        // adiciona o produto em memória
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }


        public void RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        //método p gravar p base dados td q está pendente
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }



        public bool ProductsExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }

}
