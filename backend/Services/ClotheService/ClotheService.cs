using backend.Data;
using backend.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace backend.Services.ClotheService
{
    public class ClotheService : IClotheService
    {
        private readonly DataContext _context;
        public ClotheService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Clothe>>> GetAllClothes()
        {
            var serviceResponse = new ServiceResponse<List<Clothe>>();
            var dbClothes = await _context.Clothes.ToListAsync();
            serviceResponse.Data = dbClothes;
            return serviceResponse;
        }
        public async Task<ServiceResponse<Clothe>> GetClotheById(int id)
        {
            var serviceResponse = new ServiceResponse<Clothe>();
            try
            {
                var selectedClothe = await _context.Clothes.FirstOrDefaultAsync(item => item.Id == id);
                if(selectedClothe is null)
                {
                    throw new Exception($"Could'nt find the following id: {id}");
                }
                serviceResponse.Data = selectedClothe;
            }
            catch (Exception ErrorMsg)
            {
                serviceResponse.success = false;
                serviceResponse.message = ErrorMsg.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Clothe>>> AddClothe(Clothe newClothe)
        {
            Clothe CreatedClothe = new()
            {
                Name = newClothe.Name,
                Price = newClothe.Price,
                Type = newClothe.Type
            };
            _context.Clothes.Add(CreatedClothe);
            _context.SaveChanges();

            var serviceResponse = new ServiceResponse<List<Clothe>>();
            serviceResponse.Data = await _context.Clothes.ToListAsync();
            serviceResponse.message = $"The clothe with name: ({newClothe.Name}), Type: ({newClothe.Type}), Price: ({newClothe.Price})  has been added";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Clothe>>> DeleteClotheById(int id)
        {
            var serviceResponse = new ServiceResponse<List<Clothe>>();
            try
            {
                var response = await _context.Clothes.FirstOrDefaultAsync(item => item.Id == id);
                if (response is null)
                {
                    throw new Exception($"The item with id of {id} could'nt be found.");
                }
                _context.Remove(response);
                _context.SaveChanges();
                serviceResponse.Data = await _context.Clothes.ToListAsync();
                serviceResponse.message = $"The item with id of {id} has been succesfull deleted.";

            }catch(Exception ErrorMsg)
            {
                serviceResponse.success = false;
                serviceResponse.message = ErrorMsg.Message;
            }
            return serviceResponse;
        }
    }
}
