namespace CarAPI.Entities.Dtos.Car
{
    public class GetCarDto
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
    

        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
