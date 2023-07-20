using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private int maxSpawn;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GameObject bola;
    //Jumlah trap yang sudah di spawn
    public int trapSpawned = 0;
    //jumlah koin yang sudah dikumpulkan player
    public int trapCount = 0;

    private bool isSpawned = false;
    private float spawnTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (trapSpawned < maxSpawn)
        {
            isSpawned = false;
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                if (!isSpawned)
                    SpawnTrap();
                isSpawned = true;
                spawnTimer = 0;
            }
        }
    }

    private void SpawnTrap()
    {
        Vector3 randomPosition = new Vector3(Random.Range(this.transform.position.x - 9, this.transform.position.x + 4), this.transform.position.y, Random.Range(this.transform.position.z - 5, this.transform.position.z));
        GameObject generatedObject = Instantiate(trapPrefab, randomPosition, Quaternion.identity);
        Trap generatedTrap = generatedObject.GetComponent<Trap>();
        generatedTrap.ballController = bola.GetComponent<BallController>();
        generatedTrap.ballCollider = bola.GetComponent<Collider>();
        generatedTrap.trapSpawner = this;
        trapSpawned++;
    }
}
