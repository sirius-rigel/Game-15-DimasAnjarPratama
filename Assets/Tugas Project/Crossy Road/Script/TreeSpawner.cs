using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject treePrefabs;

    [SerializeField]
    TerrainBlocks terrain;

    [SerializeField]
    int count = 2;

    private void Start()
    {
        List<Vector3> emptyPos = new List<Vector3>();

        for (int x = -terrain.Extend; x <= terrain.Extend; x++)
        {
            if (transform.position.z == 0 && x == 0)
                continue;
            emptyPos.Add(transform.position + Vector3.right * x);
        }

        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, emptyPos.Count);
            var spawnPos = emptyPos[index];
            Instantiate(treePrefabs, spawnPos, Quaternion.identity, this.transform);
            emptyPos.RemoveAt(index);
        }

        Instantiate(treePrefabs, transform.position + Vector3.right * -(terrain.Extend+1), Quaternion.identity, this.transform);
        Instantiate(treePrefabs, transform.position + Vector3.right * (terrain.Extend+1), Quaternion.identity, this.transform);
    }
}
