// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Dal;
using Marketplace.Core.DTOs;
using Marketplace.Core.Model;
using Marketplace.Core.Results;

namespace Marketplace.Dal.Repositories;

public class OfferRepository : IOfferRepository
{
    #region Fields

    private readonly MarketplaceDb _context;

    #endregion

    #region Constructors

    public OfferRepository()
    {
        _context = new MarketplaceDb();
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<Offer> InsertOfferAsync(InsertOfferDTO offer)
    {
        return await _context.InsertOfferAsync(offer);
    }

    /// <inheritdoc />
    public async Task<PagedResult<OfferListResult>> GetOffersAsync(int pageIndex, int pageSize)
    {
        return await _context.GetOffersAsync(pageIndex, pageSize);
    }
    #endregion
}