using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private float _coolDown = 1.5f;

    private IEnumerator coroutine;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = SpawnRoutine();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (!_stopSpawning)
        {
            float randomX = Random.Range(-11f, 11f);
            GameObject enemy = Instantiate(_enemyPrefab, new Vector3(randomX, 6.5f, 0), Quaternion.identity);
            enemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_coolDown);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
