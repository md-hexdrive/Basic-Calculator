Public Class Form1

    'The current value being input
    Dim CurrentInput As String = ""

    'The mathematical operator currently being used
    Dim CurrentOperator As String

    'The previous number that was input
    Dim LastInput As String = ""

#Region "General-Functions" 'General-purpose functions

    ''' <summary>
    ''' Add a digit to the number the user is entering
    ''' </summary>
    ''' <param name="Digit"></param>
    Sub AddDigit(Digit As String)

        ' Clear all previous input if new input is not
        If String.IsNullOrEmpty(CurrentInput) AndAlso String.IsNullOrEmpty(CurrentOperator) Then
            Reset()
        End If

        ' Don't allow more than one decimal point to be included in a number
        If Digit = "." AndAlso CurrentInput.Contains(".") Then
            Return
        End If
        CurrentInput &= Digit
        OutputTextBox.Text = CurrentInput


    End Sub

    ''' <summary>
    ''' Set the current Mathematical operator
    ''' </summary>
    ''' <param name="Op"></param>
    Sub SetOperator(Op As String)
        CurrentOperator = Op
    End Sub

    ''' <summary>
    ''' Handle what happens when a digit button is clicked
    ''' </summary>
    ''' <param name="DigitButton"></param>
    Sub DigitClicked(DigitButton As Button)
        AddDigit(DigitButton.Text)
    End Sub

    ''' <summary>
    ''' Clear calculator state
    ''' </summary>
    Sub Reset()
        ExpressionTextBox.Text = ""
        OutputTextBox.Text = ""
        CurrentInput = ""
        CurrentOperator = ""
        LastInput = ""
    End Sub

    ''' <summary>
    ''' Evaluate the result of the current expression
    ''' </summary>
    Sub Evaluate()
        Dim result As Decimal = 0.0

        'Only evaluate if all the nessary pieces are valid
        If Not String.IsNullOrEmpty(CurrentInput) AndAlso Not String.IsNullOrEmpty(LastInput) AndAlso Not String.IsNullOrEmpty(CurrentOperator) Then
            Dim value1 = CDec(LastInput)
            Dim value2 = CDec(CurrentInput)

            Select Case CurrentOperator
                Case "+"
                    result = value1 + value2
                Case "-"
                    result = value1 - value2
                Case "*"
                    result = value1 * value2
                Case "/"
                    result = value1 / value2
                Case Else
                    'MsgBox("Unknown operator was attempted to be used {}", CurrentOperator)
            End Select

            'Clear everything
            Reset()
            ExpressionTextBox.Text = result
            LastInput = result


        ElseIf Not String.IsNullOrEmpty(CurrentInput) Then
            result = CDec(CurrentInput)
            Reset()
            ExpressionTextBox.Text = result
            LastInput = result
        End If

    End Sub

    ''' <summary>
    ''' Calculate the result of the current expression and output it to the screen
    ''' </summary>
    Sub CalculateAndPrint()
        Evaluate()
    End Sub

#End Region



#Region "Event-Handlers" 'Button Event handlers
    Private Sub OutputTextBox_TextChanged(sender As Object, e As EventArgs) Handles OutputTextBox.TextChanged

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Reset()
    End Sub

    ''' <summary>
    ''' Handle digit button clicks
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DigitButton_Click(sender As Button, e As EventArgs) Handles DecimalPointButton.Click, ZeroButton.Click, OneButton.Click, TwoButton.Click, ThreeButton.Click, FourButton.Click, FiveButton.Click, SixButton.Click, SevenButton.Click, EightButton.Click, NineButton.Click
        Dim digit = sender.Text


        OutputTextBox.Text += digit
        AddDigit(digit)


    End Sub


    ''' <summary>
    ''' Handle basic mathematical operator input
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OperatorButton_Click(sender As Button, e As EventArgs) Handles PlusButton.Click, MinusButton.Click, MultButton.Click, DivideButton.Click

        If Not String.IsNullOrEmpty(CurrentInput) OrElse Not String.IsNullOrEmpty(LastInput) Then
            CalculateAndPrint()
            SetOperator(sender.Text)
            ExpressionTextBox.Text = LastInput & CurrentOperator
        End If




    End Sub


    Private Sub EqualsButton_Click(sender As Object, e As EventArgs) Handles EqualsButton.Click
        CalculateAndPrint()
    End Sub

    Private Sub SwitchSignButton_Click(sender As Object, e As EventArgs) Handles SwitchSignButton.Click

        ' remove the minus sign from the current number
        If CurrentInput.StartsWith("-") Then
            CurrentInput = CurrentInput.Remove(0, 1)


        Else ' Add a minus sign to the current number
            CurrentInput = "-" & CurrentInput

        End If

        OutputTextBox.Text = CurrentInput

    End Sub

#End Region


End Class
