// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreCompositeOperationProtocolsTTest.cs" company="OBeautifulCode">
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

    public static class CoreCompositeOperationProtocolsTTest
    {
        private static readonly IProtocolFactory ProtocolFactory = new ProtocolFactory(
            new Dictionary<Type, Func<IProtocol>>
            {
                { typeof(GetConstValueProtocol<int>), () => new GetConstValueProtocol<int>() },
                { typeof(GetConstValueProtocol<bool>), () => new GetConstValueProtocol<bool>() },
                { typeof(GetConstValueProtocol<decimal>), () => new GetConstValueProtocol<decimal>() },
            });

        [Fact]
        public static void Constructor___Should_throw_ArgumentNullException___When_parameter_protocolFactory_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => new CoreCompositeOperationProtocols<int>(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_IfThenElseOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((IfThenElseOp<int>)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_IfThenElseOp___Should_execute_Statement_and_return_result___When_executing_Condition_returns_true()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            var operation = Op.IfThenElse(Op.Const(true), Op.Const(1), Op.Const(2));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(1);
        }

        [Fact]
        public static void Execute_IfThenElseOp___Should_execute_ElseStatement_and_return_result___When_executing_Condition_returns_false()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            var operation = Op.IfThenElse(Op.Const(false), Op.Const(1), Op.Const(2));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(2);
        }

        [Fact]
        public static async Task ExecuteAsync_IfThenElseOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((IfThenElseOp<int>)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_IfThenElseOp___Should_execute_Statement_and_return_result___When_executing_Condition_returns_true()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            var operation = Op.IfThenElse(Op.Const(true), Op.Const(1), Op.Const(2));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(1);
        }

        [Fact]
        public static async Task ExecuteAsync_IfThenElseOp___Should_execute_ElseStatement_and_return_result___When_executing_Condition_returns_false()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            var operation = Op.IfThenElse(Op.Const(false), Op.Const(1), Op.Const(2));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeEqualTo(2);
        }

        [Fact]
        public static void Execute_IsEqualToOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            // Act
            var actual = Record.Exception(() => systemUnderTest.Execute((IsEqualToOp<int>)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Execute_IsEqualToOp___Should_return_false___When_the_result_of_executing_Statement1_is_not_equal_to_the_result_of_executing_Statement2()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            var operation = Op.IsEqualTo(Op.Const(1), Op.Const(2));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static void Execute_IsEqualToOp___Should_return_true___When_the_result_of_executing_Statement1_is_equal_to_the_result_of_executing_Statement2()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            var operation = Op.IsEqualTo(Op.Const(2), Op.Const(2));

            // Act
            var actual = systemUnderTest.Execute(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }

        [Fact]
        public static async Task ExecuteAsync_IsEqualToOp___Should_throw_ArgumentNullException___When_operation_is_null()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.ExecuteAsync((IsEqualToOp<int>)null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static async Task ExecuteAsync_IsEqualToOp___Should_return_false___When_the_result_of_executing_Statement1_is_not_equal_to_the_result_of_executing_Statement2()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            var operation = Op.IsEqualTo(Op.Const(1), Op.Const(2));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeFalse();
        }

        [Fact]
        public static async Task ExecuteAsync_IsEqualToOp___Should_return_true___When_the_result_of_executing_Statement1_is_equal_to_the_result_of_executing_Statement2()
        {
            // Arrange
            var systemUnderTest = new CoreCompositeOperationProtocols<int>(ProtocolFactory);

            var operation = Op.IsEqualTo(Op.Const(2), Op.Const(2));

            // Act
            var actual = await systemUnderTest.ExecuteAsync(operation);

            // Assert
            actual.AsTest().Must().BeTrue();
        }
    }
}
