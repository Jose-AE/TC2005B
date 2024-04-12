using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour
{

    [SerializeField] GameObject[] prefabs;


    // Start is called before the first frame update
    void Start()
    {
        string[,] matrix = Logic.GenerateBoard();



        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                foreach (GameObject go in prefabs)
                {
                    if (go.name == matrix[x, y])
                    {
                        GameObject obj = Instantiate(go);
                        go.transform.position = new Vector3(x, 0, y);
                        break;
                    }
                }

                // Debug.Log(matrix[x, y]);

            }
        }




    }

}
