Module Game

    Sub Main()
        For i = 0 To 10
            BingoBoard()
            DrawBall()
            Console.ReadLine()
        Next
    End Sub

    Sub DrawBall()
        Dim Temp(,) As Boolean = BingoTracker(0, 0)
        Dim CurrentBallNumber As Integer
        Dim CurrentBallLetter As Integer
        Do
            CurrentBallNumber = RandomNumberBetween(0, 14) 'Get row
            CurrentBallLetter = RandomNumberBetween(0, 4) 'Get columb
        Loop Until Temp(CurrentBallNumber, CurrentBallLetter) = False
        Console.WriteLine($"The current row is {CurrentBallLetter} and columb is {CurrentBallNumber}.")

        RandomNumberBetween(0, 14)
    End Sub

    Function RandomNumberBetween(Min As Integer, Max As Integer)
        Dim Ball As Single
        Randomize()
        Ball = Rnd()
        Ball *= Max - Min
        Ball += Min
        Return CInt(Math.Ceiling(Ball))
    End Function

    Function BingoTracker(BallNumber As Integer, BallLetter As Integer, Optional Clear As Boolean = False)
        Static Tracker(14, 4) As Boolean
        'Actual code here
        Tracker(BallNumber, BallLetter) = True
        Return Tracker
    End Function
    Sub BingoBoard()
        Dim Temp As String = "X  |"
        Dim Heading() As String = {"B", "I", "N", "G", "O"}
        Dim DisplayTracker(,) As Boolean = BingoTracker(0, 0)
        Console.WriteLine(StrDup(20, "_"))
        For Each letter In Heading
            Console.Write()
        Next
    End Sub
End Module
