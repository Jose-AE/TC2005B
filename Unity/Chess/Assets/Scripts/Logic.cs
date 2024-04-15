using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Logic : MonoBehaviour
{

    private Dictionary<string, int> pieceCounts;




    [Range(0, 2)][SerializeField] int bishopBlackRange; // Range for black bishops
    [Range(0, 2)][SerializeField] int bishopWhiteRange; // Range for white bishops
    [Range(0, 1)][SerializeField] int kingBlackRange;   // Range for black king
    [Range(0, 1)][SerializeField] int kingWhiteRange;   // Range for white king
    [Range(0, 1)][SerializeField] int queenBlackRange;  // Range for black queen
    [Range(0, 1)][SerializeField] int queenWhiteRange;  // Range for white queen
    [Range(0, 2)][SerializeField] int rookBlackRange;   // Range for black rooks
    [Range(0, 2)][SerializeField] int rookWhiteRange;   // Range for white rooks
    [Range(0, 2)][SerializeField] int knightBlackRange; // Range for black knights
    [Range(0, 2)][SerializeField] int knightWhiteRange; // Range for white knights
    [Range(0, 8)][SerializeField] int pawnBlackRange;   // Range for black pawns
    [Range(0, 8)][SerializeField] int pawnWhiteRange;   // Range for white pawns


    void InitPieceCounts()
    {
        pieceCounts = new Dictionary<string, int>() {
         { "Bishop_Black", Random.Range(0,bishopBlackRange+1) },
         { "Bishop_White", Random.Range(0,bishopWhiteRange+1) },
         { "King_Black", Random.Range(0,kingBlackRange+1) },
         { "King_White", Random.Range(0,kingWhiteRange+1) },
         { "Knight_Black", Random.Range(0,kingBlackRange+1) },
         { "Knight_White", Random.Range(0,kingWhiteRange+1) },
         { "Pawn_Black", Random.Range(0,pawnBlackRange+1) },
         { "Pawn_White", Random.Range(0,pawnWhiteRange+1) },
         { "Queen_Black", Random.Range(0,queenBlackRange+1) },
         { "Queen_White", Random.Range(0,queenWhiteRange+1) },
         { "Rook_Black", Random.Range(0,rookBlackRange+1) },
         { "Rook_White", Random.Range(0,rookWhiteRange+1) }
         };
    }



    public string[,] GenerateBoard()
    {
        InitPieceCounts();
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
