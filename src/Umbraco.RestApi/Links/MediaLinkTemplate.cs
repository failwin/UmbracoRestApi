﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.RestApi.Routing;
using WebApi.Hal;

namespace Umbraco.RestApi.Links
{
    public class MediaLinkTemplate : IContentLinkTemplate
    {
        private readonly int _version;

        public MediaLinkTemplate(int version)
        {
            _version = version;
        }

        public Link RootContent
        {
            get { return new Link("root", string.Format("~/{0}/{1}", RouteConstants.GetRestRootPath(_version), RouteConstants.MediaSegment)); }
        }

        public Link ContentItem
        {
            get { return new Link("content", string.Format("~/{0}/{1}/{{id}}", RouteConstants.GetRestRootPath(_version), RouteConstants.MediaSegment)); }
        }

        public Link ParentContent
        {
            get { return new Link("parent", string.Format("~/{0}/{1}/{{parentId}}", RouteConstants.GetRestRootPath(_version), RouteConstants.MediaSegment)); }
        }

        public Link PagedChildContent
        {
            get { return new Link("children", string.Format("~/{0}/{1}/{{id}}/children{{?pageIndex,pageSize}}", RouteConstants.GetRestRootPath(_version), RouteConstants.MediaSegment)); }
        }

        public Link PagedDescendantContent
        {
            get { return new Link("descendants", string.Format("~/{0}/{1}/{{id}}/descendants{{?pageIndex,pageSize}}", RouteConstants.GetRestRootPath(_version), RouteConstants.MediaSegment)); }
        }

        public Link ContentMetaData
        {
            get { return new Link("meta", string.Format("~/{0}/{1}/{{id}}/meta", RouteConstants.GetRestRootPath(_version), RouteConstants.MediaSegment)); }
        }

        public Link Search
        {
            get { return new Link("search", string.Format("~/{0}/{1}/search{{?pageIndex,pageSize,lucene}}", RouteConstants.GetRestRootPath(_version), RouteConstants.MediaSegment)); }
        }
    }
}