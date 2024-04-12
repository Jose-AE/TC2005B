using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Linq;

public static class Logic
{
    private static Dictionary<string, int> counts = new Dictionary<string, int>();


    private static void InitCounts()
    {
        counts["Bishop_Black"] = 2;
        counts["Bishop_White"] = 2;
        counts["King_Black"] = 1;
        counts["King_White"] = 1;
        counts["Knight_Black"] = 2;
        counts["Knight_White"] = 2;
        counts["Pawn_Black"] = 8;
        counts["Pawn_White"] = 8;
        counts["Queen_Black"] = 1;
        counts["Queen_White"] = 1;
        counts["Rook_Black"] = 2;
        counts["Rook_White"] = 2;
    }


    public static string[,] GenerateBoard()
    {
        InitCounts();

        string[,] matrix = new string[8, 8];

        string[] keysArray = counts.Keys.ToArray();





        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                string rngPiece = keysArray[Random.Range(0, keysArray.Length)];

                matrix[x, y] = rngPiece;

            }
        }


        return matrix;

    }

}
