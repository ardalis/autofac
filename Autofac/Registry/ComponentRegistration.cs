﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Lifetime;
using Autofac.Disposal;
using Autofac.Activators;
using Autofac.Services;
using Autofac.Events;

namespace Autofac.Registry
{
    public class ComponentRegistration : IComponentRegistration
    {
        public ComponentRegistration(
            Guid id,
            IInstanceActivator activator,
            IComponentLifetime lifetime,
            InstanceSharing sharing,
            InstanceOwnership ownership,
            IEnumerable<Service> services,
            IDictionary<string, object> extendedProperties)
        {
            Id = id;
            Activator = Enforce.ArgumentNotNull(activator, "activator");
            Lifetime = Enforce.ArgumentNotNull(lifetime, "lifetime");
            Sharing = sharing;
            Ownership = ownership;
            Services = Enforce.ArgumentElementNotNull(
                Enforce.ArgumentNotNull(services, "services"), "services").ToList();
            ExtendedProperties = new Dictionary<string, object>(
                Enforce.ArgumentNotNull(extendedProperties, "extendedProperties"));
        }

        public Guid Id { get; private set; }

        public IInstanceActivator Activator { get; private set; }

        public IComponentLifetime Lifetime { get; private set; }

        public InstanceSharing Sharing { get; private set; }

        public InstanceOwnership Ownership { get; private set; }

        public IEnumerable<Service> Services { get; private set; }

        public IDictionary<string, object> ExtendedProperties { get; private set; }

        public event EventHandler<ActivatingEventArgs<object>> Activating = (s, e) => { };

        public void RaiseActivating(IComponentContext context, object newInstance)
        {
            Activating(this, new ActivatingEventArgs<object>(context, this, newInstance));
        }

        public event EventHandler<ActivatedEventArgs<object>> Activated = (s, e) => { };

        public void RaiseActivated(IComponentContext context, object newInstance)
        {
            Activated(this, new ActivatedEventArgs<object>(context, this, newInstance));
        }

        public override string ToString()
        {
            // Temporary...
            return Activator.BestGuessImplementationType.ToString();
        }
    }
}
