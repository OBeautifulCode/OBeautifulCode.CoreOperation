// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Op.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation
{
    using OBeautifulCode.Type;

    /// <summary>
    /// Builder methods related to operations.
    /// </summary>
    public static class Op
    {
        /// <summary>
        /// Builds an operation that throws a <see cref="OpExecutionAbortedException"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="details">OPTIONAL details to use with the exception.  DEFAULT is to omit details.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static ThrowOpExecutionAbortedExceptionOp<TValue> Abort<TValue>(
            string details = null)
        {
            var result = new ThrowOpExecutionAbortedExceptionOp<TValue>(details);

            return result;
        }

        /// <summary>
        /// Builds an operation that throws a <see cref="OpExecutionDeemedNotApplicableException"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="details">OPTIONAL details to use with the exception.  DEFAULT is to omit details.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static ThrowOpExecutionDeemedNotApplicableExceptionOp<TValue> NotApplicable<TValue>(
            string details = null)
        {
            var result = new ThrowOpExecutionDeemedNotApplicableExceptionOp<TValue>(details);

            return result;
        }

        /// <summary>
        /// Builds an operation that throws a <see cref="OpExecutionFailedException"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="details">OPTIONAL details to use with the exception.  DEFAULT is to omit details.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static ThrowOpExecutionFailedExceptionOp<TValue> Throw<TValue>(
            string details = null)
        {
            var result = new ThrowOpExecutionFailedExceptionOp<TValue>(details);

            return result;
        }

        /// <summary>
        /// Builds an operation that gets a specified const value.
        /// </summary>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// An operation that gets the specified value.
        /// </returns>
        public static GetConstValueOp<TValue> Const<TValue>(
            TValue value)
        {
            var result = new GetConstValueOp<TValue>
            {
                Value = value,
            };

            return result;
        }

        /// <summary>
        /// Builds an operation that throws a <see cref="OpExecutionAbortedException"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of result.</typeparam>
        /// <param name="condition">The condition.</param>
        /// <param name="statement">The statement to execute if the condition is true.</param>
        /// <param name="elseStatement">The statement to execute if the condition is false.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static IfThenElseOp<TResult> IfThenElse<TResult>(
            IReturningOperation<bool> condition,
            IReturningOperation<TResult> statement,
            IReturningOperation<TResult> elseStatement)
        {
            var result = new IfThenElseOp<TResult>
            {
                Condition = condition,
                Statement = statement,
                ElseStatement = elseStatement,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="AndAlsoOp"/>.
        /// </summary>
        /// <param name="statements">The statements.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static AndAlsoOp AndAlso(
            params IReturningOperation<bool>[] statements)
        {
            var result = new AndAlsoOp
            {
                Statements = statements,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="OrElseOp"/>.
        /// </summary>
        /// <param name="statements">The statements.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static OrElseOp OrElse(
            params IReturningOperation<bool>[] statements)
        {
            var result = new OrElseOp
            {
                Statements = statements,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="IsEqualToOp{TResult}"/>.
        /// </summary>
        /// <typeparam name="TStatement">The type of the statements to compare.</typeparam>
        /// <param name="statement1">The first statement.</param>
        /// <param name="statement2">The second statement.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static IsEqualToOp<TStatement> IsEqualTo<TStatement>(
            IReturningOperation<TStatement> statement1,
            IReturningOperation<TStatement> statement2)
        {
            var result = new IsEqualToOp<TStatement>
            {
                Statement1 = statement1,
                Statement2 = statement2,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="NotOp"/>.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static NotOp Not(
            IReturningOperation<bool> statement)
        {
            var result = new NotOp
            {
                Statement = statement,
            };

            return result;
        }

        /// <summary>
        /// Builds a <see cref="SumOp"/>.
        /// </summary>
        /// <param name="statements">The statements.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static SumOp Sum(
            params IReturningOperation<decimal>[] statements)
        {
            var result = new SumOp
            {
                Statements = statements,
            };

            return result;
        }

        /// <summary>
        /// Builds a <see cref="SubtractOp" />.
        /// </summary>
        /// <param name="leftOperand">The left operand.</param>
        /// <param name="rightOperand">The right operand.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static SubtractOp Subtract(
            IReturningOperation<decimal> leftOperand,
            IReturningOperation<decimal> rightOperand)
        {
            var result = new SubtractOp
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand,
            };

            return result;
        }

        /// <summary>
        /// Builds a <see cref="MultiplyOp"/>.
        /// </summary>
        /// <param name="statements">The statements.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static MultiplyOp Multiply(
            params IReturningOperation<decimal>[] statements)
        {
            var result = new MultiplyOp
            {
                Statements = statements,
            };

            return result;
        }

        /// <summary>
        /// Builds a <see cref="DivideOp"/>.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static DivideOp Divide(
            IReturningOperation<decimal> numerator,
            IReturningOperation<decimal> denominator)
        {
            var result = new DivideOp
            {
                Numerator = numerator,
                Denominator = denominator,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="CompareOp"/>.
        /// </summary>
        /// <param name="left">The value to the left of the greater-than operator.</param>
        /// <param name="right">The value to the right of the greater-than operator.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static CompareOp IsGreaterThan(
            IReturningOperation<decimal> left,
            IReturningOperation<decimal> right)
        {
            var result = new CompareOp
            {
                Left = left,
                Operator = Op.Const(CompareOperator.GreaterThan),
                Right = right,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="CompareOp"/>.
        /// </summary>
        /// <param name="left">The value to the left of the greater-than-or-equal-to operator.</param>
        /// <param name="right">The value to the right of the greater-than-or-equal-to operator.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static CompareOp IsGreaterThanOrEqualTo(
            IReturningOperation<decimal> left,
            IReturningOperation<decimal> right)
        {
            var result = new CompareOp
            {
                Left = left,
                Operator = Op.Const(CompareOperator.GreaterThanOrEqualTo),
                Right = right,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="CompareOp"/>.
        /// </summary>
        /// <param name="left">The value to the left of the less-than operator.</param>
        /// <param name="right">The value to the right of the less-than operator.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static CompareOp IsLessThan(
            IReturningOperation<decimal> left,
            IReturningOperation<decimal> right)
        {
            var result = new CompareOp
            {
                Left = left,
                Operator = Op.Const(CompareOperator.LessThan),
                Right = right,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="CompareOp"/>.
        /// </summary>
        /// <param name="left">The value to the left of the less-than-or-equal-to operator.</param>
        /// <param name="right">The value to the right of the less-than-or-equal-to operator.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static CompareOp IsLessThanOrEqualTo(
            IReturningOperation<decimal> left,
            IReturningOperation<decimal> right)
        {
            var result = new CompareOp
            {
                Left = left,
                Operator = Op.Const(CompareOperator.LessThanOrEqualTo),
                Right = right,
            };

            return result;
        }

        /// <summary>
        /// Builds an <see cref="GetNumberOfSignificantDigitsOp"/>.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>
        /// The operation.
        /// </returns>
        public static GetNumberOfSignificantDigitsOp GetNumberOfSignificantDigits(
            IReturningOperation<decimal> statement)
        {
            var result = new GetNumberOfSignificantDigitsOp
            {
                Statement = statement,
            };

            return result;
        }
    }
}
