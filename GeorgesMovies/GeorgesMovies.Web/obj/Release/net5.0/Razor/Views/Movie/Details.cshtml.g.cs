#pragma checksum "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "691400b816fad64fbf47b0a25743a8152f908474"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_Details), @"mvc.1.0.view", @"/Views/Movie/Details.cshtml")]
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
using GeorgesMovies.Web.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\_ViewImports.cshtml"
using GeorgesMovies.Web.Models.Movies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\_ViewImports.cshtml"
using GeorgesMovies.Services.Movies.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\_ViewImports.cshtml"
using GeorgesMovies.Services.Comments.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"691400b816fad64fbf47b0a25743a8152f908474", @"/Views/Movie/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff494f8b0fc7642896d724588a0e21b5b258fce0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Movie_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DetailsServiceViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("messageValue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Comment..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("small text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("postComment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
  
    ViewData["Title"] = Model.Title;

    string actors = string.Join(", ", Model.ActorNames
                     .Select(x => x.FirstName + " " + x.LastName));

    var movieId = ViewContext.RouteData.Values["id"];

    var userId = AppExtensions.GetUserId(this.User);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
 if (this.TempData.ContainsKey("Message"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">\r\n        ");
#nullable restore
#line 17 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
   Write(this.TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 22 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-10 embed-responsive embed-responsive-21by9\">\r\n        <iframe class=\"embed-responsive-item\"");
            BeginWriteAttribute("src", "\r\n                src=\"", 793, "\"", 831, 1);
#nullable restore
#line 28 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
WriteAttributeValue("", 816, Model.MovieUrl, 816, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                title=\"Georges video player\"\r\n                allowfullscreen>\r\n        </iframe>\r\n    </div>\r\n    <div class=\"col-md-2 float-right\">\r\n        <h2>Time:</h2>\r\n        <p>");
#nullable restore
#line 35 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
      Write(Model.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n        <h2>Year of premiere:</h2>\r\n        <h4>");
#nullable restore
#line 38 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
       Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n        <h3>Director:</h3>\r\n        <div>");
#nullable restore
#line 41 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
        Write(Model.DirectorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <br />\r\n        <h3>Actors:</h3>\r\n        <span>");
#nullable restore
#line 44 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
          Write(actors.Any() ? actors : "No actors");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n\r\n</div>\r\n<div class=\"mb-3\"></div>\r\n\r\n<h2>");
#nullable restore
#line 50 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<div class=\"mb-3\"></div>\r\n\r\n\r\n<div class=\"mb-3\"></div>\r\n<h4>Description:</h4>\r\n<p>");
#nullable restore
#line 57 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
Write(Model.Review);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<div class=\"mb-3\"></div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "691400b816fad64fbf47b0a25743a8152f90847411172", async() => {
                WriteLiteral("\r\n    <div class=\"form-group col-md-4\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "691400b816fad64fbf47b0a25743a8152f90847411482", async() => {
                    WriteLiteral("Enter comment");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 63 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Comment.Message);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "691400b816fad64fbf47b0a25743a8152f90847413148", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 64 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Comment.Message);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "691400b816fad64fbf47b0a25743a8152f90847414931", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 65 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Comment.Message);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n        <button type=\"submit\"\r\n                class=\"btn btn-primary\">\r\n            Post\r\n        </button>\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"mb-4\"></div>\r\n\r\n<div id=\"allComments\">\r\n");
            WriteLiteral("</div>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n\r\n        window.onload = (event) => {\r\n            $(\"#allComments\").load(\"/Comment/AllByMovie/\", { movieId: ");
#nullable restore
#line 87 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
                                                                 Write(movieId);

#line default
#line hidden
#nullable disable
                WriteLiteral(" });\r\n        };\r\n\r\n\r\n        const formElement = document.getElementById(\'postComment\');\r\n\r\n        formElement.addEventListener(\'submit\', postMessage);\r\n\r\n");
                WriteLiteral(@"         $('#postComment').on('submit', event => {
            event.preventDefault();

            const messageValue = document.getElementById('messageValue').value;

            const model = {
                message: messageValue,
                movieId: ");
#nullable restore
#line 120 "C:\Users\Georges\Desktop\GeorgesMovies\GeorgesMovies\GeorgesMovies.Web\Views\Movie\Details.cshtml"
                    Write(movieId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                };

             $.ajax({
                 type: ""POST"",
                 url: ""/api/CommentApi"",
                 contentType: ""application/json"",
                 data: JSON.stringify(model),
                 success: function (data) {


                     $(""#allComments"").html(data);

                     document.getElementById('messageValue').value = '';
                 }
             });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsServiceViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
