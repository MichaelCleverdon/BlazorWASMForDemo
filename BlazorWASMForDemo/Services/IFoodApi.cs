using BlazorWASMForDemo.Objects;

namespace BlazorWASMForDemo.Services
{
    public interface IFoodApi
    {
        Task<List<FoodObject>> GetAllFoodObjects(string userName);
        Task<FoodObject> GetFoodObject(string userName, string name);
        Task<FoodObject> UpdateFoodObject(string userName, FoodObject foodObject);
        Task<FoodObject> DeleteFoodObject(string userName, FoodObject name);
    }
}
