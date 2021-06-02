using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Chataria.Core
{
    /// <summary>
    /// An interface for a class that can provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
