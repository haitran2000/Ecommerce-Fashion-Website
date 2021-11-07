#pragma checksum "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2acbf6144e9297916f3c8acd375f8f08d906f234"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PDFs_GetAllOrder), @"mvc.1.0.view", @"/Views/PDFs/GetAllOrder.cshtml")]
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
#line 1 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\_ViewImports.cshtml"
using Web_API_e_Fashion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\_ViewImports.cshtml"
using Web_API_e_Fashion.ServerToClientModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2acbf6144e9297916f3c8acd375f8f08d906f234", @"/Views/PDFs/GetAllOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a6c525d212b5a1f1b09226d5bac1da6a68154eb", @"/Views/_ViewImports.cshtml")]
    public class Views_PDFs_GetAllOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Web_API_e_Fashion.ServerToClientModels.HoaDonUser>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2acbf6144e9297916f3c8acd375f8f08d906f2343347", async() => {
                WriteLiteral(@"
    <title>Coza Store - Cửa hàng bán quần áo</title>
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" integrity=""sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"" crossorigin=""anonymous"">

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2acbf6144e9297916f3c8acd375f8f08d906f2344594", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div style=""background-color:cadetblue;text-align:center"">
            <h2 style=""color:azure; padding:5%"">
                TẤT CẢ HÓA DƠN
            </h2>
        </div>
        <table class=""table"" style=""text-align:left"">
            <tr>
                <th>Tên cửa hàng:</th>
                <td>Coza Store</td>
            </tr>
            <tr>
                <th>Địa chỉ:</th>
                <td>65/68/175, Ung Văn Khiêm, quận Bình Thạnh, TP-HCM</td>
            </tr>
            <tr>
                <th>Điện thoại:</th>
                <td>1800 2010 | 0989 866 266</td>
            </tr>
            <tr>
                <th>Email:</th>
                <td>cozastore@gmail.com</td>
            </tr>
            <tr>
                <th>Thông tin shop:</th>
                <td>Kinh doanh các mặt hàng thời trang chính như là các sản phẩm quần áo</td>
            </tr>
        </table>
    </div>

    <table class=""table"">
        <thead>");
                WriteLiteral(@"
            <tr>
                <th scope=""col"">Id</th>
                <th scope=""col"">Tên đầy đủ</th>
                <th scope=""col"">Ghi chú</th>
                <th scope=""col"">Ngày tạo</th>
                <th scope=""col"">Trạng thái</th>
                <th scope=""col"">Loại thanh toán</th>
                <th scope=""col"">Đã lấy tiền</th>
                <th scope=""col"">Tổng tiền</th>
                <th scope=""col"">Đã lấy tiền</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 56 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
             foreach (var hd in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 59 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                               Write(hd.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 60 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(hd.FullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 61 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(hd.GhiChu);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 62 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(hd.NgayTao);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 63 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(hd.TrangThai);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 64 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(hd.LoaiThanhToan);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 65 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(hd.DaLayTien);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 66 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(hd.TongTien);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 67 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(hd.DaLayTien);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 69 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n    <h5>Ngày xuất file: ");
#nullable restore
#line 74 "C:\Users\Admin\Music\DA\API\Web-API-e-Fashion\Views\PDFs\GetAllOrder.cshtml"
                   Write(DateTime.Now);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h5>

    <script src=""https://code.jquery.com/jquery-3.2.1.slim.min.js"" integrity=""sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"" crossorigin=""anonymous""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"" integrity=""sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"" crossorigin=""anonymous""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"" integrity=""sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"" crossorigin=""anonymous""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Web_API_e_Fashion.ServerToClientModels.HoaDonUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
