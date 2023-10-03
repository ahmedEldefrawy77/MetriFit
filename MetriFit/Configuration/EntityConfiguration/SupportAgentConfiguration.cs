namespace MetriFit;

    public class SupportAgentConfiguration : BaseEntitySettingsNameCompindConfiguration<SupportAgent>

    {
        public override void Configure(EntityTypeBuilder<SupportAgent> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(e => e.Password)
                .IsRequired();
        }
    }

