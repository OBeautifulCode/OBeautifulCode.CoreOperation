// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DivideOp.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using System.Collections.Generic;
    using System.Linq;
    using OBeautifulCode.Type;
    using static System.FormattableString;

    /// <summary>
    /// Performs a division.
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class DivideOp : ReturningOperationBase<decimal>, IModelViaCodeGen, IDeclareGetSelfValidationFailuresMethod
    {
        /// <summary>
        /// Gets or sets the numerator.
        /// </summary>
        public IReturningOperation<decimal> Numerator { get; set; }

        /// <summary>
        /// Gets or sets the denominator.
        /// </summary>
        public IReturningOperation<decimal> Denominator { get; set; }

        /// <inheritdoc cref="IDeclareGetSelfValidationFailuresMethod" />
        public override IReadOnlyList<SelfValidationFailure> GetSelfValidationFailures()
        {
            var result = base.GetSelfValidationFailures().ToList();

            if (this.Numerator == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Numerator), Invariant($"{nameof(this.Numerator)} is null.")));
            }

            if (this.Denominator == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Denominator), Invariant($"{nameof(this.Denominator)} is null.")));
            }

            return result;
        }
    }
}