using System.Text.Json.Serialization;

namespace MetriFit;

public  class User  : BaseEntitySettingNameCompind
{

    public string? DisplayName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    public double Height { get; set; }

    public double Weight { get; set; }

    public string? Gender { get; set; }

    public double WaistCircumference { get; set; }

    public double NeckCircumference { get; set; }

    public double? HipCircumference { get; set; }

    public double? BodyFat { get; set; }

    public double? LeanerBodyMass { get; set; }

    public double? BasalMetabolicRate { get; set; }

    public double? BmrafterActivityLevel { get; set; }

    public DateTime LastMeasurmentsEntryDate { get; set; }

    public ICollection<TotalCaloriesPerDay>? TotalCal { get; set; }

    public string? ActivityType { get; set; }

    public string? Role { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public  ICollection<Exercise>? Exercise { get; set; } = new List<Exercise>();

    public  Goal? Goal { get; set; }

    public  ICollection<MealLog>? MealLog { get; set; }

    public string? PhoneNumber { get; set; }
    [JsonIgnore]
    public RefreshToken RefreshToken { get; set; } = new RefreshToken();
    [JsonIgnore]
    public ICollection<UsersNutritions>? UsersNutritions { get; set; }
}