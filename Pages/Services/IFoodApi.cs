using RazorComponentLibrary.Objects;

namespace RazorComponentLibrary.Services
{
    public interface IFoodApi
    {
        Task<List<FoodObject>> GetAllFoodObjects();
        Task<FoodObject> GetFoodObject(string name);
        Task<FoodObject> CreateOrUpdateFoodObject(FoodObject foodObject);
        Task<FoodObject> DeleteFoodObject(FoodObject foodObject);
    }
}
