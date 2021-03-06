﻿using System;
using System.Collections.Generic;
using System.Linq;
using FeatureTests.Shared.GenericApiSupport;
using FeatureTests.Shared.GenericApiSupport.GenericPlaceholders;
using Grax.fFastMapper;

namespace FeatureTests.On.ObjectMappers.Adapters {
    public class fFastMapperAdapter : ObjectMapperAdapterBase {
        public override Type MapperType {
            get { return typeof(fFastMap); }
        }
        
        public override TTarget Map<TTarget>(object source) {
            var target = Activator.CreateInstance<TTarget>();
            Map(source, target);
            return target;
        }

        public override void Map(object source, object target) {
            GenericHelper.RewriteAndInvoke(
                () => fFastMap.Map((X1)source, (X2)target),
                source.GetType(), target.GetType()
            );
        }
    }
}
