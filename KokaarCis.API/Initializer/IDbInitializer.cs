using KokaarCis.Utility.Options;
using Microsoft.Extensions.Options;

namespace KokaarCis.Api.Initializer
{
    public interface IDbInitializer
    {
        void Initialize(bool ensureDeleted = false);
    }
}