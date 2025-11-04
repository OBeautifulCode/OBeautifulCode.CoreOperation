// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IfThenElseOp{TResult}.cs" company="OBeautifulCode">
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
    /// Performs an if/then/else.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class IfThenElseOp<TResult> : ReturningOperationBase<TResult>, IModelViaCodeGen, IDeclareGetSelfValidationFailuresMethod
    {
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        public IReturningOperation<bool> Condition { get; set; }

        /// <summary>
        /// Gets or sets the statement to execute if the condition is true.
        /// </summary>
        public IReturningOperation<TResult> Statement { get; set; }

        /// <summary>
        /// Gets or sets the statement to execute if the condition is false.
        /// </summary>
        public IReturningOperation<TResult> ElseStatement { get; set; }

        /// <inheritdoc cref="IDeclareGetSelfValidationFailuresMethod" />
        public override IReadOnlyList<SelfValidationFailure> GetSelfValidationFailures()
        {
            var result = base.GetSelfValidationFailures().ToList();

            if (this.Condition == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Condition), Invariant($"{nameof(this.Condition)} is null.")));
            }

            if (this.Statement == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Statement), Invariant($"{nameof(this.Statement)} is null.")));
            }

            if (this.ElseStatement == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.ElseStatement), Invariant($"{nameof(this.ElseStatement)} is null.")));
            }

            return result;
        }
    }
}
