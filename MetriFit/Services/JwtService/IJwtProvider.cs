namespace MetriFit;
    public interface IJwtProvider
    {
        string GetAccessToken(User user);
        string GetRefreshtoken();
    }

