using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickWall : MonoBehaviour
{

    [SerializeField] Vector2 wallSize = Vector3.zero;
    [SerializeField] Vector3 brickSize = new Vector3(1, 0.5f, 0.5f);
    [SerializeField] Material brickMaterial;
    [SerializeField] float rowOffset = 0.5f;
    [SerializeField] Vector3 wallPosition = new Vector3(0, 0.5f, 0);


    // Start is called before the first frame update
    void Start()
    {
        GenerateWall();
    }


    void GenerateBrick(Vector3 pos)
    {
        GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
        brick.transform.parent = transform;
        brick.transform.localScale = brickSize;
        brick.transform.position = pos;
        brick.GetComponent<Renderer>().material = brickMaterial;
        brick.GetComponent<Renderer>().material.color = Random.ColorHSV();

        brick.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;


    }

    void GenerateWall()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int x = 0; x < wallSize.x; x++)
            for (int y = 0; y < wallSize.y; y++)
                GenerateBrick(new Vector3((x * brickSize.x) + (y % 2 == 1 ? rowOffset : 0), y * brickSize.y, 0) + wallPosition - new Vector3((brickSize.x * wallSize.x) / 2f, 0, 0));
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GenerateWall();
        }
    }


}
