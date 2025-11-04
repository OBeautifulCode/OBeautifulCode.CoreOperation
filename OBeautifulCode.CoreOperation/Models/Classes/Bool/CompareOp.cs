// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareOp.cs" company="OBeautifulCode">
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
    /// Performs a comparison.
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class CompareOp : ReturningOperationBase<bool>, IModelViaCodeGen, IDeclareGetSelfValidationFailuresMethod
    {
        /// <summary>
        /// Gets or sets the value to the left of the <see cref="Operator"/>.
        /// </summary>
        public IReturningOperation<decimal> Left { get; set; }

        /// <summary>
        /// Gets or sets the comparison operator to use.
        /// </summary>
        public IReturningOperation<CompareOperator> Operator { get; set; }

        /// <summary>
        /// Gets or sets the value to the right of the <see cref="Operator"/>.
        /// </summary>
        public IReturningOperation<decimal> Right { get; set; }

        /// <inheritdoc cref="IDeclareGetSelfValidationFailuresMethod" />
        public override IReadOnlyList<SelfValidationFailure> GetSelfValidationFailures()
        {
            var result = base.GetSelfValidationFailures().ToList();

            if (this.Left == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Left), Invariant($"{nameof(this.Left)} is null.")));
            }

            if (this.Operator == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Operator), Invariant($"{nameof(this.Operator)} is null.")));
            }

            if (this.Right == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Right), Invariant($"{nameof(this.Right)} is null.")));
            }

            return result;
        }
    }
}