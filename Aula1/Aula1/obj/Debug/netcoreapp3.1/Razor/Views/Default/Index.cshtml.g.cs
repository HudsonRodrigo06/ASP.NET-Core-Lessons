#pragma checksum "C:\www\ASP.NET-Core-Lessons\Aula1\Aula1\Views\Default\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0a275ffefd05b6b6ea798bdc3bda948d1063028"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default_Index), @"mvc.1.0.view", @"/Views/Default/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0a275ffefd05b6b6ea798bdc3bda948d1063028", @"/Views/Default/Index.cshtml")]
    public class Views_Default_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\www\ASP.NET-Core-Lessons\Aula1\Aula1\Views\Default\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("estilos", async() => {
                WriteLiteral("\r\n    <style>\r\n        h1 {\r\n            color: red;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("javascript", async() => {
                WriteLiteral("\r\n    <script>\r\n        //JS\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<div>parte que vai mudar no layout</div>");
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