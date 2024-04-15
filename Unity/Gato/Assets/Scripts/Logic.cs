using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{

    string[,] board;
    int turn;


    Vector2Int GetRandomPos()
    {
        int rngCol = Random.Range(0, 3);
        int rngRow = Random.Range(0, 3);
        return new Vector2Int(rngRow, rngCol);
    }


    void O_Turn()
    {
        while (true)
        {
            Vector2Int pos = GetRandomPos();
            if (board[pos.x, pos.y] == null)
            {
                board[pos.x, pos.y] = "O";
                break;
            }

        }
    }

    void X_Turn()
    {
        while (true)
        {
            Vector2Int pos = GetRandomPos();
            if (board[pos.x, pos.y] == null)
            {
                board[pos.x, pos.y] = "X";
                break;
            }
        }
    }

    bool CheckWinner()
    {
        // Check rows
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] != null && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                return true;
        }


        // Check diagonal
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] != null && board[0, col] == board[1, col] && board[1, col] == board[2, col])
                return true;
        }


        // Check diagonals
        if (board[0, 0] != null && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return true;

        if (board[0, 2] != null && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return true;

        return false;
    }


    public string[,] GenerateGame()
    {
        board = new string[3, 3];
        turn = 0;


        while (turn < 9)
        {
            if (turn % 2 == 1)
                X_Turn();
            else
                O_Turn();

            turn++;

            if (CheckWinner()) break;
        }


        return board;
    }




    void PrintBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            string rowString = "";
            for (int col = 0; col < 3; col++)
            {
                rowString += (board[row, col] == null ? "-" : board[row, col]) + " ";
            }
            Debug.Log(rowString);
        }
    }
}
