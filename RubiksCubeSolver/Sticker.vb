Public Class Sticker
    Inherits Button
    '                                    U              D                F               B                R                L
    Private faces() As Point = {New Point(1, 0), New Point(1, 2), New Point(1, 1), New Point(3, 1), New Point(2, 1), New Point(0, 1)}

    Private number As Integer
    Private x As Integer
    Private y As Integer
    Private face As Integer

    Sub New(col, num, f, Optional temp = False)
        Me.BackColor = col
        Me.number = num
        Me.x = num Mod 3
        Me.y = (num \ 3) Mod 3
        Me.face = f

        If f >= 0 And num >= 0 Then
            'Me.SetBounds(x * Me.Width + 10 + (faces(face).X * 250), y * Me.Width + 10 + (faces(face).Y * 250), 60, 60)
            'Form1.Controls.Add(Me)
        End If
    End Sub

    Public Sub setColour(col)
        Me.BackColor = col
    End Sub

    Public Function getCoords() As Point
        Return New Point(Me.x, Me.y)
    End Function

    Public Function getFace()
        Return Me.face
    End Function
End Class
