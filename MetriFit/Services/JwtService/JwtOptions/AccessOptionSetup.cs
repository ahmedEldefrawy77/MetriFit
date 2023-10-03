
namespace MetriFit;
public class AccessOptionSetup : OptionSetup<AccessOptions>
{
    public AccessOptionSetup(IConfiguration configure, string SectionName = "JwtAccess") 
        : base (configure, SectionName)
    {

    }
}

