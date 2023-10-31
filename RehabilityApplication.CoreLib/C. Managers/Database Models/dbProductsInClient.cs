namespace RehabilityApplication.CoreLib
{
    public class dbProductsInClient
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string Title { get; set; }

        //public string ProductId { get; set; }
        public string DirectionNumber { get; set; }
        public int Count { get; set; }
        public bool IsGived { get; set; }
        public dbProductsInClient() { }
    }
}