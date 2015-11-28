using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Runtime.InteropServices;

namespace PGE.Portal.Layouts
{
    [Guid("1aa2f88c-84c8-42f9-b349-451ceaf205df")]
    public partial class GenericPortal : IHttpHandler
    {        
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["Method"];
            switch (method.ToLower())
            {           
                default:
                    break;
            }
        }
    }
}
