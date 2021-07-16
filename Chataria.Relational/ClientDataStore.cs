using Chataria.Core;
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
        #region Public Properties

        public bool HasCredentials => throw new System.NotImplementedException();

        #endregion

        #region Interface Implementation

        public Task EnsureDataStoreAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<LoginCredentialsDataModel> GetLoginCredentials()
        {
            throw new System.NotImplementedException();
        }

        public Task SaveLoginCredentials(LoginCredentialsDataModel loginCredentials)
        {
            throw new System.NotImplementedException();
        } 

        #endregion
    }
}
