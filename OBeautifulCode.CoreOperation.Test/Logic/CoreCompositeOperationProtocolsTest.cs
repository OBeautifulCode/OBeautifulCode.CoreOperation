// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreCompositeOperationProtocolsTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation.Test
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;
    using Xunit;

    public static class CoreCompositeOperationProtocolsTest
    {
        private static readonly IProtocolFactory ProtocolFactory = new ProtocolFactory(
            new Dictionary<Type, Func<IProtocol>>
            {
                { typeof(GetConstValueProtocol<bool>), () => new GetConstValueProtocol<bool>() },
                { typeof(GetConstValueProtocol<decimal>), () => new GetConstValueProtocol<decimal>() },
                { typeof(GetConstValueProtocol<CompareOperator>), () => new GetConstValueProtocol<CompareOperator>() },
            });

        [Fact]
        public static void Constructor___Should_throw_ArgumentNullException___When_parameter_protocolFactory_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => new CoreCompositeOperationProtocols(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_AndAlsoOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((AndAlsoOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_AndAlsoOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new AndAlsoOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_AndAlsoOp___Should_stop_executing_Statements_and_return_false___When_executing_Statements_in_order_and_one_returns_false()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.AndAlso(Op.Const(true), Op.Const(true), Op.Const(false), Op.Abort<bool>());

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_AndAlsoOp__Should_return_true___When_executing_Statements_and_none_return_false()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.AndAlso(Op.Const(true), Op.Const(true), Op.Const(true));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_AndAlsoOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((AndAlsoOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_AndAlsoOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new AndAlsoOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_AndAlsoOp___Should_stop_executing_Statements_and_return_false___When_executing_Statements_in_order_and_one_returns_false()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.AndAlso(Op.Const(true), Op.Const(true), Op.Const(false), Op.Abort<bool>());

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_AndAlsoOp__Should_return_true___When_executing_Statements_and_none_return_false()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.AndAlso(Op.Const(true), Op.Const(true), Op.Const(true));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_OrElseOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((OrElseOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_OrElseOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new OrElseOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_OrElseOp___Should_stop_executing_Statements_and_return_true___When_executing_Statements_in_order_and_one_returns_true()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.OrElse(Op.Const(false), Op.Const(false), Op.Const(true), Op.Abort<bool>());

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_OrElseOp__Should_return_false___When_executing_Statements_and_none_return_true()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.OrElse(Op.Const(false), Op.Const(false), Op.Const(false));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_OrElseOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((OrElseOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_OrElseOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new OrElseOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_OrElseOp___Should_stop_executing_Statements_and_return_true___When_executing_Statements_in_order_and_one_returns_true()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.OrElse(Op.Const(false), Op.Const(false), Op.Const(true), Op.Abort<bool>());

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_OrElseOp__Should_return_true___When_executing_Statements_and_none_return_true()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.OrElse(Op.Const(false), Op.Const(false), Op.Const(false));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_NotOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((NotOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_NotOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new NotOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_NotOp___Should_return_true___When_the_result_of_executing_Statement_is_false()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Not(Op.Const(false));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_NotOp___Should_return_false___When_the_result_of_executing_Statement_is_true()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Not(Op.Const(true));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_NotOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((NotOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_NotOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new NotOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_NotOp___Should_return_true___When_the_result_of_executing_Statement_is_false()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Not(Op.Const(false));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_NotOp___Should_return_false___When_the_result_of_executing_Statement_is_true()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Not(Op.Const(true));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_SumOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((SumOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_SumOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new SumOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_SumOp___Should_return_sum_of_the_results_of_executing_Statements___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Sum(Op.Const(1m), Op.Const(2m), Op.Const(3m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(6m);
        }

        [Fact]
        public static async Task ExecuteAsync_SumOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((SumOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_SumOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new SumOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_SumOp___Should_return_sum_of_the_results_of_executing_Statements___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Sum(Op.Const(1m), Op.Const(2m), Op.Const(3m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(6m);
        }

        [Fact]
        public static void Execute_SubtractOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((SubtractOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_SubtractOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new SubtractOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_SubtractOp___Should_execute_LeftOperand_and_subtract_the_result_of_executing_RightOperand___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Subtract(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(-1m);
        }

        [Fact]
        public static async Task ExecuteAsync_SubtractOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((SubtractOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_SubtractOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new SubtractOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_SubtractOp___Should_execute_LeftOperand_and_subtract_the_result_of_executing_RightOperand___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Subtract(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(-1m);
        }

        [Fact]
        public static void Execute_MultiplyOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((MultiplyOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_MultiplyOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new MultiplyOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_MultiplyOp___Should_return_sum_of_the_results_of_executing_Statements___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Multiply(Op.Const(2m), Op.Const(3m), Op.Const(4m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(24m);
        }

        [Fact]
        public static async Task ExecuteAsync_MultiplyOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((MultiplyOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_MultiplyOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new MultiplyOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_MultiplyOp___Should_return_sum_of_the_results_of_executing_Statements___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Multiply(Op.Const(2m), Op.Const(3m), Op.Const(4m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(24m);
        }

        [Fact]
        public static void Execute_DivideOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((DivideOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_DivideOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new DivideOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_DivideOp___Should_throw_DivideByZeroException___When_executing_Numerator_returns_0()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Divide(Op.Const(1m), Op.Const(0m));

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(operation));

            // Assert
            actual.AsTest().Must().BeOfType<DivideByZeroException>();
        }

        [Fact]
        public static void Execute_DivideOp___Should_execute_Numerator_and_divide_the_result_by_the_result_of_executing_Denominator___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Divide(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(.5m);
        }

        [Fact]
        public static async Task ExecuteAsync_DivideOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((DivideOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_DivideOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new DivideOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_DivideOp___Should_throw_DivideByZeroException___When_executing_Numerator_returns_0()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Divide(Op.Const(1m), Op.Const(0m));

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(operation));

            // Assert
            actual.AsTest().Must().BeOfType<DivideByZeroException>();
        }

        [Fact]
        public static async Task ExecuteAsync_DivideOp___Should_execute_Numerator_and_divide_the_result_by_the_result_of_executing_Denominator___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.Divide(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(.5m);
        }

        [Fact]
        public static void Execute_CompareOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((CompareOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_CompareOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new CompareOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_false___When_executing_CompareOperator_returns_GreaterThan_and_the_result_of_executing_Left_is_less_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThan(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_false___When_executing_CompareOperator_returns_GreaterThan_and_the_result_of_executing_Left_is_equal_to_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThan(Op.Const(1m), Op.Const(1m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_true___When_executing_CompareOperator_returns_GreaterThan_and_the_result_of_executing_Left_is_greater_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThan(Op.Const(2m), Op.Const(1m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_false___When_executing_CompareOperator_returns_GreaterThanOrEqualTo_and_the_result_of_executing_Left_is_less_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThanOrEqualTo(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_true___When_executing_CompareOperator_returns_GreaterThanOrEqualTo_and_the_result_of_executing_Left_is_equal_to_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThanOrEqualTo(Op.Const(1m), Op.Const(1m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_true___When_executing_CompareOperator_returns_GreaterThanOrEqualTo_and_the_result_of_executing_Left_is_greater_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThanOrEqualTo(Op.Const(2m), Op.Const(1m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_true___When_executing_CompareOperator_returns_LessThan_and_the_result_of_executing_Left_is_less_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThan(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_false___When_executing_CompareOperator_returns_LessThan_and_the_result_of_executing_Left_is_equal_to_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThan(Op.Const(1m), Op.Const(1m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_false___When_executing_CompareOperator_returns_LessThan_and_the_result_of_executing_Left_is_greater_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThan(Op.Const(2m), Op.Const(1m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_true___When_executing_CompareOperator_returns_LessThanOrEqualTo_and_the_result_of_executing_Left_is_less_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThanOrEqualTo(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_true___When_executing_CompareOperator_returns_LessThanOrEqualTo_and_the_result_of_executing_Left_is_equal_to_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThanOrEqualTo(Op.Const(1m), Op.Const(1m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static void Execute_CompareOp___Should_return_false___When_executing_CompareOperator_returns_LessThanOrEqualTo_and_the_result_of_executing_Left_is_greater_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThanOrEqualTo(Op.Const(2m), Op.Const(1m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((CompareOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new CompareOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_false___When_executing_CompareOperator_returns_GreaterThan_and_the_result_of_executing_Left_is_less_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThan(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_false___When_executing_CompareOperator_returns_GreaterThan_and_the_result_of_executing_Left_is_equal_to_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThan(Op.Const(1m), Op.Const(1m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_true___When_executing_CompareOperator_returns_GreaterThan_and_the_result_of_executing_Left_is_greater_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThan(Op.Const(2m), Op.Const(1m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_false___When_executing_CompareOperator_returns_GreaterThanOrEqualTo_and_the_result_of_executing_Left_is_less_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThanOrEqualTo(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_true___When_executing_CompareOperator_returns_GreaterThanOrEqualTo_and_the_result_of_executing_Left_is_equal_to_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThanOrEqualTo(Op.Const(1m), Op.Const(1m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_true___When_executing_CompareOperator_returns_GreaterThanOrEqualTo_and_the_result_of_executing_Left_is_greater_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsGreaterThanOrEqualTo(Op.Const(2m), Op.Const(1m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_true___When_executing_CompareOperator_returns_LessThan_and_the_result_of_executing_Left_is_less_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThan(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_false___When_executing_CompareOperator_returns_LessThan_and_the_result_of_executing_Left_is_equal_to_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThan(Op.Const(1m), Op.Const(1m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_false___When_executing_CompareOperator_returns_LessThan_and_the_result_of_executing_Left_is_greater_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThan(Op.Const(2m), Op.Const(1m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_true___When_executing_CompareOperator_returns_LessThanOrEqualTo_and_the_result_of_executing_Left_is_less_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThanOrEqualTo(Op.Const(1m), Op.Const(2m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_true___When_executing_CompareOperator_returns_LessThanOrEqualTo_and_the_result_of_executing_Left_is_equal_to_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThanOrEqualTo(Op.Const(1m), Op.Const(1m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_CompareOp___Should_return_false___When_executing_CompareOperator_returns_LessThanOrEqualTo_and_the_result_of_executing_Left_is_greater_than_the_result_of_executing_Right()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.IsLessThanOrEqualTo(Op.Const(2m), Op.Const(1m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_GetNumberOfSignificantDigitsOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((GetNumberOfSignificantDigitsOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_GetNumberOfSignificantDigitsOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute(new GetNumberOfSignificantDigitsOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static void Execute_GetNumberOfSignificantDigitsOp___Should_return_number_of_significant_digits_of_the_result_of_executing_Statement___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.GetNumberOfSignificantDigits(Op.Const(1.12340m));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(4);
        }

        [Fact]
        public static async Task ExecuteAsync_GetNumberOfSignificantDigitsOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((GetNumberOfSignificantDigitsOp)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_GetNumberOfSignificantDigitsOp___Should_throw_ValidationException___When_operation_is_invalid()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync(new GetNumberOfSignificantDigitsOp()));

            // Assert
            actual.AsTest().Must().BeOfType<ValidationException>();
        }

        [Fact]
        public static async Task ExecuteAsync_GetNumberOfSignificantDigitsOp___Should_return_number_of_significant_digits_of_the_result_of_executing_Statement___When_called()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols(ProtocolFactory);

            var operation = Op.GetNumberOfSignificantDigits(Op.Const(1.12340m));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(4);
        }
    }
}
