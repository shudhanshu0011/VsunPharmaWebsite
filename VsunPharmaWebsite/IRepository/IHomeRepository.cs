using VsunPharmaWebsite.Models;

namespace VsunPharmaWebsite.IRepository
{
	public interface IHomeRepository
	{
		public IEnumerable<ProductCategoryModel> GetProductCategory(); 

        public IEnumerable<ProductModel> GetAllProducts();

        public UsersModel LoginUser(LoginModel user);

        public void RegisterUser(UsersModel user);

        public void SaveChanges(ProductModel product, string action);
    }
}
