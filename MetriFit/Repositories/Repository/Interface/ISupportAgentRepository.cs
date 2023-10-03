namespace MetriFit;

    public interface ISupportAgentRepository : INameCompinedBaseSettingRepository<SupportAgent>
    {
        Task<SupportAgent> GetAgentByMail(string mail);
        Task DeleteAgentByMail(string mail);

    }

