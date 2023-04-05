using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Assign start position.
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float delta = _speed * Time.deltaTime;
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0) * delta;
        transform.Translate(direction);

        if (transform.position.y >= 7.54f)
        {
            transform.position = new Vector3(transform.position.x, -5.55f, 0);
        }
        else if (transform.position.y <= -5.55f)
        {
            transform.position = new Vector3(transform.position.x, 7.54f, 0);
        }

        if (transform.position.x >= 11.05)
        {
            transform.position = new Vector3(-9.92f, transform.position.y, 0);
        }
        else if (transform.position.x <= -9.92f)
        {
            transform.position = new Vector3(11.05f, transform.position.y, 0);
        }
    }
}
