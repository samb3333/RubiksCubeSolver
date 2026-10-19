Public Class Cube

    Dim faces(5) As Face
    Sub New()
        faces(0) = New Face(Color.White, 0)
        faces(1) = New Face(Color.Yellow, 1)
        faces(2) = New Face(Color.Red, 2)
        faces(3) = New Face(Color.Orange, 3)
        faces(4) = New Face(Color.Blue, 4)
        faces(5) = New Face(Color.Green, 5)

    End Sub

    Public Sub solve()
        Dim complete As Boolean = True
        For i = 1 To 7 Step 2
            If faces(1).stickers(i).BackColor <> Color.White Then
                complete = False
            End If
        Next

        If complete = False Then
            ' find white edge
            For x = 2 To 5
                For y = 1 To 7 Step 2
                    If faces(x).stickers(y).BackColor = Color.White Then
                        If x <= 3 And (y = 3 Or y = 5) Then
                            Dim moves() As String = {"LPrime", "R", "RPrime", "L"}

                            move(moves((x - 2) * 2 + (y - 3) / 2))
                        End If

                        Return
                    End If
                Next
            Next
        End If

    End Sub

    Public Sub move(name)
        Select Case name
            Case Is = "U"
                Dim temp As New line(faces(2).getRow(0))
                faces(2).setRow(0, faces(4).getRow(0))                 ' F <- R
                faces(4).setRow(0, faces(3).getRow(0))                 ' R <- B
                faces(3).setRow(0, faces(5).getRow(0))                 ' B <- L
                faces(5).setRow(0, temp)                               ' L <- F
                faces(0).rotateFace(1)

            Case Is = "D"
                Dim temp As New line(faces(2).getRow(1))
                faces(2).setRow(1, faces(5).getRow(1))                 ' F <- L
                faces(5).setRow(1, faces(3).getRow(1))                 ' L <- B
                faces(3).setRow(1, faces(4).getRow(1))                 ' B <- R
                faces(4).setRow(1, temp)                               ' R <- F
                faces(1).rotateFace(1)

            Case Is = "L"
                Dim temp As New line(faces(2).getColl(0))
                faces(2).setColl(0, faces(0).getColl(0))               ' F <- U
                faces(0).setColl(0, faces(3).getColl(1).reversed())    ' U <- B reversed
                faces(3).setColl(1, faces(1).getColl(0).reversed())    ' B <- D reversed
                faces(1).setColl(0, temp)                              ' D <- F
                faces(5).rotateFace(1)

            Case Is = "R"
                Dim temp As New line(faces(2).getColl(1))
                faces(2).setColl(1, faces(1).getColl(1))               ' F <- D
                faces(1).setColl(1, faces(3).getColl(0).reversed())    ' D <- B reversed
                faces(3).setColl(0, faces(0).getColl(1).reversed())    ' B <- U reversed
                faces(0).setColl(1, temp)                              ' U <- F
                faces(4).rotateFace(1)

            Case Is = "F"
                Dim temp As New line(faces(0).getRow(1))
                faces(0).setRow(1, faces(5).getColl(1).reversed())     ' U <- L reversed
                faces(5).setColl(1, faces(1).getRow(0))                ' L <- D
                faces(1).setRow(0, faces(4).getColl(0).reversed())     ' D <- R reversed
                faces(4).setColl(0, temp)                              ' R <- U
                faces(2).rotateFace(1)

            Case Is = "B"
                Dim temp As New line(faces(0).getRow(0))
                faces(0).setRow(0, faces(4).getColl(1))                ' U <- R
                faces(4).setColl(1, faces(1).getRow(1).reversed())     ' R <- D reversed
                faces(1).setRow(1, faces(5).getColl(0))                ' D <- L
                faces(5).setColl(0, temp.reversed())                   ' L <- U reversed
                faces(3).rotateFace(1)

            Case Is = "UPrime"
                move("U") : move("U") : move("U")
            Case Is = "DPrime"
                move("D") : move("D") : move("D")
            Case Is = "LPrime"
                move("L") : move("L") : move("L")
            Case Is = "RPrime"
                move("R") : move("R") : move("R")
            Case Is = "FPrime"
                move("F") : move("F") : move("F")
            Case Is = "BPrime"
                move("B") : move("B") : move("B")
        End Select
    End Sub

    Public Function getFace(i As Integer) As Face
        Return faces(i)
    End Function
End Class
