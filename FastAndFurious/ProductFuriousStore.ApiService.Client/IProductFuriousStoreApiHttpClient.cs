using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.ApiService.Client
{
    public interface IProductFuriousStoreApiHttpClient
    {
        Task<IList<Product>> GetAllFromController();
        Task<IList<Product>> GetAllFromMinimalApi();
        Task DeleteFromMinimalApi(int id);
        Task DeleteFromController(int id);
    }
}