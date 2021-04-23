using X.PagedList.Mvc.Core.Common;
using X.PagedList.Web.Common;

namespace Lib
{
    public class TablePagination : PagedListRenderOptions
    {
        public TablePagination()
        {
            ContainerDivClasses = new[] {"ms-auto"};
            UlElementClasses = new[] {"pagination m-0 ms-auto"};
            LiElementClasses = new[] {"page-item"};
            DisplayLinkToFirstPage = PagedListDisplayMode.Never;
            DisplayLinkToLastPage = PagedListDisplayMode.Never;
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always;
            DisplayLinkToNextPage = PagedListDisplayMode.Always;
            MaximumPageNumbersToDisplay = 5;
            LinkToPreviousPageFormat =
                @"<svg xmlns=""http://www.w3.org/2000/svg"" class=""icon icon-tabler icon-tabler-chevron-left"" width=""24"" height=""24"" viewBox=""0 0 24 24"" stroke-width=""2"" stroke=""currentColor"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round""><path stroke=""none"" d=""M0 0h24v24H0z"" fill=""none""></path><polyline points=""15 6 9 12 15 18""></polyline></svg>prev";
            LinkToNextPageFormat =
                "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"icon icon-tabler icon-tabler-chevron-right\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" stroke-width=\"2\" stroke=\"currentColor\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\">\n   <path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"></path>\n   <polyline points=\"9 6 15 12 9 18\"></polyline>\n</svg>";
            DisplayEllipsesWhenNotShowingAllPageNumbers = false;
            DisplayLinkToPreviousPage = PagedListDisplayMode.IfNeeded;
        }
    }
}