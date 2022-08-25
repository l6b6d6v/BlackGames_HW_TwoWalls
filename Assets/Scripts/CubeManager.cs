using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{

    public Vector2Int RedCubeCountFromTo;
    public Vector2Int BlueCubeCountFromTo;
    public GameObject redCubePrefab;
    public GameObject blueCubePrefab;
    public GameObject parent;
    public Transform spawnPoint;
    public Vector3 volume;
    public static List<GameObject> InstantiateCubeList = new List<GameObject>();

    private void Start()
    {
        CubeSpawn(redCubePrefab, RedCubeCountFromTo);
        CubeSpawn(blueCubePrefab, BlueCubeCountFromTo);
    }

    void CubeSpawn(GameObject prefab, Vector2Int Count)
    {
        int spawnCount = Random.Range(Count.x, Count.y);
        //GameObject instantiate;

        while (spawnCount > 0)
        {
            spawnCount--;
            Vector3 pos = new Vector3(
                Random.Range(spawnPoint.position.x - volume.x, spawnPoint.position.x + volume.x),
                Random.Range(spawnPoint.position.y - volume.y, spawnPoint.position.y + volume.y),
                Random.Range(spawnPoint.position.z - volume.z, spawnPoint.position.z + volume.z));
            GameObject instantiate = Instantiate(prefab, pos, Quaternion.identity, parent.transform);
            if (instantiate != null)
            {
                InstantiateCubeList.Add(instantiate);
            }
        }
    }
}
