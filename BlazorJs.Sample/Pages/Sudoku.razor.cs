using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorJs.Sample.Pages
{
    public class SudokuCell
    {
        public int? Entry { get; set; }
        public bool IsFixed { get; set; }
        public bool HasError { get; set; }
    }
    public partial class Sudoku : ComponentBase
    {
        int size;
        SudokuCell[,] boards;
        DateTime startTime;
        Random random = new Random();
        bool valid;
        DateTime start ;
        int score;

        CancellationTokenSource cts = new CancellationTokenSource();
        bool ValidateBoard()
        {
            bool valid = true;
            for (int y = 0; y < size; y++)
            {
                List<int> seen = new List<int>(size);
                for (int x = 0; x < size; x++)
                {
                    var cell = boards[y, x];
                    if (cell.Entry != null)
                    {
                        if (cell.Entry == 0 || cell.Entry > size || seen.Contains(cell.Entry.Value))
                        {
                            boards[y, x].HasError = true;
                            valid = false;
                        }
                        else
                        {
                            boards[y, x].HasError = false;
                        }
                        seen.Add(cell.Entry.Value);
                    }
                }
            }
            for (int x = 0; x < size; x++)
            {
                List<int> seen = new List<int>(size);
                for (int y = 0; y < size; y++)
                {
                    var cell = boards[y, x];
                    if (cell.Entry != null)
                    {
                        if (cell.Entry == 0 || cell.Entry > size || seen.Contains(cell.Entry.Value))
                        {
                            boards[y, x].HasError = true;
                            valid = false;
                        }
                        else
                        {
                            boards[y, x].HasError = false;
                        }
                        seen.Add(cell.Entry.Value);
                    }
                }
            }
            return valid;
        }
        void CreateBoard()
        {
            if (size == 0)
                return;
            boards = new SudokuCell[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    boards[y, x] = new SudokuCell();
                }
            }
            for (int i = 0; i < (size * size) / 8; i++)
            {
                int x = random.Next(1, size);
                int y = random.Next(1, size);
                while (boards[y, x].Entry != null)
                {
                    x = random.Next(1, size);
                    y = random.Next(1, size);
                }
                boards[y, x].Entry = random.Next(1, size);
                boards[y, x].IsFixed = true;
                while (!ValidateBoard())
                {
                    boards[y, x].Entry = random.Next(1, size);
                }
            }
            start = DateTime.Now;
            cts.Cancel();
            //_ = Task.Run(async () =>
            //{
            //    while (!cts.IsCancellationRequested)
            //    {
            //        await Task.Delay(1000, cts.Token);
            //        StateHasChanged();
            //    }
            //});
        }

        void Validate(int x, int y)
        {
            valid = ValidateBoard();
            boards[y, x].HasError = !valid;
        }

        public override void Dispose()
        {
            cts.Cancel();
            base.Dispose();
        }
    }
}
