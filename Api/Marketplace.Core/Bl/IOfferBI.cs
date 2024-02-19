// <copyright company="ROSEN Swiss AG">
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

namespace Marketplace.Core.Bl;

/// <summary>
///     Contract for the Pffer logic
/// </summary>
public interface IOfferBl
{
    #region Methods

    /// <summary>
    ///     Insert offer asynchronous.
    /// </summary>
    /// <returns>Offer created</returns>
    Task<Offer> InsertOfferAsync(InsertOfferDTO offer);

    /// <summary>
    ///     Get offer list asynchronous with pagination params
    /// </summary>
    /// <returns>Offer List with given pagination parameters</returns>
    Task<PagedResult<OfferListResult>> GetOffersAsync(int pageIndex, int pageSize);
    #endregion
}