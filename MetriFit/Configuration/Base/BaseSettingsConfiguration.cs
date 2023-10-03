namespace MetriFit;
    public class BaseSettingsConfiguration<TEntity> : BaseConfiguration<TEntity>, IEntityTypeConfiguration<TEntity> 
    where TEntity : BaseEntitySettings
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
        }
    }

