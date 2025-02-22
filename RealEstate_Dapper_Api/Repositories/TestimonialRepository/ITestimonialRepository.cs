using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync();
        // void CreateService(CreateServiceDto createServiceDto);
        // void DeleteService(int id);
        // void UpdateService(UpdateServiceDto updateServiceDto);
        // Task<GetByIdServiceDto> GetServiceById(int id);
    }
}
