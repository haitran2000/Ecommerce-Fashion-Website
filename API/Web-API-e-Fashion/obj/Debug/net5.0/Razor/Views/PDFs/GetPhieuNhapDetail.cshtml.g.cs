#pragma checksum "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec5ee8e5dd97f2e2e83196e13a585cfdfae3049a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PDFs_GetPhieuNhapDetail), @"mvc.1.0.view", @"/Views/PDFs/GetPhieuNhapDetail.cshtml")]
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
#line 1 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\_ViewImports.cshtml"
using Web_API_e_Fashion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\_ViewImports.cshtml"
using Web_API_e_Fashion.ServerToClientModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec5ee8e5dd97f2e2e83196e13a585cfdfae3049a", @"/Views/PDFs/GetPhieuNhapDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a6c525d212b5a1f1b09226d5bac1da6a68154eb", @"/Views/_ViewImports.cshtml")]
    public class Views_PDFs_GetPhieuNhapDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web_API_e_Fashion.ServerToClientModels.PhieuNhapChiTietPhieuNhap>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec5ee8e5dd97f2e2e83196e13a585cfdfae3049a3483", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec5ee8e5dd97f2e2e83196e13a585cfdfae3049a4730", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div style=""background-color:cadetblue;text-align:center"">
            <h2 style=""color:azure; padding:5%"">
                CHI TIẾT PHIẾU NHẬP HÀNG
            </h2>
        </div>
        <div class=""row"">
            <div class=""col"">
                <h3>Bên gửi</h3>
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
           ");
                WriteLiteral(@"         <tr>
                        <th>Thông tin shop:</th>
                        <td>Kinh doanh các mặt hàng thời trang chính như là các sản phẩm quần áo</td>
                    </tr>
                </table>
            </div>

            <div class=""col"">
                <h3>Bên nhận</h3>
                <table class=""table"" style=""text-align:left"">
                    <tr>
                        <th>Mã nhà cung cấp :</th>
                        <td>");
#nullable restore
#line 49 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                       Write(Model.NhaCungCap.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>Tên :</th>\r\n                        <td>");
#nullable restore
#line 53 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                       Write(Model.NhaCungCap.Ten);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>Địa chỉ:</th>\r\n                        <td>");
#nullable restore
#line 57 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                       Write(Model.NhaCungCap.DiaChi);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>Điện thoại:</th>\r\n                        <td>");
#nullable restore
#line 61 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                       Write(Model.NhaCungCap.SDT);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th>Thông tin:</th>\r\n                        <td>");
#nullable restore
#line 65 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                       Write(Model.NhaCungCap.ThongTin);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    </tr>\r\n\r\n                </table>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n    <br>\r\n    <table class=\"table\" style=\"text-align:left\">\r\n        <tr>\r\n            <th>Mã phiếu nhập :</th>\r\n            <td>");
#nullable restore
#line 77 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
           Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Số chứng từ:</th>\r\n            <td>");
#nullable restore
#line 81 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
           Write(Model.SoChungTu);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Ngày tạo:</th>\r\n            <td>");
#nullable restore
#line 85 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
           Write(Model.NgayTao);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Ngày tạo:</th>\r\n            <td>");
#nullable restore
#line 89 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
           Write(Model.NgayTao);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Ghi chú:</th>\r\n            <td>");
#nullable restore
#line 93 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
           Write(Model.GhiChu);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
        </tr>

  
      

    </table>
    <br>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">Id</th>
                <th scope=""col"">Tên (tên sản phẩm + màu + size)</th>
                <th scope=""col"">Giá nhập</th>
                <th scope=""col"">Số lượng nhập</th>
                <th scope=""col"">Thành tiền nhập</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 112 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
             foreach (var ctpn in Model.ChiTietPhieuNhaps)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 115 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                               Write(ctpn.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 116 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                   Write(ctpn.TenSanPhamBienTheMauSize);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 117 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                   Write(ctpn.GiaNhap);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 118 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                   Write(ctpn.SoluongNhap);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 119 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                   Write(ctpn.ThanhTienNhap);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 121 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </tbody>
    </table>
    <div class=""row"">
        <div class=""col"">
            <h4>Người lập phiếu</h4>
            <img src=""https://dvdn247.net/wp-content/uploads/2020/07/22-1.jpg"" alt=""Alternate Text"" style=""width:150px"" />
            <h4>");
#nullable restore
#line 129 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
           Write(Model.NguoiLapPhieu);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h4>
        </div>
        <div class=""col"">
            <table class=""table"">
                <tbody>
                    <tr>
                        <td class=""left"">
                            <strong class=""text-dark"">Tổng tiền: </strong>
                        </td>
                        <td class=""right"">
                            <strong class=""text-dark"">");
#nullable restore
#line 139 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
                                                 Write(Model.TongTien);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n                        </td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n    <h5>Ngày xuất file: ");
#nullable restore
#line 147 "D:\-DO-AN-TOT-NGHIEP\API- Vinh\Ecommerce-Fashion-Website\API\Web-API-e-Fashion\Views\PDFs\GetPhieuNhapDetail.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web_API_e_Fashion.ServerToClientModels.PhieuNhapChiTietPhieuNhap> Html { get; private set; }
    }
}
#pragma warning restore 1591