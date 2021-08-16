using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Dz5Routing
{
    public enum Colors
    {
        red = 0,
        blue = 1,
        green = 2,
        yellow = 3
    }
    public class CustRouteConstraint : IRouteConstraint
    {
        private readonly string _mathingString = "";

        public CustRouteConstraint(string mathingString)
        {
            _mathingString = mathingString;
        }
        public CustRouteConstraint() { }

        public bool Match(
            HttpContext httpContext, 
            IRouter route, 
            string routeKey, 
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            var value = (string)values[routeKey];

            if (_mathingString.Length > 0)
            {
                return value == _mathingString;
            }

            return (
                value == Colors.blue.ToString() 
                || value == Colors.green.ToString()
                || value == Colors.red.ToString()
                || value == Colors.yellow.ToString()
            );
        }
    }
}
