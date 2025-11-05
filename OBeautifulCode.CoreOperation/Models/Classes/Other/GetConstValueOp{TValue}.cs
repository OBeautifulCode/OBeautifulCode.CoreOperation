// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetConstValueOp{TValue}.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using System.Collections.Generic;
    using OBeautifulCode.Type;

    /// <summary>
    /// Gets a specified fixed value.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    public partial class GetConstValueOp<TValue> : ReturningOperationBase<TValue>, IDeclareGetSelfValidationFailuresMethod
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public TValue Value { get; set; }

        /// <inheritdoc cref="IDeclareGetSelfValidationFailuresMethod" />
        public override IReadOnlyList<SelfValidationFailure> GetSelfValidationFailures()
        {
            var result = base.GetSelfValidationFailures();

            return result;
        }
    }
}