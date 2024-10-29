using UniPlatform.DB.Entities;

namespace UniPlatform.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);

    }
}
