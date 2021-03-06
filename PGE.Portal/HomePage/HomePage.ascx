﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomePage.ascx.cs" Inherits="PGE.Portal.HomePage.HomePage" %>
<style>    
       #pageContentTitle {display: none;}    
       #WebPartTitlectl00_ctl39_g_6efd3ae4_8d26_438c_94fc_8659cb59e90e  {display: none;} 
</style>

    <div id="slide">
		<%--<a href="#" target="_blank">
			<img src="/Style%20Library/images/slideshow/1.jpg" alt="images1" />
		</a>
		<a href="#" target="_blank">
			<img src="/Style%20Library/images/slideshow/2.jpg" alt="images2" />
		</a>
		<a href="#" target="_blank">
			<img src="/Style%20Library/images/slideshow/3.jpg" alt="images3" />
		</a>
		<a href="#" target="_blank">
			<img src="/Style%20Library/images/slideshow/4.jpg" alt="images4" />
		</a>
		<a href="#" target="_blank">
			<img src="/Style%20Library/images/slideshow/5.JPG" alt="images5" />
		</a>
		<a href="#" target="_blank">
			<img src="/Style%20Library/images/slideshow/6.JPG" alt="images6" />
		</a>--%>
	</div>

	<%--<script type="text/javascript">--%>
		<%--$('#slide').coinslider();--%>
	<%--</script>--%>
						
	<div class="content">
		<div class="content1">
			<table id="tblMainCategory" class="table-content">
              <tr id="MainCategory" style="position:static">
				<%--<td class="td-content">
					<div class="title-content">Manajemen</div>
					<div class="news-content">
					Humas CSR<br />Good Of Goverment<br />
					Time Sheet<br />e-workflow<br />
					Daily Reporting
					</div>
				</td>		--%>		
			  </tr>
			</table>
		</div>
		<%--<div class="content2">
			<table class="table-content"><tr>
				<td class="td-content">
					<div class="title-content">Manajemen</div>
					<div class="news-content">
					Humas CSR<br />Good Of Goverment<br />
					Time Sheet<br />e-workflow<br />
					Daily Reporting
					</div>
				</td>
				<td class="td-content">
					<div class="title-content">Manajemen</div>
					<div class="news-content">
					Humas CSR<br />Good Of Goverment<br />
					Time Sheet<br />e-workflow<br />
					Daily Reporting
					</div>
				</td>
			</tr></table>
		</div>--%>
								
		<div class="gray-line"></div>
							
		<div class="content1a">
			<div class="title-content2">Berita Terbaru</div>
			<div class="news-content2">
				<table class="small-table-content2" id="NewsView">
                             
				</table>
			</div>
		</div>
		<div class="content2a">
			<div class="title-content2">Acara</div>
			<div class="news-content2">
			    <table class="small-table-content2" id="EventView">
                   
               </table>
			</div>
		</div>
							
		<div class="gray-line"></div>
							
		<div class="title-content3">Gallery</div>
		<!-- #region Jssor Slider Begin -->

		<!-- Generated by Jssor Slider Maker Online. -->
		<!-- This demo works without jquery library. -->
						
		<script type="text/javascript" src="/sites/PGEPortal/Style%20Library/jquery/jssor.slider.min.js"></script>
		<!-- use jssor.slider.debug.js instead for debug -->
		<script>
		    jssor_1_slider_init = function () {

		        var jssor_1_options = {
		            $AutoPlay: true,
		            $AutoPlaySteps: 4,
		            $SlideDuration: 160,
		            $SlideWidth: 200,
		            $SlideSpacing: 3,
		            $Cols: 5,
		            $ArrowNavigatorOptions: {
		                $Class: $JssorArrowNavigator$,
		                $Steps: 4
		            },
		            $BulletNavigatorOptions: {
		                $Class: $JssorBulletNavigator$,
		                $SpacingX: 1,
		                $SpacingY: 1
		            }
		        };

		        var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

		        //responsive code begin
		        //you can remove responsive code if you don't want the slider scales while window resizes
		        function ScaleSlider() {
		            var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
		            if (refSize) {
		                refSize = Math.min(refSize, 809);
		                jssor_1_slider.$ScaleWidth(refSize);
		            }
		            else {
		                window.setTimeout(ScaleSlider, 30);
		            }
		        }
		        ScaleSlider();
		        $Jssor$.$AddEvent(window, "load", ScaleSlider);
		        $Jssor$.$AddEvent(window, "resize", $Jssor$.$WindowResizeFilter(window, ScaleSlider));
		        $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
		        //responsive code end
		    };
		</script>
							
		<div class="minislide">	
			<div class="minislidephoto">			
				<div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 809px; height: 150px; visibility: hidden;">
					<!-- Loading Screen -->
					<div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
						<div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
						<div style="position:absolute;display:block;background:url('/sites/PGEPortal/Style%20Library/Images/minislide/loading.gif') no-repeat center center;top:0px;left:0px;width:100%;height:100%;"></div>
					</div>
					<div id="BottomPic" data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 809px; height: 150px; overflow: hidden;">
						<%--<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/005.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/006.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/011.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/013.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/014.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/019.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/020.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/021.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/022.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/024.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/025.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/027.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/029.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/030.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/031.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/030.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/034.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/038.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/039.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/043.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/044.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/047.jpg" />
						</div>
						<div style="display: none;">
							<img data-u="image" src="/Style%20Library/images/minislide/050.jpg" />
						</div>--%>
					</div>
				</div>
				<!-- Bullet Navigator -->
				<div data-u="navigator" class="jssorb03" style="bottom:10px;right:10px;">
					<!-- bullet navigator item prototype -->
					<div data-u="prototype" style="width:21px;height:21px;">
						<div data-u="numbertemplate"></div>
					</div>
				</div>
			</div>
						    	
			<!-- Arrow Navigator -->
			<span data-u="arrowleft" class="jssora03l" data-autocenter="2"></span>
			<span data-u="arrowright" class="jssora03r" data-autocenter="2"></span>
		</div>
							
		<%--<script>--%>
			<%--jssor_1_slider_init();--%>
		<%--</script>--%>
						
		<!-- #endregion Jssor Slider End -->
	</div>


<script src="../_layouts/15/PGE.Portal/js/HomePage.js"></script>
