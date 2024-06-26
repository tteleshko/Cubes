using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    [SerializeField] private int _maxCubesCount;
    [SerializeField] private float _spawnOffset = 0.2f;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        float offset = _cubePrefab.transform.localScale.x + _spawnOffset;

        for (int i = 0; i < _maxCubesCount; i++)
        {
            GameObject cube = Instantiate(_cubePrefab, spawnPosition, _cubePrefab.transform.rotation, transform.parent);
            spawnPosition.x = cube.transform.position.x + offset;
        }
    }
}
