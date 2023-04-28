<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550086/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4787)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Grid View for ASP.NET MVC - How to focus the newly inserted row
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4787/)**
<!-- run online end -->

This example demonstrates how to use the grid's AddNewRowRouteValues property to focus the newly inserted row.

## Overview

After the grid adds a new row to the data source, you can get the row's key value in an action specified by the grid's [AddNewRowRouteValues](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.MVCxGridViewEditingSettings.AddNewRowRouteValues) property. To focus the newly inserted row, handle the grid's [BeforeGetCallbackResult](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridSettingsBase.BeforeGetCallbackResult) event and do the followng in the handler:

* Call the grid's [FindVisibleIndexByKeyValue](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.FindVisibleIndexByKeyValue(System.Object)) method to get the row's visible index.
* Assign that index to the grid's [FocusedRowIndex](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.FocusedRowIndex) property.

```cshtml
var grid = Html.DevExpress().GridView(settings => {
    settings.Name = "GridView";
    settings.CallbackRouteValues = new { Controller = "Home", Action = "GridViewPartial" };
    settings.SettingsEditing.AddNewRowRouteValues = new { Controller = "Home", Action = "AddNew" };
    settings.KeyFieldName = "ID";
    <!-- ... -->
    settings.BeforeGetCallbackResult = (s, e) => {
        var gridView = s as MVCxGridView;
        gridView.FocusedRowIndex = gridView.FindVisibleIndexByKeyValue(ViewData["newKey"]);
    };
});
```

```csharp
public ActionResult AddNew(Entry e) {
    ViewData["newKey"] = e.ID;
    var model = GetData().ToList();
    model.Add(e);
    return PartialView("_GridViewPartial", model);
}
```

## Files to Review

* [HomeController.cs](./CS/E4787/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/E4787/Controllers/HomeController.vb))
* [GridViewPartial.cshtml](./CS/E4787/Views/Home/_GridViewPartial.cshtml) (VB: [GridViewPartial.vbhtml](./VB/E4787/Views/Home/_GridViewPartial.vbhtml))

## More Examples

* [Grid View for ASP.NET Web Forms - How to focus the newly inserted rows](https://github.com/DevExpress-Examples/asp-net-web-forms-grid-focus-inserted-row)


