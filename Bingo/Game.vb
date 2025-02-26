Module Game

    Sub Main()
        Dim UserInput As String
        Do
            BingoBoard()
            Console.WriteLine()
            Console.WriteLine("Press ""d"" to draw ball")
            Console.WriteLine("Press ""c"" to clear")
            Console.WriteLine("Press ""q"" to quit")
            UserInput = Console.ReadLine()
            Select Case UserInput
                Case "d"
                    DrawBall()
                Case "c"
                    BingoTracker(0, 0,, True)
                    DrawBall(True)
                Case Else
                    'Pass
            End Select
        Loop Until UserInput = "q"
        Console.Clear
        Console.WriteLine("Bye, bye.")
    End Sub

    Sub DrawBall(Optional ClearCounter As Boolean = False)
        Dim Temp(,) As Boolean = BingoTracker(0, 0)
        Dim CurrentBallNumber As Integer
        Dim CurrentBallLetter As Integer
        Static BallCounter As Integer
        Do
            CurrentBallNumber = RandomNumberBetween(0, 14) 'Get row
            CurrentBallLetter = RandomNumberBetween(0, 4) 'Get columb
        Loop Until Temp(CurrentBallNumber, CurrentBallLetter) = False Or BallCounter >= 75
        BingoTracker(CurrentBallNumber, CurrentBallLetter, True, False)
        BallCounter += 1
        Console.WriteLine($"The current row is {CurrentBallLetter} and columb is {CurrentBallNumber}.")
    End Sub

    Function RandomNumberBetween(Min As Integer, Max As Integer)
        Dim Ball As Single
        Randomize()
        Ball = Rnd()
        Ball *= Max + Min
        Ball += Min
        Return CInt((Ball))
    End Function

    Function BingoTracker(BallNumber As Integer, BallLetter As Integer, Optional Update As Boolean = False, Optional Clear As Boolean = False) As Boolean(,)
        Static Tracker(14, 4) As Boolean
        'Actual code here
        If Update Then
            Tracker(BallNumber, BallLetter) = True
        End If
        If Clear Then
            'Clear the array
            ReDim Tracker(14, 4) 'with no preserve it will not save data when redim so we can use it to clear
        End If
        Tracker(BallNumber, BallLetter) = True
            Return Tracker
    End Function
    Sub BingoBoard()
        Dim Slot As String = "|x  "
        Dim Heading() As String = {"B", "I", "N", "G", "O"}
        Dim DisplayTracker(,) As Boolean = BingoTracker(0, 0)
        For Each letter In Heading
            Console.Write(letter.PadLeft(2).PadRight(4))
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(20, "_"))
        For currentNumber = 0 To 14

            For CurrentLetter = 0 To 4
                If DisplayTracker(currentNumber, CurrentLetter) Then
                    Slot = "|X  "
                Else
                    Slot = "|   "
                End If
                Slot = Slot.PadLeft(4)
                Console.Write(Slot)
            Next
            Console.WriteLine()
        Next
    End Sub
End Module
