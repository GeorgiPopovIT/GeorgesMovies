#pragma checksum "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d8b499466f74410108c24c2d8f50fb2f399a467"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d8b499466f74410108c24c2d8f50fb2f399a467", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"108046869c47d0824ebbab506cb47164ec75f259", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GeorgesMovies.Web.Models.Home.IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""jumbotron jumbotron-fluid"">
    <div class=""container"">
        <h1 class=""display-4"">Welcome to Georges Movies</h1>
        <p class=""lead"">This is my first ASP.NET Core application.It is about watch trailers of films.</p>
    </div>
</div>


<div class=""mb-5""></div>



<div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">

    <div class=""carousel-inner"">
");
#nullable restore
#line 27 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Home\Index.cshtml"
         foreach (var movie in Model.Movies)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"carousel-item\">\r\n                <img class=\"d-block w-100\" width=\"200\" height=\"600\"");
            BeginWriteAttribute("src", " src=\"", 919, "\"", 942, 1);
#nullable restore
#line 31 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 925, movie.PictuteUrl, 925, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 943, "\"", 961, 1);
#nullable restore
#line 31 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 949, movie.Title, 949, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n");
#nullable restore
#line 33 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Home\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GeorgesMovies.Web.Models.Home.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
