namespace backend.Models
{
    public class Clothe
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Sommar T-Shirt";
        public ClotheType Type { get; set; } = ClotheType.Top;
        public int Price { get; set; } = 100;
    }
}
