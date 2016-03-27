﻿using System;
using System.ComponentModel.DataAnnotations;
using Umbraco.RestApi.Links;

namespace Umbraco.RestApi.Models
{
    public class ContentRepresentation : ContentRepresentationBase
    {
        public ContentRepresentation(IContentLinkTemplate<int> linkTemplate, Action<UmbracoRepresentation> createHypermediaCallback)
            : base(linkTemplate, createHypermediaCallback)
        {
        }

        public ContentRepresentation(IContentLinkTemplate<int> linkTemplate)
            : base(linkTemplate)
        {
        }

        public ContentRepresentation(Action<UmbracoRepresentation> createHypermediaCallback)
            : base(createHypermediaCallback)
        {
        }

        public ContentRepresentation()
        {
        }

        [Required]
        [Display(Name = "templateId")]
        public int TemplateId { get; set; }

        [Display(Name = "templateName")]
        public string TemplateName { get; set; }
    }
}
