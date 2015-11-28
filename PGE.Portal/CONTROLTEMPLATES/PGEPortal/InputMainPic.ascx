<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InputMainPic.ascx.cs" Inherits="PGE.Portal.CONTROLTEMPLATES.PGEPortal.InputMainPic" %>

<div id="wrapping" class="clearfix">
        <div class="title-h2">Master Main Picture</div>
        <div class="div">
             <table id="tblMasterMainPic" class="table">
                  <thead>                
                    <tr>                          
                       <th class="header-grid">Picture Name</th> 
                       <th class="header-grid">Picture Path</th>                       
                       <th class="header-grid">Action</th>
                    </tr>
                 </thead>
           </table>
        </div>

         <div class="button-template2">
            <input type="button" id="btnAddMasterMainPic" value="Tambah" class="button-template"/>
        </div>

    <div class="modal" id="modalMasterMainPic">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Detail Main Picture</h4>
                    </div>
                    <div class="modal-body">
                        <div>                                              
                            <div class="div">
                                <span class="lbl">Picture <span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <input type="file" id="fuAttachment" class="input" name="fuAttachment[]" multiple  /> <output id="list"></output> 
                            </div>                                                                                                       
                        </div>                
                    </div>
                    <div class="modal-footer">
                        <input type="button" id="btnSaveMasterMainPic" value="Simpan" class="button-template"/>
                        <input type="button" data-dismiss="modal" value="Batal" class="button-template"/>                        
                    </div>
                </div>
            </div>
        </div> 
    
    <div class="modal" id="modalMasterMainPicDelete">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Confirm Delete Main Picture</h4>
                    </div>    
                    <div class="modal-body">
                        <div>                                                                                                                                         
                            <input name="hfdelrow" class="input" maxlength="50" id="hfdelrow" type="text" />
                        </div>                
                    </div>                
                    <div class="modal-footer">
                        <input type="button" id="btnDelMainPic" value="Yes" class="button-template"/>
                        <input type="button" data-dismiss="modal" value="No" class="button-template"/>                        
                    </div>
                </div>
            </div>
        </div>   
</div>

<script src="../../../_layouts/15/PGE.Portal/js/InputMainPic.js" type="text/javascript"></script>
