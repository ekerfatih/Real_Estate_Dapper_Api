using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository {
    public class PropertyAmenityRepository : IPropertyAmenityRepository {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context) {
            _context = context;
        }
        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id) {
            string sql = @"Select PropertyAmenityId,Title from PropertyAmenity inner join Amenity on Amenity.AmenityId = PropertyAmenity.AmenityId where PropertyId = @propertyId and Status=1";
            DynamicParameters parameters = new();
            parameters.Add("@propertyId", id);
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(sql, parameters);
                return values.ToList();
            }
        }
    }
}
