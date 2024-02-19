﻿// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Bl;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;
using Marketplace.Core.Results;

namespace Marketplace.Bl;

/// <summary>
///     Category's logic
/// </summary>
/// <seealso cref="Marketplace.Core.Bl.ICategoryBl" />
public class CategoryBl : ICategoryBl
{
    #region Fields

    private readonly ICategoryRepository categoryRepository;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryBl" /> class.
    /// </summary>
    /// <param name="categoryRepository">The category repository.</param>
    public CategoryBl(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<IEnumerable<CategoryListResult>> GetCategoriesAsync()
    {
        return await categoryRepository.GetCategoriesAsync().ConfigureAwait(false);
    }
    #endregion
}