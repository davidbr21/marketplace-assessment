// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System;

namespace Marketplace.Core.Results;

public class OfferListResult
{
    #region Properties

    /// <summary>
    ///     Gets or sets the category identifier.
    /// </summary>
    /// <value>
    ///     The category identifier.
    /// </value>
    public byte CategoryId { get; set; }

    /// <summary>
    ///     Gets or sets the category name.
    /// </summary>
    /// <value>
    ///     The category name.
    /// </value>
    public string CategoryName { get; set; }

    /// <summary>
    ///     Gets or sets the description.
    /// </summary>
    /// <value>
    ///     The description.
    /// </value>
    public string Description { get; set; }

    /// <summary>
    ///     Gets or sets the location.
    /// </summary>
    /// <value>
    ///     The location.
    /// </value>
    public string Location { get; set; }

    /// <summary>
    ///     Gets or sets the picture URL.
    /// </summary>
    /// <value>
    ///     The picture URL.
    /// </value>
    public string PictureUrl { get; set; }

    /// <summary>
    ///     Gets or sets the title.
    /// </summary>
    /// <value>
    ///     The title.
    /// </value>
    public string Title { get; set; }

    /// <summary>
    ///     Gets or sets the user identifier.
    /// </summary>
    /// <value>
    ///     The user identifier.
    /// </value>
    public int UserId { get; set; }

    /// <summary>
    ///     Gets or sets the user name.
    /// </summary>
    /// <value>
    ///     The user name.
    /// </value>
    public string UserName { get; set; }

    /// <summary>
    ///     Gets or sets the published on.
    /// </summary>
    /// <value>
    ///     The published on.
    /// </value>
    public DateTime PublishedOn { get; set; } = DateTime.Now;

    #endregion
}