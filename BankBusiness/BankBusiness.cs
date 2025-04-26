using BankData;
using BankData.Models;

namespace BankBusiness
{

    /// <summary>
    /// Business Logic of the App (CRUD operations)
    /// </summary>
    public class BankBusiness
    {
        private BankContext bankContext = null;

        /// <summary>
        /// Get all producst from the database
        /// </summary>
        public List<Customer> GetAll()
        {
            using (bankContext = new ProductContext())
            {
                return bankContext.Products.ToList();
            }
        }

        /// <summary>
        /// Get single product from the database by Id
        /// </summary>
        public Product Get(int id)
        {
            using (bankContext = new ProductContext())
            {
                return bankContext.Products.Find(id);
            }
        }

        /// <summary>
        /// Add a product to the database
        /// </summary>
        public void Add(Product product)
        {
            using (bankContext = new ProductContext())
            {
                bankContext.Products.Add(product);
                bankContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update a single product in the database by Id.
        /// </summary>
        public void Update(Product product)
        {
            using (bankContext = new ProductContext())
            {
                var item = bankContext.Products.Find(product.Id);
                if (item != null)
                {
                    bankContext.Entry(item).CurrentValues.SetValues(product);
                    bankContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deleate a product from the database by Id
        /// </summary>
        public void Delete(int id)
        {
            using (bankContext = new ProductContext())
            {
                var product = bankContext.Products.Find(id);
                if (product != null)
                {
                    bankContext.Products.Remove(product);
                    bankContext.SaveChanges();
                }
            }
        }
    }
}
