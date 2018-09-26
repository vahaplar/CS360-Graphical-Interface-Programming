Imports Microsoft.VisualBasic.PowerPacks

Public Class Form1
    'Check if ball hits the wall
    Dim move_right As Boolean
    Dim move_top As Boolean
    'Ball speed
    Dim speed As Integer
    'Angle affects speed
    Dim x_speed As Integer
    Dim y_speed As Integer
    'The angle that the ball thrown
    Dim angle As Double
    'Ball and container for ball
    Dim canvas As New ShapeContainer
    Dim theShape As New OvalShape
    'Friction parameter
    Dim friction As Integer
    'Hardness parameter
    Dim hardness As Integer
    Dim stick = False

    Private Function DrawBall()
        'The ball object draw on the screen whenever this called
        canvas.Parent = Me
        theShape.Parent = canvas
        theShape.FillStyle = FillStyle.Solid
        theShape.FillColor = Color.Blue
        theShape.Size = New System.Drawing.Size(48, 48)
        theShape.Location = New System.Drawing.Point((ClientSize.Width - 48) \ 2, (ClientSize.Height - 48) \ 2)
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Ball moves tick by tick
        'Position of ball is checked on every tick to determine if the ball going to change direction

        If stick = False Then
            If (theShape.Left - x_speed) <= 0 Then
                move_right = True
            End If
            If (theShape.Right + x_speed) >= Me.ClientRectangle.Right Then
                move_right = False
            End If
            If (theShape.Top - y_speed) <= 0 Then
                move_top = False
            End If
            If (theShape.Bottom + y_speed) >= Me.ClientRectangle.Bottom Then
                move_top = True
            End If
            'Ball changes direction if conditions met
            If move_right = False Then
                theShape.Left -= x_speed
            Else
                theShape.Left += x_speed
            End If
            If move_top = False Then
                theShape.Top += y_speed
            Else
                theShape.Top -= y_speed
            End If
            'Position of ball is checked on every tick to determine if the ball going to change direction
            'This time hardness value affects the ball so it looks like its embedded to wall
            'This mimics a sticking motion
        Else
            If (theShape.Left - x_speed) <= hardness Then
                move_right = True
            End If
            If (theShape.Right + x_speed) >= Me.ClientRectangle.Right - hardness Then
                move_right = False
            End If
            If (theShape.Top - y_speed) <= hardness Then
                move_top = False
            End If
            If (theShape.Bottom + y_speed) >= Me.ClientRectangle.Bottom - hardness Then
                move_top = True
            End If
            'Ball changes direction if conditions met
            If move_right = False Then
                theShape.Left -= x_speed
            Else
                theShape.Left += x_speed
            End If
            If move_top = False Then
                theShape.Top += y_speed
            Else
                theShape.Top -= y_speed
            End If
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When the application starts, ball will initiated with these default values 
        DrawBall()
        Timer1.Stop()
        speed = NumericUpDown1.Value
        angle = TrackBar1.Value
        x_speed = Math.Cos(Math.PI * angle / 180.0) * ((2 * speed) ^ (0.5))
        y_speed = Math.Sin(Math.PI * angle / 180.0) * ((2 * speed) ^ (0.5))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Button that starts timer so the ball moves
        Timer1.Start()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Button that stops timer so the ball stops
        Timer1.Stop()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        'Ball speed adjusted here
        speed = NumericUpDown1.Value * 100
        x_speed = Math.Cos(Math.PI * angle / 180.0) * ((2 * speed) ^ (0.5))
        y_speed = Math.Sin(Math.PI * angle / 180.0) * ((2 * speed) ^ (0.5))
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        'Ball hardness adjusted here so the ball will embed with borders to imitate hardness
        hardness = NumericUpDown2.Value * -1
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        'Thrown angle of ball
        angle = TrackBar1.Value
        x_speed = Math.Cos(Math.PI * angle / 180.0) * ((2 * speed) ^ (0.5))
        y_speed = Math.Sin(Math.PI * angle / 180.0) * ((2 * speed) ^ (0.5))
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Select Case CheckBox1.CheckState
            Case CheckState.Unchecked
                friction = 0
            Case CheckState.Checked
                friction = 1
            Case CheckState.Indeterminate
                friction = 0
        End Select
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Select Case CheckBox2.CheckState
            Case CheckState.Unchecked
                NumericUpDown2.Enabled = False
                stick = False
                hardness = 0
            Case CheckState.Checked
                stick = True
                NumericUpDown2.Enabled = True
                hardness = NumericUpDown2.Value * -1
            Case CheckState.Indeterminate
                friction = 0
        End Select


    End Sub
End Class