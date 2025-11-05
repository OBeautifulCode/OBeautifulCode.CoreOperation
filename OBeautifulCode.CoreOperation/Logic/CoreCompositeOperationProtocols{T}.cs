// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreCompositeOperationProtocols{T}.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using System;
    using System.Threading.Tasks;
    using OBeautifulCode.Equality.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Protocols that handle generic operations that are composed of other operations.
    /// </summary>
    /// <typeparam name="T">The type of value.</typeparam>
    public class CoreCompositeOperationProtocols<T> :
          ISyncAndAsyncReturningProtocol<IfThenElseOp<T>, T>,
          ISyncAndAsyncReturningProtocol<IsEqualToOp<T>, bool>
    {
        private readonly IProtocolFactory protocolFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreCompositeOperationProtocols{TResult}"/> class.
        /// </summary>
        /// <param name="protocolFactory">The protocol factory to use when a protocol is required to execute an operation.</param>
        public CoreCompositeOperationProtocols(
            IProtocolFactory protocolFactory)
        {
            if (protocolFactory == null)
            {
                throw new ArgumentNullException(nameof(protocolFactory));
            }

            this.protocolFactory = protocolFactory;
        }

        /// <inheritdoc />
        public T Execute(
            IfThenElseOp<T> operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            T result;

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (this.protocolFactory.GetProtocolAndExecuteViaReflection<bool>(operation.Condition))
            {
                result = this.protocolFactory.GetProtocolAndExecuteViaReflection<T>(operation.Statement);
            }
            else
            {
                result = this.protocolFactory.GetProtocolAndExecuteViaReflection<T>(operation.ElseStatement);
            }

            return result;
        }

        /// <inheritdoc />
        public async Task<T> ExecuteAsync(
            IfThenElseOp<T> operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            T result;

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<bool>(operation.Condition))
            {
                result = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<T>(operation.Statement);
            }
            else
            {
                result = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<T>(operation.ElseStatement);
            }

            return result;
        }

        /// <inheritdoc />
        public bool Execute(
            IsEqualToOp<T> operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var value1 = this.protocolFactory.GetProtocolAndExecuteViaReflection<T>(operation.Statement1);

            var value2 = this.protocolFactory.GetProtocolAndExecuteViaReflection<T>(operation.Statement2);

            var result = value1.IsEqualTo(value2);

            return result;
        }

        /// <inheritdoc />
        public async Task<bool> ExecuteAsync(
            IsEqualToOp<T> operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var value1 = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<T>(operation.Statement1);

            var value2 = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<T>(operation.Statement2);

            var result = value1.IsEqualTo(value2);

            return result;
        }
    }
}
