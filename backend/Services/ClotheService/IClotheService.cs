using backend.Models;

namespace backend.Services.ClotheService
{
    public interface IClotheService
    {
        Task<ServiceResponse<List<Clothe>>> GetAllClothes();
        Task<ServiceResponse<Clothe>> GetClotheById(int id);
        Task<ServiceResponse<List<Clothe>>> AddClothe(Clothe newClothe);
        Task<ServiceResponse<List<Clothe>>> DeleteClotheById(int id);
    }
}
