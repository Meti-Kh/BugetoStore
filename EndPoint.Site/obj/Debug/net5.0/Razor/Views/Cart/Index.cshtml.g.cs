#pragma checksum "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d585a8257d11ab14e45d8a0daa24349b284d590"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\_ViewImports.cshtml"
using EndPoint.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\_ViewImports.cshtml"
using EndPoint.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d585a8257d11ab14e45d8a0daa24349b284d590", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87685c89e84078b3e134b89a928accf3d0f04a39", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyStore.Application.Services.Cart.CartDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("remove"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("c-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/pay/index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("checkout-button d-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    double sum = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"cart-home\">\r\n    <div class=\"post-item-cart d-block order-2\">\r\n        <div class=\"content-page\">\r\n            <div class=\"cart-form\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d585a8257d11ab14e45d8a0daa24349b284d5906257", async() => {
                WriteLiteral(@"
                    <table class=""table-cart cart table table-borderless"">
                        <thead>
                            <tr>
                                <th scope=""col"" class=""product-cart-name"">نام محصول</th>
                                <th scope=""col"" class=""product-cart-quantity"">تعداد مورد نیاز</th>
                                <th scope=""col"" class=""product-cart-price"">قیمت</th>
                                <th scope=""col"" class=""product-cart-Total"">مجموع</th>
                            </tr>
                        </thead>
                        <tbody>

");
#nullable restore
#line 24 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
                             foreach (var item in Model.CartItems)
                            {


#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <tr>
                                    <th scope=""row"" class=""product-cart-name"">
                                        <div class=""product-thumbnail-img"">
                                            <a href=""#"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5d585a8257d11ab14e45d8a0daa24349b284d5907739", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1385, "~/", 1385, 2, true);
#nullable restore
#line 31 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
AddHtmlAttributeValue("", 1387, item.Image, 1387, 11, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            </a>\r\n                                            <div class=\"product-remove\">\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d585a8257d11ab14e45d8a0daa24349b284d5909618", async() => {
                    WriteLiteral("\r\n                                                    <i class=\"mdi mdi-close\"></i>\r\n                                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1606, "~/cart/Delete/", 1606, 14, true);
#nullable restore
#line 34 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
AddHtmlAttributeValue("", 1620, item.ID, 1620, 8, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            </div>
                                        </div>
                                        <div class=""product-title"">
                                            <a href=""#"">
                                                ");
#nullable restore
#line 41 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
                                           Write(item.ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </a>

                                        </div>
                                    </th>
                                    <td class=""product-cart-quantity"">
                                        <div class=""required-number before"">
                                            <div class=""quantity"">
                                                <input type=""number"" min=""1"" max=""100"" step=""1""");
                BeginWriteAttribute("value", " value=\"", 2534, "\"", 2553, 1);
#nullable restore
#line 49 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2542, item.Count, 2542, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 2554, "\"", 2573, 2);
                WriteAttributeValue("", 2559, "count-", 2559, 6, true);
#nullable restore
#line 49 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2565, item.ID, 2565, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><div class=\"quantity-nav\"><div class=\"quantity-button quantity-up\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2641, "\"", 2671, 3);
                WriteAttributeValue("", 2651, "AddCount(\'", 2651, 10, true);
#nullable restore
#line 49 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2661, item.ID, 2661, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2669, "\')", 2669, 2, true);
                EndWriteAttribute();
                WriteLiteral(">+</div><div class=\"quantity-button quantity-down\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2722, "\"", 2752, 3);
                WriteAttributeValue("", 2732, "lowCount(\'", 2732, 10, true);
#nullable restore
#line 49 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2742, item.ID, 2742, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2750, "\')", 2750, 2, true);
                EndWriteAttribute();
                WriteLiteral(@">-</div></div>
                                            </div>
                                        </div>
                                    </td>
                                    <td class=""product-cart-price"">
                                        <span class=""amount"">
                                            ");
#nullable restore
#line 55 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
                                       Write(item.Price.ToString("n0"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            <span>تومان</span>
                                        </span>
                                    </td>
                                    <td class=""product-cart-Total"">
                                        <span class=""amount"">
");
#nullable restore
#line 61 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
                                              
                                                double total = item.Price * item.Count;
                                                sum += total;
                                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
#nullable restore
#line 65 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
                                       Write(total.ToString("n0"));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n                                            <span>تومان</span>\r\n                                        </span>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 70 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                        </tbody>\r\n                    </table>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""cart-collaterals"">
                <div class=""totals d-block"">
                    <h3 class=""Total-cart-total"">مجموع کل سبد خرید</h3>
                    <div class=""checkout-summary"">
                        <ul class=""checkout-summary-summary"">
                            <li class=""cart-subtotal"">
                                <span class=""amount"">قیمت کل</span>


                                <span> ");
#nullable restore
#line 86 "D:\پروزه فروشگاهی باگتو\MyStore\EndPoint.Site\Views\Cart\Index.cshtml"
                                  Write(sum.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" تومان</span>
                            </li>
                            <li class=""shipping-totals"">
                                <span class=""amount"">حمل و نقل</span>
                                <div class=""shipping-totals-item"">
                                    <div class=""shipping-totals-outline"">
                                        <label for=""#"" class=""outline-radio"">
                                            <input type=""radio"" name=""payment_method"" id=""payment-option-online"" checked=""checked"">
                                            <span class=""outline-radio-check""></span>
                                        </label>
                                        <label for=""#"" class=""shipping-totals-title-row"">
                                            <div class=""shipping-totals-title"">حمل و نقل رایگان</div>
                                        </label>
                                    </div>
                                    <div class=""shipping-totals-o");
            WriteLiteral(@"utline"">
                                        <label for=""#"" class=""outline-radio"">
                                            <input type=""radio"" name=""payment_method"" id=""payment-option-online"">
                                            <span class=""outline-radio-check""></span>
                                        </label>
                                        <label for=""#"" class=""shipping-totals-title-row"">
                                            <div class=""shipping-totals-title"">حمل و نقل معمولی: 20,000 تومان</div>
                                        </label>
                                    </div>
                                    <span class=""shipping-destination"">حمل و نقل به خراسان شمالی</span>
                                </div>
                            </li>
                            <li class=""order-total"">
                                <span class=""amount""> مجموع</span>
                                <span> 6,032,000 تومان</span>
                ");
            WriteLiteral(@"            </li>
                            <li class=""discount-code"">
                                <div class="" align-items-center"">
                                    <div class=""col-md-7 pr mt-5"">
                                        <div class=""coupon"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d585a8257d11ab14e45d8a0daa24349b284d59020838", async() => {
                WriteLiteral(@"
                                                <input type=""text"" name=""input-coupon"" class=""input-coupon-code"" placeholder=""كد تخفیف:"">
                                                <button class=""btn btn-coupon"" type=""submit"">اعمال</button>
                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""col-md-2 pl mt-5"">
                                        <div class=""proceed-to-checkout"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d585a8257d11ab14e45d8a0daa24349b284d59022738", async() => {
                WriteLiteral("تسویه حساب");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>


");
            DefineSection("Script", async() => {
                WriteLiteral(@"
    <script>

    function AddCount(CartItemId) {
        window.location.replace('/cart/add?CartItemId=' + CartItemId);
    }

    function lowCount(CartItemId) {
        window.location.replace('/cart/LowOff?CartItemId=' + CartItemId);
    }

    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyStore.Application.Services.Cart.CartDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
