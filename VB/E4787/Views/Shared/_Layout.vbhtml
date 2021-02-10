<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    @Html.DevExpress().GetStyleSheets(
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
     New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
      New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}
)
    @Html.DevExpress().GetScripts(
    New Script With {.ExtensionSuite = ExtensionSuite.GridView},
        New Script With {.ExtensionSuite = ExtensionSuite.Editors},
            New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}
)
</head>
<body>
    @RenderBody()
</body>
</html>
