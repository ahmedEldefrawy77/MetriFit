namespace MetriFit;
public class UserConfiguration  : BaseEntitySettingsNameCompindConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        var Options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        builder.Property(e => e.DisplayName).HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

        builder.Property(e => e.Email).IsRequired().HasMaxLength(40);

        builder.Property(e => e.Password).IsRequired().HasMaxLength(int.MaxValue);

        builder.Property(e => e.DateOfBirth).IsRequired();

        builder.Property(e => e.Height).IsRequired().HasMaxLength(4);

        builder.Property(e => e.NeckCircumference).IsRequired();

        builder.Property(e => e.WaistCircumference).IsRequired();

        builder.Property(e => e.Gender).IsRequired().HasMaxLength(6);

        builder.Property(e => e.Weight).IsRequired().HasMaxLength(4);

        builder.Property(e => e.ActivityType).IsRequired();

        builder.Property(e => e.Role).IsRequired().HasDefaultValue("User").HasMaxLength(5).ValueGeneratedOnAdd();

        builder.HasIndex(e => e.Email).IsUnique();

        builder.HasOne(e => e.RefreshToken).WithOne(e => e.User).HasForeignKey<RefreshToken>(e => e.UserId);
      
       
    }
}
