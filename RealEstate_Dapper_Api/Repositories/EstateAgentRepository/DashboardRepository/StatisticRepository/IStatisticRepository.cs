namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository {
    public interface IStatisticRepository {

        Task<int> ProductCountByEmployeeId(int id);
        Task<int> ProductCountByStatusTrue(int id);
        Task<int> ProductCountByStatusFalse(int id);
        Task<int> AllProductCount();
    }
}
