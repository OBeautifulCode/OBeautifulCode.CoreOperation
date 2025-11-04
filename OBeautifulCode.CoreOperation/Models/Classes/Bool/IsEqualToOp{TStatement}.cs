// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsEqualToOp{TStatement}.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using OBeautifulCode.Type;

    /// <summary>
    /// Determines if two value are equal.
    /// </summary>
    /// <typeparam name="TStatement">The type of the statements to compare.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class IsEqualToOp<TStatement> : TwoStatementOpBase<TStatement, bool>, IModelViaCodeGen
    {
    }
}