using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireRate = 0.5f;

    private float _canFire = 0.0f;

    // Start is called before the first frame update.
    void Start()
    {
        // Assign start position.
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame.
    void Update()
    {
        CalculateMovement();

        // If I hit space key, attempt to fire laser.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float delta = _speed * Time.deltaTime;
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0) * delta;
        transform.Translate(direction);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5.55f, 7.54f), 0);

        if (transform.position.x >= 11.05)
        {
            transform.position = new Vector3(-9.92f, transform.position.y, 0);
        }
        else if (transform.position.x <= -9.92f)
        {
            transform.position = new Vector3(11.05f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        // Handle cooldown case.
        if (Time.time <= _canFire) {
            return;
        }

        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.85f, 0), Quaternion.identity);
    }
}
