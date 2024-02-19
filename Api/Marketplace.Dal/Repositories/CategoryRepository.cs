// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System.Threading.Tasks;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;
using Marketplace.Core.Results;

namespace Marketplace.Dal.Repositories;

public class CategoryRepository : ICategoryRepository
{
    #region Fields

    private readonly MarketplaceDb _context;

    #endregion

    #region Constructors

    public CategoryRepository()
    {
        _context = new MarketplaceDb();
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<CategoryListResult[]> GetCategoriesAsync()
    {
        return await _context.GetCategoriesAsync();
    }
    #endregion
}