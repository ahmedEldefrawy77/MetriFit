namespace MetriFit;
    public class BaseEntitySettingsNameCompindConfiguration<TEntity> : BaseConfiguration<TEntity>, IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntitySettingNameCompind
    {
        public override void Configure ( EntityTypeBuilder<TEntity> builder)
        {
            base.Configure (builder);
            builder.Property(e=>e.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(15);
        }
    }
