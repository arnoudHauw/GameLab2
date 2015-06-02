using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawningEnemy : MonoBehaviour
{

    private float _timeNextWave = 10;
    private int _AmountWave = 2;
    public GameObject[] newEnemy;
    public GameObject SpawnPoints;
	void Start () 
    {
        StartCoroutine(SpawnWave());
	}
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(_timeNextWave);
            _timeNextWave = 15;
        Wave();
    }
    IEnumerator SpawnEnemy(float _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        Instantiate(newEnemy[0], SpawnPoints.transform.position,
                    SpawnPoints.transform.rotation);
    }

    void Wave()
    {
        for (int k = 0; k < _AmountWave; k++)
        {
            StartCoroutine(SpawnEnemy(1f * k));
        }

        _AmountWave = _AmountWave + 1;
        StartCoroutine(SpawnWave());
    }
}
