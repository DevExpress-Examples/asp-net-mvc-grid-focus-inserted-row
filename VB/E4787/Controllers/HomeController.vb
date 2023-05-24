Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports E4787.Models

Namespace E4787.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		<ValidateInput(False)>
		Public Function GridViewPartial() As ActionResult
			Dim model = GetData()
			Return PartialView("_GridViewPartial", model)
		End Function

		Public Function AddNew(ByVal e As Entry) As ActionResult
			ViewData("newKey") = e.ID

			Dim model = GetData().ToList()
			model.Add(e)
			Return PartialView("_GridViewPartial", model)
		End Function

		Private Function GetData() As IEnumerable(Of Entry)
			Return Enumerable.Range(0, 5).Select(Function(i) New Entry With {
				.ID=i,
				.Text = "Text " & i
			})
		End Function

	End Class
End Namespace