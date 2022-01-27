using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columnPull : MonoBehaviour
{
    public int columnPoolSize = 5; 
    private GameObject[] columns;
    public GameObject columnPrefab;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25);
    private float timeSinceLastSpawn;

    public float spawnrate;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    private float spawnXpos = 10f;
    private int currentcol = 0;

    
    void Start()
    {
        timeSinceLastSpawn = 0f; 

        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);

        } 
    }

    
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnrate)
        {
            timeSinceLastSpawn = 0f;
            float spawnYposition = Random.Range(columnMin, columnMax);
            columns[currentcol].transform.position = new Vector2(spawnXpos, spawnYposition);
            currentcol++; 

            if (currentcol >= columnPoolSize)
            {
                currentcol = 0; 
            }
        }
    }
}
