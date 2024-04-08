using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float projectileForce = 10f;
    [SerializeField] float projectileSize = 0.5f;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleShoot();
    }


    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }


    void HandleShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.transform.localScale = new Vector3(projectileSize, projectileSize, projectileSize);
            bullet.transform.position = transform.position + transform.forward;
            Rigidbody rb = bullet.AddComponent<Rigidbody>();
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.AddForce(transform.forward * projectileForce, ForceMode.Impulse);



        }

    }
}
