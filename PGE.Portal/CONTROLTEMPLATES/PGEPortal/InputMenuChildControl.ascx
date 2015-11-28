<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InputMenuChildControl.ascx.cs" Inherits="PGE.Portal.CONTROLTEMPLATES.PGEPortal.InputMenuChildControl" %>
  <div id="wrapping" class="clearfix">
        <div class="title-h1">Master Main Menu Child</div>
        <div class="div">
             <table id="tblMasterMenuChild" class="tabelgrid">
                  <thead>                
                    <tr>                          
                       <th class="header-grid">Parent Menu Name</th> 
                       <th class="header-grid">Child Menu Name</th>
                       <th class="header-grid">Url Child Menu</th>
                       <th class="header-grid">Action</th>
                    </tr>
                 </thead>
           </table>
        </div>
        <div class="button-template2">
            <input type="button" id="btnAddMasterMenuChild" value="Tambah"/>
        </div>
        
        <div class="modal" id="modalMasterMenuChild">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Detail Menu</h4>
                    </div>
                    <div class="modal-body">
                        <div>            
                            <div class="div">
                                <span class="lbl">Parent Menu Name <span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <select id="ddlParentName" class="input"></select>                
                            </div>                
                            <div class="div">
                                <span class="lbl">Child Menu Name <span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <input  id="txtMenuChildName" class="input" maxlength="50" name="txtMenuChildName" type="text" />
                            </div>                             
                            <div class="div">
                                <span class="lbl">Url Child Menu <span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <input id="txtUrl" class="input" name="txtUrl" type="text"/>
                            </div>                                                
                        </div>                
                    </div>
                    <div class="modal-footer">
                        <input type="button" id="btnSaveMasterMenuChild" value="Simpan" class="button"/>
                        <input type="button" data-dismiss="modal" value="Batal" class="button"/>                        
                    </div>
                </div>
            </div>
        </div>    
    </div>

<script src="../../../_layouts/15/PGE.Portal/js/InputMenuChild.js" type="text/javascript"></script>
