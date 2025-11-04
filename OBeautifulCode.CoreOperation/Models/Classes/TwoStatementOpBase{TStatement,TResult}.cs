// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TwoStatementOpBase{TStatement,TResult}.cs" company="OBeautifulCode">
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
    /// An operation that executes over a single-statement input.
    /// </summary>
    /// <typeparam name="TStatement">The type of the statements.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class TwoStatementOpBase<TStatement, TResult> : ReturningOperationBase<TResult>, IModelViaCodeGen, IDeclareGetSelfValidationFailuresMethod
    {
        /// <summary>
        /// Gets or sets the first statement.
        /// </summary>
        public IReturningOperation<TStatement> Statement1 { get; set; }

        /// <summary>
        /// Gets or sets the second statement.
        /// </summary>
        public IReturningOperation<TStatement> Statement2 { get; set; }

        /// <inheritdoc cref="IDeclareGetSelfValidationFailuresMethod" />
        public override IReadOnlyList<SelfValidationFailure> GetSelfValidationFailures()
        {
            var result = base.GetSelfValidationFailures().ToList();

            if (this.Statement1 == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Statement1), Invariant($"{nameof(this.Statement1)} is null.")));
            }

            if (this.Statement2 == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Statement2), Invariant($"{nameof(this.Statement2)} is null.")));
            }

            return result;
        }
    }
}
