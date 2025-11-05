// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetConstValueProtocol{TValue}.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using System;
    using System.Threading.Tasks;
    using OBeautifulCode.Type;

    /// <summary>
    /// Executes a <see cref="GetConstValueOp{TValue}"/>.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    public class GetConstValueProtocol<TValue> : ISyncAndAsyncReturningProtocol<GetConstValueOp<TValue>, TValue>
    {
        /// <inheritdoc />
        public TValue Execute(
            GetConstValueOp<TValue> operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var result = operation.Value;

            return result;
        }

        /// <inheritdoc />
        public async Task<TValue> ExecuteAsync(
            GetConstValueOp<TValue> operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var result = await Task.FromResult(operation.Value);

            return result;
        }
    }
}