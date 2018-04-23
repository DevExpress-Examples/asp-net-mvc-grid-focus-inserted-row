@Code
    Dim grid = Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "GridView"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

            settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "AddNew"}

            settings.KeyFieldName = "ID"

            settings.SettingsPager.Visible = False
            settings.Settings.ShowGroupPanel = False
            settings.Settings.ShowFilterRow = False
            settings.SettingsBehavior.AllowSelectByRowClick = False
            settings.SettingsBehavior.AllowFocusedRow = True

            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowNewButton = True
        
            settings.Columns.Add("ID")
            settings.Columns.Add("Text")

            settings.BeforeGetCallbackResult =
                Sub(s, e)
                    Dim gridView = TryCast(s, MVCxGridView)
                    gridView.FocusedRowIndex = gridView.FindVisibleIndexByKeyValue(ViewData("newKey"))
            End Sub
    End Sub)
End Code
@Code grid.Bind(Model).GetHtml() End Code