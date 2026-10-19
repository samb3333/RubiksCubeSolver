Public Class Face
    Private rows(1) As line
    Private colls(1) As line
    Public stickers(8) As Sticker
    Sub New(col, num)

        For x = 0 To 8
            stickers(x) = New Sticker(col, x, num)
        Next

        rows(0) = New line()
        rows(0).stickers(0) = stickers(0)
        rows(0).stickers(1) = stickers(1)
        rows(0).stickers(2) = stickers(2)

        rows(1) = New line()
        rows(1).stickers(0) = stickers(6)
        rows(1).stickers(1) = stickers(7)
        rows(1).stickers(2) = stickers(8)

        colls(0) = New line()
        colls(0).stickers(0) = stickers(0)
        colls(0).stickers(1) = stickers(3)
        colls(0).stickers(2) = stickers(6)

        colls(1) = New line()
        colls(1).stickers(0) = stickers(2)
        colls(1).stickers(1) = stickers(5)
        colls(1).stickers(2) = stickers(8)


    End Sub

    Public Function getRow(num)
        Return rows(num)
    End Function
    Public Function getColl(num)
        Return colls(num)
    End Function

    Public Sub setRow(num As Integer, row As line)
        For x = 0 To 2
            rows(num).stickers(x).setColour(row.stickers(x).BackColor)
        Next
    End Sub
    Public Sub setColl(num As Integer, Coll As line)
        For x = 0 To 2
            colls(num).stickers(x).setColour(Coll.stickers(x).BackColor)
        Next
    End Sub

    Public Sub rotateFace(direction As Integer)
        ' direction: 1 = clockwise, -1 = anticlockwise
        Dim old(8) As Color
        For i = 0 To 8
            old(i) = stickers(i).BackColor
        Next

        ' new sticker i takes colour from old sticker map(i)
        Dim cw() As Integer = {6, 3, 0, 7, 4, 1, 8, 5, 2}
        Dim acw() As Integer = {2, 5, 8, 1, 4, 7, 0, 3, 6}
        Dim map() As Integer = If(direction = 1, cw, acw)

        For i = 0 To 8
            stickers(i).setColour(old(map(i)))
        Next
    End Sub
End Class

Public Class line
    Public stickers(2) As Sticker
    Sub New()

    End Sub

    Sub New(source As line)
        stickers(0) = New Sticker(source.stickers(0).BackColor, -1, -1)
        stickers(1) = New Sticker(source.stickers(1).BackColor, -1, -1)
        stickers(2) = New Sticker(source.stickers(2).BackColor, -1, -1)
    End Sub

    Public Function reversed() As line
        Dim r As New line(Me)

        For x = 0 To 2
            r.stickers(x).BackColor = Me.stickers(2 - x).BackColor
        Next
        Return r
    End Function
End Class