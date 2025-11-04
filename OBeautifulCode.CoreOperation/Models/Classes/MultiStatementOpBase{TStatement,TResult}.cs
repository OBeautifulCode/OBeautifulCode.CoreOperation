// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiStatementOpBase{TStatement,TResult}.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OBeautifulCode.CodeAnalysis.Recipes;
    using OBeautifulCode.Type;
    using static System.FormattableString;

    /// <summary>
    /// An operation that executes over a multi-statement input.
    /// </summary>
    /// <typeparam name="TStatement">The type of the statements.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi", Justification = ObcSuppressBecause.CA1704_IdentifiersShouldBeSpelledCorrectly_SpellingIsCorrectInContextOfTheDomain)]
    public abstract partial class MultiStatementOpBase<TStatement, TResult> : ReturningOperationBase<TResult>, IModelViaCodeGen, IDeclareGetSelfValidationFailuresMethod
    {
        /// <summary>
        /// Gets or sets the statements.
        /// </summary>
        public IReadOnlyCollection<IReturningOperation<TStatement>> Statements { get; set; }

        /// <inheritdoc cref="IDeclareGetSelfValidationFailuresMethod" />
        public override IReadOnlyList<SelfValidationFailure> GetSelfValidationFailures()
        {
            var result = base.GetSelfValidationFailures().ToList();

            if (this.Statements == null)
            {
                result.Add(new SelfValidationFailure(nameof(this.Statements), Invariant($"{nameof(this.Statements)} is null.")));
            }
            else if (!this.Statements.Any())
            {
                result.Add(new SelfValidationFailure(nameof(this.Statements), Invariant($"{nameof(this.Statements)} is an empty enumerable.")));
            }
            else if (this.Statements.Count < 2)
            {
                result.Add(new SelfValidationFailure(nameof(this.Statements), Invariant($"{nameof(this.Statements)} contains less than 2 elements.")));
            }
            else if (this.Statements.Any(_ => _ == null))
            {
                result.Add(new SelfValidationFailure(nameof(this.Statements), Invariant($"{nameof(this.Statements)} contains at least one null element.")));
            }

            return result;
        }
    }
}
