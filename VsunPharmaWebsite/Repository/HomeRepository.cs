using Dapper;
using System.Data;
using VsunPharmaWebsite.DapperContexts;
using VsunPharmaWebsite.IRepository;
using VsunPharmaWebsite.Models;

namespace VsunPharmaWebsite.Repository
{
	public class HomeRepository: IHomeRepository
	{
		private readonly DapperContext _dapperContext;

		public HomeRepository(DapperContext context)
		{
			_dapperContext = context;
		}

		public IEnumerable<ProductCategoryModel> GetProductCategory()
		{
			using (var context = _dapperContext.CreateConnection())
			{
				var Data = context.Query<ProductCategoryModel>("GetProductCategoryData", commandType: CommandType.StoredProcedure);
				return Data;
			}
		}

        public IEnumerable<ProductModel> GetAllProducts()
		{
            using (var context = _dapperContext.CreateConnection())
            {
                var Data = context.Query<ProductModel>("GetAllProducts", commandType: CommandType.StoredProcedure);
                return Data;
            }
        }

        public UsersModel LoginUser(LoginModel user)
        {
            using (var context = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("EEmailID", user.EmailID);
                parameters.Add("PPassword", user.Password);
                UsersModel res = context.QueryFirstOrDefault<UsersModel>("Login", parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public void RegisterUser(UsersModel user)
        {
            using (var context = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("NName", user.Name);
                parameters.Add("EEmail", user.Email);
                parameters.Add("PPhone", user.Phone);
                parameters.Add("PPassword", user.Password);

                context.Execute("RegisterUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void SaveChanges(ProductModel product, string action)
        {
            using (var context = _dapperContext.CreateConnection())
            {
                var parameters = new DynamicParameters();

                if (action == "Edit")
                {
                    parameters.Add("ProductId", product.ProductId);
                    parameters.Add("ProductName", product.ProductName);
                    parameters.Add("Brand", product.Brand);
                    parameters.Add("RegularPrice", product.RegularPrice);
                    parameters.Add("DiscountedPrice", product.DiscountedPrice);
                    parameters.Add("SKU", product.SKU);
                    parameters.Add("Category", product.Category);
                    parameters.Add("IsAvailable", product.IsAvailable);
                    parameters.Add("ProductDescription", product.ProductDescription);
                    parameters.Add("Quantity", product.Quantity);

                    context.Execute("UpdateProduct", parameters, commandType: CommandType.StoredProcedure);
                }
                else if (action == "Delete")
                {
                    parameters.Add("ProductId", product.ProductId);

                    context.Execute("DeleteProduct", parameters, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}
