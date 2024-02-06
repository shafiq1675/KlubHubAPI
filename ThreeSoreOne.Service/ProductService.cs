using ThreeStoreOne.Model;
using ThreeStoreOne.Repo;

namespace ThreeStoreOne.Service
{
    public interface IProductService
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProduct();
    }
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            try
            {
                product.ProductId = Guid.NewGuid().ToString();
                _productRepository.AddProduct(product);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _productRepository.GetAllProduct();
        }
    }
}
