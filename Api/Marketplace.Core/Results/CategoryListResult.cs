// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System;

namespace Marketplace.Core.Results;

public class CategoryListResult
{
    #region Properties

    /// <summary>
    ///     Gets or sets the category identifier.
    /// </summary>
    /// <value>
    ///     The category identifier.
    /// </value>
    public byte Id { get; set; }

    /// <summary>
    ///     Gets or sets the category name.
    /// </summary>
    /// <value>
    ///     The category name.
    /// </value>
    public string Name { get; set; }
    #endregion
}