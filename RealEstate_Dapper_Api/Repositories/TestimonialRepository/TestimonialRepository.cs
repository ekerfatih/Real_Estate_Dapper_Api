using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository {
    public class TestimonialRepository : ITestimonialRepository {

        private readonly Context _context;

        public TestimonialRepository(Context context) {
            _context = context;
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync() {
            string query = "Select * from Testimonial";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }

        }
    }
}
