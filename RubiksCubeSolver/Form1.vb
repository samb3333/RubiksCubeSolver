Imports System.Drawing.Drawing2D

Public Class Form1
    Private cube As Cube

    Private Structure Point3D
        Public X As Double
        Public Y As Double
        Public Z As Double

        Public Sub New(ByVal px As Double, ByVal py As Double, ByVal pz As Double)
            X = px
            Y = py
            Z = pz
        End Sub
    End Structure

    Private Class VisualFace
        Public Corners(3) As Point3D
        Public FaceIndex As Integer

        Sub New(index As Integer, inputCorners() As Point3D)
            FaceIndex = index
            Corners = inputCorners
        End Sub
    End Class

    Private Class ProjectedVisualFace
        Public Points(3) As PointF
        Public Depth As Double
        Public Colours(8) As Color
    End Class

    Private faces As New List(Of VisualFace)

    Private angleX As Double = -0.5
    Private angleY As Double = 0.6

    Private dragging As Boolean = False
    Private lastMouse As Point

    Private Const ViewDistance As Double = 5.0


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True   ' stops flicker
        Me.ResizeRedraw = True     ' redraw when the window is resized

        cube = New Cube

        AddHandler Me.U.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.D.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.L.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.R.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.F.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.B.Click, AddressOf DynamicMoveButton_Click

        AddHandler Me.UPrime.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.DPrime.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.LPrime.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.RPrime.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.FPrime.Click, AddressOf DynamicMoveButton_Click
        AddHandler Me.BPrime.Click, AddressOf DynamicMoveButton_Click


        faces.Add(New VisualFace(0, {P(-1, 1, 1), P(1, 1, 1), P(1, 1, -1), P(-1, 1, -1)}))      ' U white
        faces.Add(New VisualFace(1, {P(-1, -1, -1), P(1, -1, -1), P(1, -1, 1), P(-1, -1, 1)}))  ' D yellow
        faces.Add(New VisualFace(2, {P(-1, 1, -1), P(1, 1, -1), P(1, -1, -1), P(-1, -1, -1)}))  ' F red
        faces.Add(New VisualFace(3, {P(1, 1, 1), P(-1, 1, 1), P(-1, -1, 1), P(1, -1, 1)}))      ' B orange
        faces.Add(New VisualFace(4, {P(1, 1, -1), P(1, 1, 1), P(1, -1, 1), P(1, -1, -1)}))      ' R blue
        faces.Add(New VisualFace(5, {P(-1, 1, 1), P(-1, 1, -1), P(-1, -1, -1), P(-1, -1, 1)}))  ' L green

    End Sub

    Private Function P(ByVal x As Double, ByVal y As Double, ByVal z As Double) As Point3D
        Return New Point3D(x, y, z)
    End Function

    Private Function ArrayOfColour(inputColor)
        Dim colourArray(8) As Color
        For i = 0 To 8
            colourArray(i) = inputColor
        Next
        Return colourArray
    End Function

    Private Sub DynamicMoveButton_Click(Sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(Sender, Button)

        cube.move(clickedButton.Name)

        Me.Invalidate()
    End Sub

    Private Sub Solver_Click(sender As Object, e As EventArgs) Handles Solver.Click
        cube.solve()
        Me.Invalidate()
    End Sub

    Private Function Rotate(ByVal pt As Point3D) As Point3D
        Dim cosY As Double = Math.Cos(angleY)
        Dim sinY As Double = Math.Sin(angleY)
        Dim cosX As Double = Math.Cos(angleX)
        Dim sinX As Double = Math.Sin(angleX)

        Dim x1 As Double = pt.X * cosY - pt.Z * sinY
        Dim z1 As Double = pt.X * sinY + pt.Z * cosY

        Dim y2 As Double = pt.Y * cosX - z1 * sinX
        Dim z2 As Double = pt.Y * sinX + z1 * cosX

        Return New Point3D(x1, y2, z2)
    End Function

    Private Function Project(ByVal pt As Point3D) As PointF
        Dim scale As Double = Math.Min(ClientSize.Width, ClientSize.Height) * 1.2
        Dim factor As Double = scale / (pt.Z + ViewDistance)
        Dim sx As Double = ClientSize.Width / 3 + pt.X * factor
        Dim sy As Double = ClientSize.Height / 2 - pt.Y * factor
        Return New PointF(CSng(sx), CSng(sy))
    End Function

    Private Function GridPoint(p() As PointF, u As Double, v As Double) As PointF
        ' point u of the way along the top edge (corner 0 -> 1) and the bottom edge (corner 3 -> 2)
        Dim topX As Double = p(0).X + (p(1).X - p(0).X) * u
        Dim topY As Double = p(0).Y + (p(1).Y - p(0).Y) * u
        Dim botX As Double = p(3).X + (p(2).X - p(3).X) * u
        Dim botY As Double = p(3).Y + (p(2).Y - p(3).Y) * u

        ' then v of the way from the top point down to the bottom point
        Return New PointF(CSng(topX + (botX - topX) * v), CSng(topY + (botY - topY) * v))
    End Function

    Private Function FaceToGrid(n As Integer, points() As PointF) As PointF()
        Dim col As Integer = n Mod 3
        Dim row As Integer = n \ 3

        Return {
        GridPoint(points, col / 3, row / 3),
        GridPoint(points, (col + 1) / 3, row / 3),
        GridPoint(points, (col + 1) / 3, (row + 1) / 3),
        GridPoint(points, col / 3, (row + 1) / 3)
    }
    End Function

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        ' Rotate and project every face, remembering its average depth
        Dim toDraw As New List(Of ProjectedVisualFace)
        For Each f As VisualFace In faces
            Dim pf As New ProjectedVisualFace

            Dim cubeFace As Face = cube.getFace(f.FaceIndex)
            For x = 0 To 8
                pf.Colours(x) = cubeFace.stickers(x).BackColor
            Next

            ReDim pf.Points(f.Corners.Length - 1)

            Dim totalZ As Double = 0
            For i As Integer = 0 To f.Corners.Length - 1
                Dim r As Point3D = Rotate(f.Corners(i))
                totalZ += r.Z
                pf.Points(i) = Project(r)
            Next
            pf.Depth = totalZ / f.Corners.Length
            toDraw.Add(pf)
        Next

        ' Painter's algorithm: draw the furthest faces first
        toDraw.Sort(Function(a, b) b.Depth.CompareTo(a.Depth))

        For Each pf As ProjectedVisualFace In toDraw
            For x = 0 To 8
                Using brush As New SolidBrush(pf.Colours(x))
                    e.Graphics.FillPolygon(brush, FaceToGrid(x, pf.Points))
                    e.Graphics.DrawPolygon(Pens.Black, FaceToGrid(x, pf.Points))
                End Using
            Next

            e.Graphics.DrawPolygon(Pens.Black, pf.Points)
        Next
    End Sub

    ' ---------- Mouse dragging to rotate ----------

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        dragging = True
        lastMouse = e.Location
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If dragging Then
            angleY += (e.X - lastMouse.X) * 0.01
            angleX -= (e.Y - lastMouse.Y) * 0.01
            lastMouse = e.Location
            Me.Invalidate()   ' ask Windows to repaint
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        dragging = False
    End Sub
End Class
