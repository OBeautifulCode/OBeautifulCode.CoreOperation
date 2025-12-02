// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubtractOp.cs" company="OBeautifulCode">
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
    /// Performs a subtraction.
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class SubtractOp : ReturningOperationBase<decimal>, IModelViaCodeGen, IDeclareGetSelfValidationFailuresMethod
    {
        /// <summary>
        /// Gets or sets the left operand.
        /// </summary>
        public IReturningOperation<decimal> LeftOperand { get; set; }

        /// <summary>
        /// Gets or sets the right operand.
        /// </summary>
        public IReturningOperation<decimal> RightOperand { get; set; }

        /// <inheritdoc cref="IDeclareGetSelfValidationFailuresMethod" />
        public override IReadOnlyList<SelfValidationFailure> GetSelfValidationFailures()
        {
            var result = base.GetSelfValidationFailures().ToList();

            if (this.LeftOperand == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.LeftOperand), Invariant($"{nameof(this.LeftOperand)} is null.")));
            }

            if (this.RightOperand == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.RightOperand), Invariant($"{nameof(this.RightOperand)} is null.")));
            }

            return result;
        }
    }
}
