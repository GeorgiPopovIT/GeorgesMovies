#pragma checksum "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Actor\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "580e09f7ce9c6de286afba4b4c694d7339207cb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Actor_All), @"mvc.1.0.view", @"/Views/Actor/All.cshtml")]
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
#line 1 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\_ViewImports.cshtml"
using GeorgesMovies.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\_ViewImports.cshtml"
using GeorgesMovies.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\_ViewImports.cshtml"
using GeorgesMovies.Web.Models.Movies;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"580e09f7ce9c6de286afba4b4c694d7339207cb8", @"/Views/Actor/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be170b994a1017f09925b5a6292fd91afe846fa2", @"/Views/_ViewImports.cshtml")]
    public class Views_Actor_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GeorgesMovies.Web.Models.Actors.AllActorsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Actor\All.cshtml"
   
    ViewData["Title"] = "All actors";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"list-group\">\n    <p class=\"list-group-item list-group-item-action active\">\n        Actor name  \n    </p>\n");
#nullable restore
#line 10 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Actor\All.cshtml"
     foreach (var actor in Model.Actors)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a href=\"#\" class=\"list-group-item list-group-item-action\">");
#nullable restore
#line 12 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Actor\All.cshtml"
                                                              Write(actor.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 12 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Actor\All.cshtml"
                                                                               Write(actor.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 13 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Actor\All.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GeorgesMovies.Web.Models.Actors.AllActorsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
