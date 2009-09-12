﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Registration;
using Autofac.Activators;
using Autofac.Lifetime;

namespace Autofac.Tests
{
    static class Fixture
    {
        public static IComponentRegistration CreateSingletonObjectRegistration()
        {
            return new ComponentRegistration(
                Guid.NewGuid(),
                new ReflectionActivator(typeof(object),
                    new BindingFlagsConstructorFinder(System.Reflection.BindingFlags.Public),
                    new MostParametersConstructorSelector(),
                    Enumerable.Empty<Parameter>()),
                new RootScopeLifetime(),
                InstanceSharing.Shared,
                InstanceOwnership.OwnedByLifetimeScope,
                new Service[] { new TypedService(typeof(object)) },
                new Dictionary<string, object>());
        }
    }
}
