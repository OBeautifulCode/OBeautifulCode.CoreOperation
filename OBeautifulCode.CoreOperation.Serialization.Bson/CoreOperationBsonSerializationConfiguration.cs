// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreOperationBsonSerializationConfiguration.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.CoreOperation.Serialization.Bson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using OBeautifulCode.Serialization.Bson;
    using OBeautifulCode.Type;
    using OBeautifulCode.Type.Recipes;

    /// <inheritdoc />
    public class CoreOperationBsonSerializationConfiguration : BsonSerializationConfigurationBase
    {
        /// <inheritdoc />
        protected override IReadOnlyCollection<string> TypeToRegisterNamespacePrefixFilters =>
            new[]
            {
                    OBeautifulCode.CoreOperation.ProjectInfo.Namespace,
            };

        /// <inheritdoc />
        protected override IReadOnlyCollection<BsonSerializationConfigurationType> DependentBsonSerializationConfigurationTypes =>
            new BsonSerializationConfigurationType[]
            {
            };

        /// <inheritdoc />
        protected override IReadOnlyCollection<TypeToRegisterForBson> TypesToRegisterForBson => new Type[0]
            .Concat(new[] { typeof(IModel) })
            .Concat(OBeautifulCode.CoreOperation.ProjectInfo.Assembly.GetPublicEnumTypes())
            .Select(_ => _.ToTypeToRegisterForBson())
            .ToList();
    }
}