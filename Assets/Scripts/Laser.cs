using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Send it up.
        transform.Translate(_speed * Time.deltaTime * Vector3.up);

        if (transform.position.y >= 7f)
        {
            Destroy(this.gameObject);
        }
    }
}
