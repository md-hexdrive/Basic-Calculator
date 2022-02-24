Public Class Form1

    'The current value being input
    Dim CurrentInput As String = ""

    'The mathematical operator currently being used
    Dim CurrentOperator As String

    'The Actual Numeric value processed so far
    Dim CurrentValue As Double = 0.0

    Dim ValueOne As Double = 0.0
    Dim ValueTwo As Double = 0.0


#Region "General-Functions" 'General-purpose functions

    ''' <summary>
    ''' Add a digit to the number being processed currently
    ''' </summary>
    ''' <param name="Digit"></param>
    Sub AddDigit(Digit As Double)

        ValueTwo *= 10
        ValueTwo += Digit

    End Sub

    ''' <summary>
    ''' Set the current Mathematical operator
    ''' </summary>
    ''' <param name="Op"></param>
    Sub SetOperator(Op As String)
        CurrentOperator = Op
    End Sub

    Sub DigitClicked(DigitButton As Button)
        AddDigit(DigitButton.Text)
    End Sub


#End Region



#Region "Event-Handlers"
    Private Sub OutputTextBox_TextChanged(sender As Object, e As EventArgs) Handles OutputTextBox.TextChanged

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

    End Sub

    ''' <summary>
    ''' Handle digit button clicks
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DigitButton_Click(sender As Button, e As EventArgs) Handles DecimalPointButton.Click, ZeroButton.Click, OneButton.Click, TwoButton.Click, ThreeButton.Click, FourButton.Click, FiveButton.Click, SixButton.Click, SevenButton.Click, EightButton.Click, NineButton.Click
        MsgBox(sender.Text)
    End Sub



    Private Sub OperatorButton_Click(sender As Object, e As EventArgs) Handles PlusButton.Click, MinusButton.Click, MultButton.Click, DivideButton.Click

    End Sub


    Private Sub EqualsButton_Click(sender As Object, e As EventArgs) Handles EqualsButton.Click
        MsgBox("You work")
    End Sub

#End Region 'Button Event handlers


End Class
