﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PGE.Portal.HomePage {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    using System.CodeDom.Compiler;
    
    
    public partial class HomePage {
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebPartCodeGenerator", "12.0.0.0")]
        public static implicit operator global::System.Web.UI.TemplateControl(HomePage target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControlTree(global::PGE.Portal.HomePage.HomePage @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n<style>    \r\n       #pageContentTitle {display: none;}    \r\n       #WebPartTitl" +
                        "ectl00_ctl39_g_6efd3ae4_8d26_438c_94fc_8659cb59e90e  {display: none;} \r\n</style>" +
                        "\r\n\r\n    <div id=\"slide\">\r\n\t\t\r\n\t</div>\r\n\r\n\t\r\n\t\t\r\n\t\r\n\t\t\t\t\t\t\r\n\t<div class=\"content\"" +
                        ">\r\n\t\t<div class=\"content1\">\r\n\t\t\t<table id=\"tblMainCategory\" class=\"table-content" +
                        "\">\r\n              <tr id=\"MainCategory\" style=\"position:static\">\r\n\t\t\t\t\t\t\r\n\t\t\t  <" +
                        "/tr>\r\n\t\t\t</table>\r\n\t\t</div>\r\n\t\t\r\n\t\t\t\t\t\t\t\t\r\n\t\t<div class=\"gray-line\"></div>\r\n\t\t\t\t" +
                        "\t\t\t\r\n\t\t<div class=\"content1a\">\r\n\t\t\t<div class=\"title-content2\">Berita Terbaru</d" +
                        "iv>\r\n\t\t\t<div class=\"news-content2\">\r\n\t\t\t\t<table class=\"small-table-content2\" id=" +
                        "\"NewsView\">\r\n                             \r\n\t\t\t\t</table>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t" +
                        "\t<div class=\"content2a\">\r\n\t\t\t<div class=\"title-content2\">Acara</div>\r\n\t\t\t<div cl" +
                        "ass=\"news-content2\">\r\n\t\t\t    <table class=\"small-table-content2\" id=\"EventView\">" +
                        "\r\n                   \r\n               </table>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t\t\t\t\t\t\t\r\n\t\t" +
                        "<div class=\"gray-line\"></div>\r\n\t\t\t\t\t\t\t\r\n\t\t<div class=\"title-content3\">Gallery</d" +
                        "iv>\r\n\t\t<!-- #region Jssor Slider Begin -->\r\n\r\n\t\t<!-- Generated by Jssor Slider M" +
                        "aker Online. -->\r\n\t\t<!-- This demo works without jquery library. -->\r\n\t\t\t\t\t\t\r\n\t\t" +
                        "<script type=\"text/javascript\" src=\"/Style%20Library/jquery/jssor.slider.min.js\"" +
                        "></script>\r\n\t\t<!-- use jssor.slider.debug.js instead for debug -->\r\n\t\t<script>\r\n" +
                        "\t\t    jssor_1_slider_init = function () {\r\n\r\n\t\t        var jssor_1_options = {\r\n" +
                        "\t\t            $AutoPlay: true,\r\n\t\t            $AutoPlaySteps: 4,\r\n\t\t            " +
                        "$SlideDuration: 160,\r\n\t\t            $SlideWidth: 200,\r\n\t\t            $SlideSpaci" +
                        "ng: 3,\r\n\t\t            $Cols: 5,\r\n\t\t            $ArrowNavigatorOptions: {\r\n\t\t    " +
                        "            $Class: $JssorArrowNavigator$,\r\n\t\t                $Steps: 4\r\n\t\t     " +
                        "       },\r\n\t\t            $BulletNavigatorOptions: {\r\n\t\t                $Class: $" +
                        "JssorBulletNavigator$,\r\n\t\t                $SpacingX: 1,\r\n\t\t                $Spac" +
                        "ingY: 1\r\n\t\t            }\r\n\t\t        };\r\n\r\n\t\t        var jssor_1_slider = new $Js" +
                        "sorSlider$(\"jssor_1\", jssor_1_options);\r\n\r\n\t\t        //responsive code begin\r\n\t\t" +
                        "        //you can remove responsive code if you don\'t want the slider scales whi" +
                        "le window resizes\r\n\t\t        function ScaleSlider() {\r\n\t\t            var refSize" +
                        " = jssor_1_slider.$Elmt.parentNode.clientWidth;\r\n\t\t            if (refSize) {\r\n\t" +
                        "\t                refSize = Math.min(refSize, 809);\r\n\t\t                jssor_1_sl" +
                        "ider.$ScaleWidth(refSize);\r\n\t\t            }\r\n\t\t            else {\r\n\t\t           " +
                        "     window.setTimeout(ScaleSlider, 30);\r\n\t\t            }\r\n\t\t        }\r\n\t\t      " +
                        "  ScaleSlider();\r\n\t\t        $Jssor$.$AddEvent(window, \"load\", ScaleSlider);\r\n\t\t " +
                        "       $Jssor$.$AddEvent(window, \"resize\", $Jssor$.$WindowResizeFilter(window, S" +
                        "caleSlider));\r\n\t\t        $Jssor$.$AddEvent(window, \"orientationchange\", ScaleSli" +
                        "der);\r\n\t\t        //responsive code end\r\n\t\t    };\r\n\t\t</script>\r\n\t\t\t\t\t\t\t\r\n\t\t<div c" +
                        "lass=\"minislide\">\t\r\n\t\t\t<div class=\"minislidephoto\">\t\t\t\r\n\t\t\t\t<div id=\"jssor_1\" st" +
                        "yle=\"position: relative; margin: 0 auto; top: 0px; left: 0px; width: 809px; heig" +
                        "ht: 150px; visibility: hidden;\">\r\n\t\t\t\t\t<!-- Loading Screen -->\r\n\t\t\t\t\t<div data-u" +
                        "=\"loading\" style=\"position: absolute; top: 0px; left: 0px;\">\r\n\t\t\t\t\t\t<div style=\"" +
                        "filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top" +
                        ": 0px; left: 0px; width: 100%; height: 100%;\"></div>\r\n\t\t\t\t\t\t<div style=\"position" +
                        ":absolute;display:block;background:url(\'/Style%20Library/images/minislide/loadin" +
                        "g.gif\') no-repeat center center;top:0px;left:0px;width:100%;height:100%;\"></div>" +
                        "\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<div id=\"BottomPic\" data-u=\"slides\" style=\"cursor: default; " +
                        "position: relative; top: 0px; left: 0px; width: 809px; height: 150px; overflow: " +
                        "hidden;\">\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t\t<!-- Bullet Navigator -->\r\n\t\t\t\t<" +
                        "div data-u=\"navigator\" class=\"jssorb03\" style=\"bottom:10px;right:10px;\">\r\n\t\t\t\t\t<" +
                        "!-- bullet navigator item prototype -->\r\n\t\t\t\t\t<div data-u=\"prototype\" style=\"wid" +
                        "th:21px;height:21px;\">\r\n\t\t\t\t\t\t<div data-u=\"numbertemplate\"></div>\r\n\t\t\t\t\t</div>\r\n" +
                        "\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t\t\t\t    \t\r\n\t\t\t<!-- Arrow Navigator -->\r\n\t\t\t<span data-u" +
                        "=\"arrowleft\" class=\"jssora03l\" data-autocenter=\"2\"></span>\r\n\t\t\t<span data-u=\"arr" +
                        "owright\" class=\"jssora03r\" data-autocenter=\"2\"></span>\r\n\t\t</div>\r\n\t\t\t\t\t\t\t\r\n\t\t\r\n\t" +
                        "\t\t\r\n\t\t\r\n\t\t\t\t\t\t\r\n\t\t<!-- #endregion Jssor Slider End -->\r\n\t</div>\r\n\r\n\r\n<script src" +
                        "=\"../_layouts/15/PGE.Portal/js/HomePage.js\"></script>\r\n"));
        }
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
