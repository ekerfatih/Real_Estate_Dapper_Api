using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductRepository {
    public interface ILast5ProductRepository {
        public Task<List<ResultLast5RentProductWithCategoryDto>> GetLast5RentedProduct(int id);
    }
}
