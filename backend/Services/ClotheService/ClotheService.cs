using backend.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace backend.Services.ClotheService
{
    public class ClotheService : IClotheService
    {
        List<Clothe> _clotheList = new List<Clothe>()
        {
            new Clothe(),
            new Clothe(){Name = "Kappa", Id = 1},
            new Clothe(){Name = "Alpachino", Id = 2}
        };
        public async Task<ServiceResponse<List<Clothe>>> GetAllClothes()
        {
            var serviceResponse = new ServiceResponse<List<Clothe>>();
            serviceResponse.Data = _clotheList;
            return serviceResponse;
        }
        public async Task<ServiceResponse<Clothe>> GetClotheById(int id)
        {
            var serviceResponse = new ServiceResponse<Clothe>();
            try
            {
                var selectedClothe = _clotheList.FirstOrDefault(item => item.Id == id);
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
            Clothe IncomingClothe = new()
            {
                Id = _clotheList.Max(item => item.Id) + 1,
                Name = newClothe.Name,
                Price = newClothe.Price,
                Type = newClothe.Type
            };
            _clotheList.Add(IncomingClothe);
            var serviceResponse = new ServiceResponse<List<Clothe>>();
            serviceResponse.Data = _clotheList;
            serviceResponse.message = $"The clothe with id: {newClothe.Id} and name: {newClothe.Name} has been added";
            //Save here to
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Clothe>>> DeleteClotheById(int id)
        {
            var serviceResponse = new ServiceResponse<List<Clothe>>();
            try
            {
                var response = _clotheList.FirstOrDefault(item => item.Id == id);
                if(response is null)
                {
                    throw new Exception($"The item with id of {id} could'nt be found.");
                }
                _clotheList.Remove(response);
                serviceResponse.Data = _clotheList;

            }catch(Exception ErrorMsg)
            {
                serviceResponse.success = false;
                serviceResponse.message = ErrorMsg.Message;
            }
            return serviceResponse;
        }
    }
}
