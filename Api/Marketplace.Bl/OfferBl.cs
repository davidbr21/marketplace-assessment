// <copyright company="ROSEN Swiss AG">
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
using Marketplace.Core.DTOs;
using Marketplace.Core.Model;
using Marketplace.Core.Results;

namespace Marketplace.Bl;

/// <summary>
///     Users' logic
/// </summary>
/// <seealso cref="Marketplace.Core.Bl.IOfferBl" />
public class OfferBl : IOfferBl
{
    #region Fields

    private readonly IOfferRepository offerRepository;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="OfferBl" /> class.
    /// </summary>
    /// <param name="offerRepository">The user repository.</param>
    public OfferBl(IOfferRepository offerRepository)
    {
        this.offerRepository = offerRepository;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<Offer> InsertOfferAsync(InsertOfferDTO offer)
    {
        return await offerRepository.InsertOfferAsync(offer).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<PagedResult<OfferListResult>> GetOffersAsync(int pageIndex, int pageSize)
    {
        return await offerRepository.GetOffersAsync(pageIndex, pageSize).ConfigureAwait(false);
    }
    #endregion
}