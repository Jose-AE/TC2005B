
using UnityEngine;

public class Visual : MonoBehaviour
{

    [SerializeField] GameObject[] prefabs;
    private string[,] matrix;


    void PlacePices()
    {
        matrix = GetComponent<Logic>().GenerateBoard();

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                string currCellPieceName = matrix[row, col];

                if (currCellPieceName == null)
                    continue;

                foreach (GameObject go in prefabs)
                {
                    if (currCellPieceName == go.name)
                    {
                        Instantiate(go, new Vector3(row + 0.5f, 0.05f, col + 0.5f), Quaternion.Euler(-90, 0, 0));
                        break;
                    }
                }
            }
        }

    }




    void Start()
    {
        PlacePices();

    }

}
