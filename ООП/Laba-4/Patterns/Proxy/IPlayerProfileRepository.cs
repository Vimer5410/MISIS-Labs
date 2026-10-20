using System;

namespace Laba_4.Patterns.Proxy
{
    public interface IPlayerProfileRepository
    {
        string GetProfileData(string playerId);
    }
}