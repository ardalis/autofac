﻿using System;
using System.Collections.Generic;

namespace Autofac.Activators
{
    public class ProvidedInstanceActivator : InstanceActivator, IInstanceActivator
    {
        object _instance;
        bool _activated;

        public ProvidedInstanceActivator(object instance)
            : base(Enforce.ArgumentNotNull(instance, "instance").GetType())
        {
            _instance = instance;
        }

        public object ActivateInstance(ILifetimeScope activationScope, IEnumerable<Parameter> parameters)
        {
            Enforce.ArgumentNotNull(activationScope, "activationScope");
            Enforce.ArgumentNotNull(parameters, "parameters");

            if (_activated)
                throw new InvalidOperationException("Already activated the only provided instance");

            _activated = true;

            return _instance;
        }
    }
}
