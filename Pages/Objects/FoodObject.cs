namespace RazorComponentLibrary.Objects
{
    public class FoodObject
    {
        public FoodObject() { }
        public FoodObject(string username, string name, uint quantity = 0)
        {
            Username = username;
            Name = name;
            Quantity = quantity;
        }

        public string Username { get; set; }
        public string Name { get; set; }
        public uint Quantity { get; set; }
    }
}
