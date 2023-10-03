namespace MetriFit;
 public class RefreshTokenConfiguration :BaseConfiguration<RefreshToken>
 {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            base.Configure(builder);

            builder.Property(e=> e.CreatedAt ).IsRequired();
            builder.Property(e=> e.ExpiredAt).IsRequired();
            builder.Property(e=> e.Value).IsRequired().HasMaxLength(128);

        }
 }
