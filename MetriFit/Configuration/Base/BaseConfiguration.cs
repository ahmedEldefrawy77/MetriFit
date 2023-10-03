namespace MetriFit;

public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
       builder.HasKey(e=> e.Id);
       builder.Property(e => e.Id).HasMaxLength(128).HasValueGenerator<GuidValueGenerator>();
    }
}
