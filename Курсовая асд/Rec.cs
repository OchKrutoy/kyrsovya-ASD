using System;
class Rec
{
    static int N = 8;
    static int[,] board = new int[N, N];
    static int[] dx = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static int totalCells = N * N;
    static bool Solve(int x, int y, int moveNum)
    {
        board[x, y] = moveNum;
        if (moveNum == totalCells)
            return true;
        for (int i = 0; i < 8; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            if (nx >= 0 && nx < N && ny >= 0 && ny < N && board[nx,
            ny] == 0)
            {
                if (Solve(nx, ny, moveNum + 1))
}
        }
        board[x, y] = 0;
        return false;
        static void Main()
        {
            DateTime start = DateTime.Now;
            if (Solve(0, 0, 1))
            {
                DateTime end = DateTime.Now;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(board[i, j].ToString().PadLeft(4));
                    Console.WriteLine();
                }
                Console.WriteLine($"\nВремя: {(end - start).TotalMilliseconds:F5} мс");
                return;
            }
            else
            {
                DateTime end = DateTime.Now;
                Console.WriteLine("Нет решения");
                Console.WriteLine($"Время:{(end -
                start).TotalSeconds:F5} мс");
            }
        }
    }
}