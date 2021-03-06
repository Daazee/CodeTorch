﻿using CodeTorch.Core;
using CodeTorch.Core.Commands;
using System;
using System.Linq;
using System.Web;

namespace CodeTorch.Web.ActionCommands
{
    public class NavigateToUrlActionCommand : IActionCommandStrategy
    {
        public Templates.BasePage Page { get; set; }

  

        public ActionCommand Command { get; set; }

        NavigateToUrlCommand Me = null;
        


        public void ExecuteCommand()
        {
            

            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                if (Command != null)
                {
                    Me = (NavigateToUrlCommand)Command;
                }

                if (String.IsNullOrEmpty(Me.NavigateUrl))
                {
                    throw new ApplicationException("NavigateUrl is invalid");
                }
                string url = Common.CreateUrlWithQueryStringContext(Me.NavigateUrl, Me.Context);
                url = String.Format(url, Page.Request.QueryString[Me.EntityID]);

                log.DebugFormat("RedirectUrl:{0}", url);
                Page.Response.Redirect(url,false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                Page.DisplayErrorAlert(ex);

                log.Error(ex);
            }
            
        }



        
    }
}
