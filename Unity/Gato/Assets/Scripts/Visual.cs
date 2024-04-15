
using Unity.VisualScripting;
using UnityEngine;

public class Visual : MonoBehaviour
{
    [SerializeField] Transform piecesParent;

    [SerializeField] GameObject xPrefab;
    [SerializeField] GameObject oPrefab;



    void PlacePices()
    {
        string[,] board = GetComponent<Logic>().GenerateGame();

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                string currCellPieceName = board[row, col];

                if (currCellPieceName == null)
                    continue;

                GameObject prefab = currCellPieceName == "X" ? xPrefab : oPrefab;
                GameObject piece = Instantiate(prefab);
                piece.transform.SetParent(piecesParent);
                piece.transform.localPosition = new Vector3(row, 1f, col + 0.1f);

            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeletePices();
            PlacePices();
        }
    }

    void DeletePices()
    {
        foreach (Transform child in piecesParent)
            Destroy(child.gameObject);

    }

    void Start()
    {
        PlacePices();
    }

}