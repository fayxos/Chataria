using Chataria.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Chataria.Relational
{
    /// <summary>
    /// Stores and retrieves information about the client application
    /// such as login credentials, messages, settings and so on
    /// in a SQLite Database
    /// </summary>
    public class ClientDataStore : IClientDataStore
    {
        #region Protected Members

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected ClientDataStoreDbContext mDbContest;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public ClientDataStore(ClientDataStoreDbContext dbContext)
        {
            // Set local member
            mDbContest = dbContext;
        }

        #endregion

        #region Interface Implementation

        public async Task<bool> HasCredentials()
        {
            return await GetLoginCredentialsAsync() != null;
        }

        public async Task EnsureDataStoreAsync()
        {
            // Make sure the database exists and is created
            await mDbContest.Database.EnsureCreatedAsync();
        }

        public Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {
            // Get the first column in the login credentials table, or null if none exists
            return Task.FromResult(mDbContest.LoginCredentials.FirstOrDefault());
        }

        public async Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials)
        {
            // Clear all entries
            mDbContest.LoginCredentials.RemoveRange(mDbContest.LoginCredentials);

            // Add new one
            mDbContest.LoginCredentials.Add(loginCredentials);

            // Save changes
            await mDbContest.SaveChangesAsync();
        }

        #endregion
    }
}
