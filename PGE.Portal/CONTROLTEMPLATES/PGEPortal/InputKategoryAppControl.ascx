<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InputKategoryAppControl.ascx.cs" Inherits="PGE.Portal.CONTROLTEMPLATES.PGEPortal.InputKategoryAppControl" %>

<div id="wrapping" class="clearfix">
    <div class="border-list">	
        <div class="title-h2">Master Kategory Aplikasi</div>
        <div class="div">
             <table id="tblMasterKategoriApp" class="table">
                  <thead>                
                    <tr>                          
                       <th class="header-grid">Nama Kategori Aplikasi</th>                                              
                       <th class="header-grid">Action</th>
                    </tr>
                 </thead>
           </table>
        </div>
       <%-- <div class="button-template2">
            <input type="button" id="btnAddKategoriApp" value="Tambah"/>
        </div>
        --%>
        <div class="modal" id="modalMasterKategoriApp">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Detail Kategori</h4>
                    </div>
                    <div class="modal-body">
                        <div>                            
                            <div class="div">
                                <span class="lbl">Nama Kategori Aplikasi<span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <input name="txtNamaKategoriApp" class="input" maxlength="100" id="txtNamaKategoriApp" type="text" />
                            </div>                                                                                                     
                        </div>                
                    </div>
                    <div class="modal-footer">
                        <input type="button" id="btnSaveKategoriApp" value="Simpan" class="button"/>
                        <input type="button" data-dismiss="modal" value="Batal" class="button"/>                        
                    </div>
                </div>
            </div>
        </div>    
        	<div style="clear:both;"></div>
    </div>		
</div>

<script src="../../../_layouts/15/PGE.Portal/js/InputKategoriApp.js" type="text/javascript"></script>