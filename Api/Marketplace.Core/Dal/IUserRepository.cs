// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System.Threading.Tasks;
using Marketplace.Core.DTOs;
using Marketplace.Core.Model;

namespace Marketplace.Core.Dal;

/// <summary>
///     Contract for the User data access
/// </summary>
public interface IUserRepository
{
    #region Methods

    /// <summary>
    ///     Gets all users asynchronous.
    /// </summary>
    /// <returns>Array of users</returns>
    Task<User[]> GetAllUsersAsync();

    /// <summary>
    ///     Insert user asynchronous.
    /// </summary>
    /// <returns>User created</returns>
    Task<int> InsertUserAsync(InsertUserDTO user);

    /// <summary>
    ///     Get single user asynchronous.
    /// </summary>
    /// <returns>User</returns>
    Task<User> GetUserByUserNameAsync(string username);
    #endregion
}