Public Class beta
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("WARNING ENABLING BRUHPROX WILL ALLOW YOU TO INSTALL THE CLIENT HOWEVER THE CLIENT IS CURRENTLY BROKEN DUE TO BRUHPROX BEING DOWN DO YOU WISH TO PROCEED?", MsgBoxStyle.YesNo, MsgBoxStyle.Question & "are you sure box")
        If MsgBoxResult.Yes Then
            MsgBox("yes")
        End If
        If MsgBoxResult.No Then
            MsgBox("no")
        End If
    End Sub
End Class