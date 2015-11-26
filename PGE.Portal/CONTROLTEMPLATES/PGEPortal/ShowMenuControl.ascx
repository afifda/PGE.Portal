﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowMenuControl.ascx.cs" Inherits="PGE.Portal.CONTROLTEMPLATES.PGEPortal.ShowMenuControl" %>

<div class="container">
      <!-- Static navbar -->
      <div class="navbar navbar-default" role="navigation">
        <div class="navbar-header">
          	<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          	</button>
        </div>
        <div class="navbar-collapse collapse">

          <!-- Left nav -->
          <ul class="nav navbar-nav">
            <li><a href="#">Link</a></li>
            <li><a href="#">Link</a></li>
            <li><a href="#">Link</a></li>
            <li><a href="#">Dropdown <span class="caret"></span></a>
              <ul class="dropdown-menu">
                <li><a href="#">Action</a></li>
                <li><a href="#">Another action</a></li>
                <li><a href="#">Something else here</a></li>
                <li class="divider"></li>
                <li class="dropdown-header">Nav header</li>
                <li><a href="#">Separated link</a></li>
                <li><a href="#">One more separated link <span class="caret"></span></a>
                  <ul class="dropdown-menu">
                    <li><a href="#">Action</a></li>
                    <li><a href="#">Another action</a></li>
                    <li><a href="#">A long sub menu <span class="caret"></span></a>
                      <ul class="dropdown-menu">
                        <li><a href="#">Action</a></li>
                        <li><a href="#">Something else here</a></li>
                        <li class="disabled"><a class="disabled" href="#">Disabled item</a></li>
                        <li><a href="#">One more link</a></li>
                        <li><a href="#">Menu item 1</a></li>
                        <li><a href="#">Menu item 2</a></li>
                        <li><a href="#">Menu item 3</a></li>
                        <li><a href="#">Menu item 4</a></li>
                        <li><a href="#">Menu item 5</a></li>
                        <li><a href="#">Menu item 6</a></li>
                        <li><a href="#">Menu item 7</a></li>
                        <li><a href="#">Menu item 8</a></li>
                        <li><a href="#">Menu item 9</a></li>
                        <li><a href="#">Menu item 10</a></li>
                        <li><a href="#">Menu item 11</a></li>
                        <li><a href="#">Menu item 12</a></li>
                        <li><a href="#">Menu item 13</a></li>
                        <li><a href="#">Menu item 14</a></li>
                        <li><a href="#">Menu item 15</a></li>
                        <li><a href="#">Menu item 16</a></li>
                        <li><a href="#">Menu item 17</a></li>
                        <li><a href="#">Menu item 18</a></li>
                        <li><a href="#">Menu item 19</a></li>
                        <li><a href="#">Menu item 20</a></li>
                        <li><a href="#">Menu item 21</a></li>
                        <li><a href="#">Menu item 22</a></li>
                        <li><a href="#">Menu item 23</a></li>
                        <li><a href="#">Menu item 24</a></li>
                        <li><a href="#">Menu item 25</a></li>
                        <li><a href="#">Menu item 26</a></li>
                        <li><a href="#">Menu item 27</a></li>
                        <li><a href="#">Menu item 28</a></li>
                        <li><a href="#">Menu item 29</a></li>
                        <li><a href="#">Menu item 30</a></li>
                        <li><a href="#">Menu item 31</a></li>
                        <li><a href="#">Menu item 32</a></li>
                        <li><a href="#">Menu item 33</a></li>
                        <li><a href="#">Menu item 34</a></li>
                        <li><a href="#">Menu item 35</a></li>
                        <li><a href="#">Menu item 36</a></li>
                        <li><a href="#">Menu item 37</a></li>
                        <li><a href="#">Menu item 38</a></li>
                        <li><a href="#">Menu item 39</a></li>
                        <li><a href="#">Menu item 40</a></li>
                        <li><a href="#">Menu item 41</a></li>
                        <li><a href="#">Menu item 42</a></li>
                        <li><a href="#">Menu item 43</a></li>
                        <li><a href="#">Menu item 44</a></li>
                        <li><a href="#">Menu item 45</a></li>
                        <li><a href="#">Menu item 46</a></li>
                        <li><a href="#">Menu item 47</a></li>
                        <li><a href="#">Menu item 48</a></li>
                        <li><a href="#">Menu item 49</a></li>
                        <li><a href="#">Menu item 50</a></li>
                        <li><a href="#">Menu item 51</a></li>
                        <li><a href="#">Menu item 52</a></li>
                        <li><a href="#">Menu item 53</a></li>
                        <li><a href="#">Menu item 54</a></li>
                        <li><a href="#">Menu item 55</a></li>
                        <li><a href="#">Menu item 56</a></li>
                        <li><a href="#">Menu item 57</a></li>
                        <li><a href="#">Menu item 58</a></li>
                        <li><a href="#">Menu item 59</a></li>
                        <li><a href="#">Menu item 60</a></li>
                      </ul>
                    </li>
                    <li><a href="#">Another link</a></li>
                    <li><a href="#">One more link</a></li>
                  </ul>
                </li>
              </ul>
            </li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
	  
	  <div class="navbar-bwh"></div>

    </div>