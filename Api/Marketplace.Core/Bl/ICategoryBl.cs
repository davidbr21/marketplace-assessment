// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Model;
using Marketplace.Core.Results;

namespace Marketplace.Core.Bl;

/// <summary>
///     Contract for the Category logic
/// </summary>
public interface ICategoryBl
{
    #region Methods

    /// <summary>
    ///     Gets the categories.
    /// </summary>
    /// <returns>List of categories</returns>
    Task<IEnumerable<CategoryListResult>> GetCategoriesAsync();
    #endregion
}