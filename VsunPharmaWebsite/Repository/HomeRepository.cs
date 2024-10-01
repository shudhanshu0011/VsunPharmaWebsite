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
    }
}
