namespace ConsoleApp2
{
    public class Phone
    {
        public string Model { get; set; }
        public string OperationSystemType { get; set; }
        public string MarketLaunchDate { get; set; }
        public string Price { get; set; }
        public bool IsAvailable { get; set; }
        public int ShopId { get; set; }
        public string DisplayPhone()
        {
            return $"Model : {Model},\nOperation system type : {OperationSystemType},\nMarket launch date : {MarketLaunchDate},\nPrice : {Price},\nIs Available : {IsAvailable},\nShop Id : {ShopId}.";
        }
    }
}
