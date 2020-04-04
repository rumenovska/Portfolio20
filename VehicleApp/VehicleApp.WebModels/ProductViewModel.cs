namespace VehicleApp.WebModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }

        public int OrderId { get; set; }
        public virtual OrderViewModel Order { get; set; }
    }
}