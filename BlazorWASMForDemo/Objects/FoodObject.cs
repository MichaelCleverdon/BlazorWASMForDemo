namespace BlazorWASMForDemo.Objects
{
    public class FoodObject
    {
        public FoodObject(string username, string name, int quantity = 0)
        {
            Username = username;
            Name = name;
            Quantity = quantity;
        }

        public string Username { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
