namespace MetriFit;
    public class UsersNutritions
    {
        public User? Users { get; set; }
        public Guid UserId { get; set; }
        public NutritionInformation? NutritionInformation { get; set; }
        public Guid NutritionInfortmationId { get; set; }
    }
