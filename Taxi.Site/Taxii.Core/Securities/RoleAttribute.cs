using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxii.Core.Interfaces;

namespace Taxii.Core.Securities
{
    public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private  IAccountService _accountService;
        private string _roleName;
        public RoleAttribute(string roleName)
        {
            _roleName = roleName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Identity.Name;
                _accountService =(IAccountService) context.HttpContext.RequestServices.GetService(typeof(IAccountService));
                if (! _accountService.CheckUserRole(_roleName,userName))
                {
                    context.Result = new RedirectResult("/Account/Register");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Register");
            }
        }
    }
}
