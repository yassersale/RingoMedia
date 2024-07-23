using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using RingoMedia.Queries.Container;
using System;

namespace RingoMedia.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}