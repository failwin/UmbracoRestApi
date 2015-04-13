﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Configuration;

namespace Umbraco.Web.Rest.Routing
{
    /// <summary>
    /// A custom route prefix which is based on the configured back office route/folder (i.e. Umbraco)
    /// </summary>
    public sealed class UmbracoRoutePrefix : RoutePrefixAttribute
    {
        public UmbracoRoutePrefix(string prefix): base(prefix)
        {
            _fromConfig = true;
        }

        public UmbracoRoutePrefix(string prefix, string backofficeRoute)
            : base(prefix)
        {
            _fromConfig = false;
            _umbracoMvcArea = backofficeRoute;
        }

        /// <summary>
        /// Gets the prefix with the umbraco back office configured route 
        /// </summary>
        public override string Prefix
        {
            get { return UmbracoMvcArea.EnsureEndsWith('/') + base.Prefix.TrimEnd('/'); }
        }

        private readonly bool _fromConfig;
        private string _umbracoMvcArea;

        /// <summary>
        /// This returns the string of the MVC Area route.
        /// </summary>
        /// <remarks>
        /// Uses reflection to get the internal property in umb core, we don't want to expose this publicly in the core
        /// until we sort out the Global configuration bits and make it an interface, put them in the correct place, etc...
        /// </remarks>
        internal string UmbracoMvcArea
        {
            get
            {
                if (_fromConfig)
                {
                    return _umbracoMvcArea ??                        
                        //Use reflection to get the type and value and cache
                           (_umbracoMvcArea = (string)Assembly.Load("Umbraco.Core").GetType("Umbraco.Core.Configuration.GlobalSettings").GetStaticProperty("UmbracoMvcArea"));    
                }
                return _umbracoMvcArea;
            }
        }
    }
}
