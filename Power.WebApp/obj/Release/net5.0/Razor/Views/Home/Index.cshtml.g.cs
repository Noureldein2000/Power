#pragma checksum "E:\Study\Power API\Power\Power.WebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a6f0caf3ab81fe0df82cb9d3260f3fc6d67b198"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Study\Power API\Power\Power.WebApp\Views\_ViewImports.cshtml"
using Power.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Study\Power API\Power\Power.WebApp\Views\_ViewImports.cshtml"
using Power.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Study\Power API\Power\Power.WebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Builder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Study\Power API\Power\Power.WebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Study\Power API\Power\Power.WebApp\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Study\Power API\Power\Power.WebApp\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a6f0caf3ab81fe0df82cb9d3260f3fc6d67b198", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0293da374dc9335539c1eedf3fc2bbb4ac96aaa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Study\Power API\Power\Power.WebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">");
#nullable restore
#line 7 "E:\Study\Power API\Power\Power.WebApp\Views\Home\Index.cshtml"
                     Write(_localizer["Welcome"].Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">");
#nullable restore
#line 8 "E:\Study\Power API\Power\Power.WebApp\Views\Home\Index.cshtml"
                                                               Write(_localizer["Content"].Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>.</p>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<PowerWebResource> _localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
