using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace PowerLog.Web
{
    public static class ControllerHelperExtension
    {
        public static int GetUserId(this Controller controller)
        {
            var userId = WebSecurity.GetUserId(controller.User.Identity.Name);
            return userId;
        }
    }
}