using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawn : MonoBehaviour
{
    public GameObject prefab1, prefab2, prefab3, prefab4;
    public GameObject prefab;
    public float spawnX;
    public float spawnY1, spawnY2, spawnY3, spawnY4;
    public float spawnRate = 150f;
    float nextSpawnDistance = 100f;
    float nextSpawnTime = 0f;
    int whatToSpawn;

    void Start()
    {
        spawnX = (Camera.main.pixelWidth * 2) + 300f;
        spawnY1 = Camera.main.pixelHeight - 155f;
        spawnY2 = Camera.main.pixelHeight - 155f;
        spawnY3 = Camera.main.pixelHeight - 150f;
        spawnY4 = Camera.main.pixelHeight - 110f;
    }

    void Update()
    {
        if (Camera.main.transform.position.x > nextSpawnDistance / 2 && Time.time > nextSpawnTime / 2)
        {
            whatToSpawn = Random.Range(1, 5);

            switch (whatToSpawn)
            {
                case 1:
                    prefab = Instantiate(prefab1, new Vector3(spawnX, spawnY1, 0), Quaternion.identity);
                    break;
                case 2:
                    prefab = Instantiate(prefab2, new Vector3(spawnX, spawnY2, 0), Quaternion.identity);
                    break;
                case 3:
                    prefab = Instantiate(prefab3, new Vector3(spawnX, spawnY3, 0), Quaternion.identity);
                    break;
                case 4:
                    prefab = Instantiate(prefab4, new Vector3(spawnX, spawnY4, 0), Quaternion.identity);
                    break;
            }

            //Debug.Log(prefab.transform.position.x);
            spawnX += 900f;
            nextSpawnDistance = Camera.main.transform.position.x + spawnX;
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
