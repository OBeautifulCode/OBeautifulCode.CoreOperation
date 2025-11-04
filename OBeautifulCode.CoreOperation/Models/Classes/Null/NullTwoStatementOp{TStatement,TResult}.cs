// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullTwoStatementOp{TStatement,TResult}.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using OBeautifulCode.Type;

    /// <summary>
    /// Null object pattern implementation of an operation that executes over a single-statement input.
    /// </summary>
    /// <typeparam name="TStatement">The type of the statements.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class NullTwoStatementOp<TStatement, TResult> : TwoStatementOpBase<TStatement, TResult>, IModelViaCodeGen
    {
    }
}