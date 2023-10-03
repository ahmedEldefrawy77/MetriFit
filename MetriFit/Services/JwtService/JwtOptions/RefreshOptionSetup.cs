namespace MetriFit;
public class RefreshOptionSetup : OptionSetup<RefreshOptions>
{
	public RefreshOptionSetup(IConfiguration configuration, string SectionName= "JwtRefresh") 
		: base(configuration, SectionName){ }
}
