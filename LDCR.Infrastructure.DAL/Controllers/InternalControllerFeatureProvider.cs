using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace LDCR.Infrastructure.Controllers
{
    public class InternalControllerFeatureProvider : ControllerFeatureProvider
    {
        /// <summary>
        /// Used for checking if a certain class is a Controller or not
        /// </summary>
        protected override bool IsController(TypeInfo typeInfo)
        {
            if (!typeInfo.IsClass) 
                return false;
            
            if (typeInfo.IsAbstract) 
                return false;
            
            if (typeInfo.ContainsGenericParameters) 
                return false;
            
            if (typeInfo.IsDefined(typeof(NonControllerAttribute))) 
                return false;

            return typeInfo.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) || typeInfo.IsDefined(typeof(ControllerAttribute));
        }
    }
}
