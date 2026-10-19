<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        U = New Button()
        D = New Button()
        R = New Button()
        L = New Button()
        B = New Button()
        F = New Button()
        BPrime = New Button()
        FPrime = New Button()
        RPrime = New Button()
        LPrime = New Button()
        DPrime = New Button()
        UPrime = New Button()
        Solver = New Button()
        SuspendLayout()
        ' 
        ' U
        ' 
        U.Location = New Point(1048, 79)
        U.Margin = New Padding(4, 3, 4, 3)
        U.Name = "U"
        U.Size = New Size(82, 59)
        U.TabIndex = 0
        U.Text = "U"
        U.UseVisualStyleBackColor = True
        ' 
        ' D
        ' 
        D.Location = New Point(1137, 79)
        D.Margin = New Padding(4, 3, 4, 3)
        D.Name = "D"
        D.Size = New Size(82, 59)
        D.TabIndex = 1
        D.Text = "D"
        D.UseVisualStyleBackColor = True
        ' 
        ' R
        ' 
        R.Location = New Point(1314, 79)
        R.Margin = New Padding(4, 3, 4, 3)
        R.Name = "R"
        R.Size = New Size(82, 59)
        R.TabIndex = 3
        R.Text = "R"
        R.UseVisualStyleBackColor = True
        ' 
        ' L
        ' 
        L.Location = New Point(1226, 79)
        L.Margin = New Padding(4, 3, 4, 3)
        L.Name = "L"
        L.Size = New Size(82, 59)
        L.TabIndex = 2
        L.Text = "L"
        L.UseVisualStyleBackColor = True
        ' 
        ' B
        ' 
        B.Location = New Point(1492, 79)
        B.Margin = New Padding(4, 3, 4, 3)
        B.Name = "B"
        B.Size = New Size(82, 59)
        B.TabIndex = 5
        B.Text = "B"
        B.UseVisualStyleBackColor = True
        ' 
        ' F
        ' 
        F.Location = New Point(1403, 79)
        F.Margin = New Padding(4, 3, 4, 3)
        F.Name = "F"
        F.Size = New Size(82, 59)
        F.TabIndex = 4
        F.Text = "F"
        F.UseVisualStyleBackColor = True
        ' 
        ' BPrime
        ' 
        BPrime.Location = New Point(1492, 145)
        BPrime.Margin = New Padding(4, 3, 4, 3)
        BPrime.Name = "BPrime"
        BPrime.Size = New Size(82, 59)
        BPrime.TabIndex = 11
        BPrime.Text = "B'"
        BPrime.UseVisualStyleBackColor = True
        ' 
        ' FPrime
        ' 
        FPrime.Location = New Point(1403, 145)
        FPrime.Margin = New Padding(4, 3, 4, 3)
        FPrime.Name = "FPrime"
        FPrime.Size = New Size(82, 59)
        FPrime.TabIndex = 10
        FPrime.Text = "F'"
        FPrime.UseVisualStyleBackColor = True
        ' 
        ' RPrime
        ' 
        RPrime.Location = New Point(1314, 145)
        RPrime.Margin = New Padding(4, 3, 4, 3)
        RPrime.Name = "RPrime"
        RPrime.Size = New Size(82, 59)
        RPrime.TabIndex = 9
        RPrime.Text = "R'"
        RPrime.UseVisualStyleBackColor = True
        ' 
        ' LPrime
        ' 
        LPrime.Location = New Point(1226, 145)
        LPrime.Margin = New Padding(4, 3, 4, 3)
        LPrime.Name = "LPrime"
        LPrime.Size = New Size(82, 59)
        LPrime.TabIndex = 8
        LPrime.Text = "L'"
        LPrime.UseVisualStyleBackColor = True
        ' 
        ' DPrime
        ' 
        DPrime.Location = New Point(1137, 145)
        DPrime.Margin = New Padding(4, 3, 4, 3)
        DPrime.Name = "DPrime"
        DPrime.Size = New Size(82, 59)
        DPrime.TabIndex = 7
        DPrime.Text = "D'"
        DPrime.UseVisualStyleBackColor = True
        ' 
        ' UPrime
        ' 
        UPrime.Location = New Point(1048, 145)
        UPrime.Margin = New Padding(4, 3, 4, 3)
        UPrime.Name = "UPrime"
        UPrime.Size = New Size(82, 59)
        UPrime.TabIndex = 6
        UPrime.Text = "U'"
        UPrime.UseVisualStyleBackColor = True
        ' 
        ' Solver
        ' 
        Solver.Location = New Point(909, 79)
        Solver.Margin = New Padding(4, 3, 4, 3)
        Solver.Name = "Solver"
        Solver.Size = New Size(82, 59)
        Solver.TabIndex = 12
        Solver.Text = "Solver"
        Solver.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1729, 923)
        Controls.Add(Solver)
        Controls.Add(BPrime)
        Controls.Add(FPrime)
        Controls.Add(RPrime)
        Controls.Add(LPrime)
        Controls.Add(DPrime)
        Controls.Add(UPrime)
        Controls.Add(B)
        Controls.Add(F)
        Controls.Add(R)
        Controls.Add(L)
        Controls.Add(D)
        Controls.Add(U)
        Margin = New Padding(4, 3, 4, 3)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)

    End Sub
    Friend WithEvents U As System.Windows.Forms.Button
    Friend WithEvents D As System.Windows.Forms.Button
    Friend WithEvents R As System.Windows.Forms.Button
    Friend WithEvents L As System.Windows.Forms.Button
    Friend WithEvents B As System.Windows.Forms.Button
    Friend WithEvents F As System.Windows.Forms.Button
    Friend WithEvents BPrime As System.Windows.Forms.Button
    Friend WithEvents FPrime As System.Windows.Forms.Button
    Friend WithEvents RPrime As System.Windows.Forms.Button
    Friend WithEvents LPrime As System.Windows.Forms.Button
    Friend WithEvents DPrime As System.Windows.Forms.Button
    Friend WithEvents UPrime As System.Windows.Forms.Button
    Friend WithEvents Solver As Button

End Class
