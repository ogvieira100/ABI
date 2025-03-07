using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Security
{
    public interface IPasswordHasher
    {
        /// <summary>
        /// Hashes a plain text password using a secure hashing algorithm.
        /// </summary>
        /// <param name="password">The plain text password to hash.</param>
        /// <returns>The hashed password.</returns>
        string HashPassword(string password);

        /// <summary>
        /// Verifies if a plain text password matches a hashed password.
        /// </summary>
        /// <param name="password">The plain text password to verify.</param>
        /// <param name="hash">The hashed password to compare against.</param>
        /// <returns>True if the password matches the hash, false otherwise.</returns>
        bool VerifyPassword(string password, string hash);
    }
}
