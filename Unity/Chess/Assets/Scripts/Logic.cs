using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Logic : MonoBehaviour
{

    private Dictionary<string, int> pieceCounts = new Dictionary<string, int>() {
         { "Bishop_Black", 2 },
         { "Bishop_White", 2 },
         { "King_Black", 1 },
         { "King_White", 1 },
         { "Knight_Black", 2 },
         { "Knight_White", 2 },
         { "Pawn_Black", 8 },
         { "Pawn_White", 8 },
         { "Queen_Black", 1 },
         { "Queen_White", 1 },
         { "Rook_Black", 2 },
         { "Rook_White", 2 }
         };




    public string[,] GenerateBoard()
    {

        string[,] matrix = new string[8, 8];
        string[] keysArray = pieceCounts.Keys.ToArray();


        foreach (string pieceName in keysArray)
        {
            while (pieceCounts[pieceName] > 0)
            {
                Vector2Int rngPos = new Vector2Int(Random.Range(0, 8), Random.Range(0, 8));
                if (matrix[rngPos.y, rngPos.x] == null)
                {
                    matrix[rngPos.y, rngPos.x] = pieceName;
                    pieceCounts[pieceName] -= 1;
                }

            }

        }

        return matrix;

    }

}
