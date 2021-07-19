using Chataria.Core;
using Dna;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chataria.Relational
{
    /// <summary>
    /// Extension methods for the <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public static FrameworkConstruction UseClientDataStore(this FrameworkConstruction construction)
        {
            // Inject our SQLíte EF data store
            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                // Setup connection string
                options.UseSqlite(construction.Configuration.GetConnectionString("ClientDataStoreConnection"));
            }, contextLifetime: ServiceLifetime.Transient);

            // Add client data store for easy access/use of the backing data store
            // Make it scoped so we can inject the scoped DbContext
            construction.Services.AddTransient<IClientDataStore>(
                provider => new ClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            // Return Framework for chaining
            return construction;
        }
    }
}
