using System;
using System.Collections.Generic;
class Program
{
    static int N = 5;
    static int[,] board = new int[N, N];
    static int[] dx = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static int totalCells = N * N;
    static bool Solve(int startX, int startY)
    {
        Stack<int> xStack = new Stack<int>();
        Stack<int> yStack = new Stack<int>();
        Stack<int> moveIndexStack = new Stack<int>();
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                board[i, j] = 0;
        board[startX, startY] = 1;
        xStack.Push(startX);
        yStack.Push(startY);
        moveIndexStack.Push(-1);
        while (xStack.Count > 0)
        {
            int x = xStack.Peek();
            int y = yStack.Peek();
            int lastMoveIndex = moveIndexStack.Peek();
            int moveNum = board[x, y];
            if (moveNum == totalCells)
                return true;
            bool found = false;
            for (int i = lastMoveIndex + 1; i < 8; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i]; if (nx >= 0 && nx < N && ny >= 0 && ny < N &&
board[nx, ny] == 0)
                {
                    moveIndexStack.Pop();
                    moveIndexStack.Push(i);
                    board[nx, ny] = moveNum + 1;
                    xStack.Push(nx);
                    yStack.Push(ny);
                    moveIndexStack.Push(-1);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                xStack.Pop();
                yStack.Pop();
                moveIndexStack.Pop();
                board[x, y] = 0;
            }
        }
        return false;
    }
    static void Main()
    {
        DateTime start = DateTime.Now;
        bool result = Solve(0, 0);
        DateTime end = DateTime.Now;
        if (result)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(board[i,
                    j].ToString().PadLeft(4)); Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Время: {(end -
            start).TotalMilliseconds} мс");
        }
        else
        {
            Console.WriteLine("Нет решения");
            Console.WriteLine($"Время: {(end -
            start).TotalMilliseconds} мс");
        }
    }
}
