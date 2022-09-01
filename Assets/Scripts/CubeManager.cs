using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Vector2Int _redCubeCountFromTo;
    [SerializeField] private Vector2Int _blueCubeCountFromTo;
    [SerializeField] private GameObject _redCubePrefab;
    [SerializeField] private GameObject _blueCubePrefab;
    [SerializeField] private GameObject _spawnedCubes;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Vector3 _volume;
    public static List<GameObject> InstantiateCubeList = new List<GameObject>();

    private void Start()
    {
        CubeSpawn(_redCubePrefab, _redCubeCountFromTo);
        CubeSpawn(_blueCubePrefab, _blueCubeCountFromTo);
    }

    void CubeSpawn(GameObject prefab, Vector2Int Count)
    {
        int spawnCount = Random.Range(Count.x, Count.y);

        while (spawnCount > 0)
        {
            spawnCount--;
            Vector3 pos = new Vector3(
                Random.Range(_spawnPoint.position.x - _volume.x, _spawnPoint.position.x + _volume.x),
                Random.Range(_spawnPoint.position.y - _volume.y, _spawnPoint.position.y + _volume.y),
                Random.Range(_spawnPoint.position.z - _volume.z, _spawnPoint.position.z + _volume.z));
            GameObject instantiate = Instantiate(prefab, pos, Quaternion.identity, _spawnedCubes.transform);
            if (instantiate != null)
            {
                InstantiateCubeList.Add(instantiate);
            }
        }
    }
}
