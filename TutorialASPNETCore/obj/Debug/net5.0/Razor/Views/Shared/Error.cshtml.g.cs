#pragma checksum "C:\Users\Seba\source\repos\PracticaNetCore\TutorialASPNETCore\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bd8499c86ad1bbfb542f0e054a70ab99dfb5dc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "C:\Users\Seba\source\repos\PracticaNetCore\TutorialASPNETCore\Views\_ViewImports.cshtml"
using TutorialASPNETCore.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Seba\source\repos\PracticaNetCore\TutorialASPNETCore\Views\_ViewImports.cshtml"
using TutorialASPNETCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Seba\source\repos\PracticaNetCore\TutorialASPNETCore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bd8499c86ad1bbfb542f0e054a70ab99dfb5dc0", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"981b82f25ef9b4f97b34aeabc6b56e5919286286", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Seba\source\repos\PracticaNetCore\TutorialASPNETCore\Views\Shared\Error.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    //@ViewBag.Title= @ViewBag.ErrorTitle;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>\r\n    ");
#nullable restore
#line 6 "C:\Users\Seba\source\repos\PracticaNetCore\TutorialASPNETCore\Views\Shared\Error.cshtml"
Write(ViewBag.ErrorTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h1>\r\n<h2>\r\n    ");
#nullable restore
#line 9 "C:\Users\Seba\source\repos\PracticaNetCore\TutorialASPNETCore\Views\Shared\Error.cshtml"
Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h2>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
