namespace MetriFit;
public class SupportAgentRepository : NameCompinedBaseSettingRepository<SupportAgent>, ISupportAgentRepository
{

    public SupportAgentRepository(ApplicationDbContext context) : base(context){}

    public async Task DeleteAgentByMail(string mail)
    {
       SupportAgent? agent = await GetAgentByMail(mail);
        await Task.Run(()=> _dbSet.Remove(agent));
        await SaveChangesAsync();

    }

    public async Task<SupportAgent> GetAgentByMail(string mail)
    {
        SupportAgent? agent = await _dbSet.FirstOrDefaultAsync(e => e.Email == mail);
        if (agent == null)
            throw new ArgumentNullException(nameof(agent));

        return agent;
    }
}

