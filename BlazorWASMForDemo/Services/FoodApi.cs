using BlazorWASMForDemo.Objects;

namespace BlazorWASMForDemo.Services
{
    public class FoodApi : IFoodApi
    {
        private List<FoodObject> tempList = new List<FoodObject>()
        {
            new FoodObject("michaelcleverdon@u.boisestate.edu", "8oz Can of Corn", 5),
            new FoodObject("michaelcleverdon@u.boisestate.edu", "12oz Can of Tomato w/ Green Chiles", 8),
            new FoodObject("michaelcleverdon@u.boisestate.edu", "8oz Can of Black Beans", 50),
            new FoodObject("michaelcleverdon@u.boisestate.edu", "8oz Can of Pinto Beans", 9),
            new FoodObject("michaelcleverdon@u.boisestate.edu", "10oz Can of Green Beans", 15),
            new FoodObject("michaelcleverdon@u.boisestate.edu", "1lb Bag of Flour", 12),
            new FoodObject("michaelcleverdon@u.boisestate.edu", "Ramen Packets - Chicken Flavor", 16),
            new FoodObject("michaelcleverdon@u.boisestate.edu", "Funfetti Birthday Cake Mix", 1),
            new FoodObject("kevin", "Funfetti Birthday Cake Mix", 1),
            new FoodObject("kevin", "Funfetti Birthday Cake Mix", 1),
            new FoodObject("kevin", "Funfetti Birthday Cake Mix", 1),
            new FoodObject("kevin", "Funfetti Birthday Cake Mix", 1),
            new FoodObject("kevin", "Funfetti Birthday Cake Mix", 1),
            new FoodObject("kevin", "Funfetti Birthday Cake Mix", 1),
            new FoodObject("kevin", "Funfetti Birthday Cake Mix", 1),
        };
        public Task<List<FoodObject>> GetAllFoodObjects(string userName)
        {
            Console.WriteLine(userName);
            return Task.Run(() => tempList.Where(fo => fo.Username == userName).ToList());
        }

        public Task<FoodObject> GetFoodObject(string userName, string name)
        {
            throw new NotImplementedException();
        }

        public Task<FoodObject> UpdateFoodObject(string userName, FoodObject foodObject)
        {
            throw new NotImplementedException();
        }

        public Task<FoodObject> DeleteFoodObject(string userName, FoodObject food)
        {
            throw new NotImplementedException();
        }
    }
}
