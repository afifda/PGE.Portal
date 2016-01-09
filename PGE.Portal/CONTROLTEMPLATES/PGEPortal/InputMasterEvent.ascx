<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InputMasterEvent.ascx.cs" Inherits="PGE.Portal.CONTROLTEMPLATES.PGEPortal.InputMasterEvent" %>

<div id="wrapping" class="clearfix">
    <div class="border-list">	
        <div class="title-h2">Master Main Event</div>
        <div class="div">
             <table id="tblMasterMainPic" class="table">
                  <thead>                
                    <tr>                          
                       <th class="header-grid">Title</th> 
                       <th class="header-grid">Date Event</th>
                        <th class="header-grid">Description</th>
                        <th class="header-grid">Picture Path</th>  
                        <th class="header-grid">File Name</th>                       
                       <th class="header-grid">Action</th>
                    </tr>
                 </thead>
           </table>
        </div>

         <div class="button-template2">
            <input type="button" id="btnAddMasterEvent" value="Tambah" class="button-template"/>
        </div>

    <div class="modal" id="modalMasterEvent">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Detail Main Event</h4>
                    </div>

                    <div class="modal-body">
                        <div class="div">
                                <span class="lbl">Title <span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <input name="txtTitle" class="input" maxlength="50" id="txtTitle" type="text" />
                        </div>  
                        <div class="div">
                                <span class="lbl">DataEvent <span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <input name="txtDataEvent" class="input" maxlength="50" id="txtDataEvent" type="text" />
                        </div>
                        <div class="div">
                                <span class="lbl">Event Description <span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <%--<input name="txtDesc" class="input" maxlength="50" id="txtDesc" type="text" />--%>
                                <textarea name="txtDesc" class="input-textarea-bottom" id="txtDesc" rows="10" cols="48"></textarea>
                        </div>  
                        <div>                                              
                            <div class="div">
                                <span class="lbl">Picture <span class="red">*</span></span>
                                <span class="titikdua">:</span>
                                <input type="file" id="fuAttachment" class="input" name="fuAttachment[]" multiple  /> <output id="list"></output> 
                            </div>                                                                                                       
                        </div>                
                    </div>
                    <div class="modal-footer">
                        <input type="button" id="btnSaveMasterEvent" value="Simpan" class="button-template"/>
                        <input type="button" data-dismiss="modal" value="Batal" class="button-template"/>                        
                    </div>
                </div>
            </div>
        </div> 
    
    <div class="modal" id="modalMasterMainEventDelete">
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
       <div style="clear:both;"></div>
    </div>  
</div>

<script src="../../../_layouts/15/PGE.Portal/js/InputMasterEvent.js"></script>
<script src="../../../_layouts/15/PGE.Portal/js/date.js"></script>
