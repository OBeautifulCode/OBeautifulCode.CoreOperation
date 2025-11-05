// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreCompositeOperationProtocols.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using OBeautifulCode.Type;
    using static System.FormattableString;

    /// <summary>
    /// Protocols that handle operations that are composed of other operations.
    /// </summary>
    public class CoreCompositeOperationProtocols :
          ISyncAndAsyncReturningProtocol<AndAlsoOp, bool>,
          ISyncAndAsyncReturningProtocol<OrElseOp, bool>,
          ISyncAndAsyncReturningProtocol<NotOp, bool>,
          ISyncAndAsyncReturningProtocol<SumOp, decimal>,
          ISyncAndAsyncReturningProtocol<CompareOp, bool>,
          ISyncAndAsyncReturningProtocol<GetNumberOfSignificantDigitsOp, int>,
          ISyncAndAsyncReturningProtocol<DivideOp, decimal>
    {
        private readonly IProtocolFactory protocolFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreCompositeOperationProtocols"/> class.
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
        public bool Execute(
            AndAlsoOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            foreach (var statement in operation.Statements)
            {
                if (!this.protocolFactory.GetProtocolAndExecuteViaReflection<bool>(statement))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> ExecuteAsync(
            AndAlsoOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            foreach (var statement in operation.Statements)
            {
                if (!(await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<bool>(statement)))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        public bool Execute(
            OrElseOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            foreach (var statement in operation.Statements)
            {
                if (this.protocolFactory.GetProtocolAndExecuteViaReflection<bool>(statement))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public async Task<bool> ExecuteAsync(
            OrElseOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            foreach (var statement in operation.Statements)
            {
                if (await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<bool>(statement))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public bool Execute(
            NotOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var result = !this.protocolFactory.GetProtocolAndExecuteViaReflection<bool>(operation.Statement);

            return result;
        }

        /// <inheritdoc />
        public async Task<bool> ExecuteAsync(
            NotOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var result = !(await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<bool>(operation.Statement));

            return result;
        }

        /// <inheritdoc />
        public decimal Execute(
            SumOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var result = operation.Statements.Sum(_ => this.protocolFactory.GetProtocolAndExecuteViaReflection<decimal>(_));

            return result;
        }

        /// <inheritdoc />
        public async Task<decimal> ExecuteAsync(
            SumOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var result = 0m;

            foreach (var statement in operation.Statements)
            {
                result += await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<decimal>(statement);
            }

            return result;
        }

        /// <inheritdoc />
        public bool Execute(
            CompareOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var left = this.protocolFactory.GetProtocolAndExecuteViaReflection<decimal>(operation.Left);

            var @operator = this.protocolFactory.GetProtocolAndExecuteViaReflection<CompareOperator>(operation.Operator);

            var right = this.protocolFactory.GetProtocolAndExecuteViaReflection<decimal>(operation.Right);

            var result = Compare(left, @operator, right);

            return result;
        }

        /// <inheritdoc />
        public async Task<bool> ExecuteAsync(
            CompareOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var left = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<decimal>(operation.Left);

            var @operator = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<CompareOperator>(operation.Operator);

            var right = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<decimal>(operation.Right);

            var result = Compare(left, @operator, right);

            return result;
        }

        /// <inheritdoc />
        public int Execute(
            GetNumberOfSignificantDigitsOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var value = this.protocolFactory.GetProtocolAndExecuteViaReflection<decimal>(operation.Statement);

            var result = GetNumberOfSignificantDigit(value);

            return result;
        }

        /// <inheritdoc />
        public async Task<int> ExecuteAsync(
            GetNumberOfSignificantDigitsOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var value = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<decimal>(operation.Statement);

            var result = GetNumberOfSignificantDigit(value);

            return result;
        }

        /// <inheritdoc />
        public decimal Execute(
            DivideOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var numerator = this.protocolFactory.GetProtocolAndExecuteViaReflection<decimal>(operation.Numerator);

            var denominator = this.protocolFactory.GetProtocolAndExecuteViaReflection<decimal>(operation.Denominator);

            var result = numerator / denominator;

            return result;
        }

        /// <inheritdoc />
        public async Task<decimal> ExecuteAsync(
            DivideOp operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            operation.ThrowIfInvalid(new ValidationOptions { ValidationScope = ValidationScope.SelfOnly });

            var numerator = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<decimal>(operation.Numerator);

            var denominator = await this.protocolFactory.GetProtocolAndExecuteViaReflectionAsync<decimal>(operation.Denominator);

            var result = numerator / denominator;

            return result;
        }

        private static bool Compare(
            decimal left,
            CompareOperator @operator,
            decimal right)
        {
            bool result;

            switch (@operator)
            {
                case CompareOperator.GreaterThan:
                    result = left > right;
                    break;
                case CompareOperator.GreaterThanOrEqualTo:
                    result = left >= right;
                    break;
                case CompareOperator.LessThan:
                    result = left < right;
                    break;
                case CompareOperator.LessThanOrEqualTo:
                    result = left <= right;
                    break;
                default:
                    throw new NotSupportedException(Invariant($"This {nameof(CompareOperator)} is not supported: {@operator}."));
            }

            return result;
        }

        private static int GetNumberOfSignificantDigit(
            decimal value)
        {
            // adapted from: https://stackoverflow.com/a/42265036/356790
            var n = value / 1.000000000000000000000000000000m;

            var bits = decimal.GetBits(n);

            var result = bits[3] >> 16 & 255;

            if (result < 0)
            {
                throw new InvalidOperationException("Expected result to be >= 0.");
            }

            return result;
        }
    }
}
