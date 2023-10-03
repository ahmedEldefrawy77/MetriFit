namespace MetriFit;

public partial class NutritionInformation : BaseEntitySettings
{
    public int Calories { get; set; }

    public int Protien { get; set; }

    public int Fat { get; set; }

    public int Carbonhydrate { get; set; }

    public string? MealPicture { get; set; }

    public Guid UserId { get; set; }

    public DateTime? Date { get; set; }

    public  ICollection<User>? User { get; set; } 
    public ICollection<UsersNutritions>? UserNutritions { get; set; }
}