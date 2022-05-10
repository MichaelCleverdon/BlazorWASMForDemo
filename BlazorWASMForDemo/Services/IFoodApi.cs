using BlazorWASMForDemo.Objects;

namespace BlazorWASMForDemo.Services
{
    public interface IFoodApi
    {
        Task<List<FoodObject>> GetAllFoodObjects();
        Task<FoodObject> GetFoodObject(string name);
        Task<FoodObject> CreateOrUpdateFoodObject(FoodObject foodObject);
        Task<FoodObject> DeleteFoodObject(FoodObject foodObject);
    }
}
