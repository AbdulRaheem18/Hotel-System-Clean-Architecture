using System.Collections.Generic;

namespace application.Features.Responses
{
    public class BaseFeatureResponse
    {
        public bool Success{get;set;}
        public List<string> Errors{get;set;}
        public string RequestId{get;set;}
        public BaseFeatureResponse()
        {
            Errors = new List<string>();
            Success = true;
        }
        
    }
}