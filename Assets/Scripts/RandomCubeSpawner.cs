using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _cubes;

    [SerializeField] private int _maxCubesCount;
    [SerializeField] private int _numberInRow;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        float startPosition = transform.position.x;
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        float offset = _cubes[0].transform.localScale.x;
      
        for (int i = 0; i < _maxCubesCount; i++)
        {
            int randomCubeIndex = Random.Range(0, _cubes.Length);
            if (i == _numberInRow || i==_numberInRow*2)
            {
                spawnPosition.x = startPosition;
                spawnPosition.z += offset;
            }
            GameObject cube = Instantiate(_cubes[randomCubeIndex], spawnPosition, _cubes[randomCubeIndex].transform.rotation, transform.parent);
            spawnPosition.x = cube.transform.position.x + offset;
        }
    }
}
