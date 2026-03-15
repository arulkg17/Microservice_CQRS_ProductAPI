namespace ProductAPI.Domain;
    public class Product
    {
        public int Id { get; set; }         // PK
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
    }

