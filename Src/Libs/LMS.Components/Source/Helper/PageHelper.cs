using System.Collections.Specialized;
using Microsoft.AspNetCore.Components;

namespace LMS.Components.Source.Helper;

public class PageHelper(NavigationManager navigationManager)
{
    public string? GetUrlQueryParam(string key)
    {
        Uri uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);
        NameValueCollection query = System.Web.HttpUtility.ParseQueryString(uri.Query);
        return query[key];
    }
}