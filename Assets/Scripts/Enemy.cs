using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);

        if (transform.position.y <= -4.5f)
        {
            float randomX = Random.Range(-11f, 11f);
            transform.position = new Vector3(randomX, 6.5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle Player.
        if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        // Handle Laser.
        if (other.CompareTag("Ammunition"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
