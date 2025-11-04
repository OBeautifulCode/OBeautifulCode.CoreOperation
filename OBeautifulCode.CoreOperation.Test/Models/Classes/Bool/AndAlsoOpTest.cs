// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AndAlsoOpTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using FakeItEasy;

    using OBeautifulCode.AutoFakeItEasy;
    using OBeautifulCode.CodeAnalysis.Recipes;
    using OBeautifulCode.CodeGen.ModelObject.Recipes;
    using OBeautifulCode.Math.Recipes;

    using Xunit;

    using static System.FormattableString;

    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
    public static partial class AndAlsoOpTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static AndAlsoOpTest()
        {
            SelfValidationTestScenarios
                .AddScenario(() =>
                {
                    var systemUnderTest = A.Dummy<AndAlsoOp>();

                    systemUnderTest.Statements = systemUnderTest.Statements.Take(1).ToList();

                    var result = new SelfValidationTestScenario<AndAlsoOp>
                    {
                        Name = "GetSelfValidationFailures() should return a failure when property 'Statements' contains less than 2 elements",
                        SystemUnderTest = systemUnderTest,
                        ExpectedFailurePropertyNames = new[] { "Statements" },
                        ExpectedFailureMessageContains = new[] { "Statements", "contains less than 2 elements", },
                        ScenarioPassesWhen = SelfValidationTestScenarioPassesWhen.OnlyOneFailureMeetsExpectation,
                    };

                    return result;
                });
        }
    }
}