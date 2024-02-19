﻿// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.DTOs;
using Marketplace.Core.Model;
using Marketplace.Core.Results;

namespace Marketplace.Dal;

public interface IMarketplaceDb
{
    Task<User[]> GetUsersAsync();

    Task<int> InsertUserAsync(InsertUserDTO user);

    Task<User> GetUserByUserNameAsync(string username);

    Task<Offer> InsertOfferAsync(InsertOfferDTO offer);

    Task<PagedResult<OfferListResult>> GetOffersAsync(int pageIndex, int pageSize);

    Task<CategoryListResult[]> GetCategoriesAsync();
}