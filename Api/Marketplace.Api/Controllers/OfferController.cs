// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Bl;
    using Marketplace.Core.DTOs;
    using Marketplace.Core.Model;
    using Marketplace.Core.Results;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Services for Offers
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
        #region Fields

        private readonly ILogger<OfferController> logger;

        private readonly IOfferBl offerBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="offerBl">The Offer business logic.</param>
        public OfferController(ILogger<OfferController> logger, IOfferBl offerBl)
        {
            this.logger = logger;
            this.offerBl = offerBl;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Insert new offer from body params.
        /// </summary>
        /// <returns>offer created</returns>
        [HttpPost]
        public async Task<ActionResult<Offer>> Post([FromBody] InsertOfferDTO offer)
        {
            Offer result;

            try
            {
                result = await this.offerBl.InsertOfferAsync(offer);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Get offers list with pagination.
        /// </summary>
        /// <returns>Offers</returns>
        [HttpGet]
        public async Task<ActionResult<PagedResult<OfferListResult>>> Get(int pageIndex, int pageSize)
        {
            PagedResult<OfferListResult> result;

            try
            {
                result = await this.offerBl.GetOffersAsync(pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }
        #endregion
    }
}