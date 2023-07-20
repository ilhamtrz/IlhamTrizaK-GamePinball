using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int maxSpawn;
    [SerializeField] private float spawnInterval;
    [SerializeField] private Collider bola;
    //Jumlah coin yang sudah di spawn
    public int coinSpawned = 0;
    //jumlah koin yang sudah dikumpulkan player
    public int coinCount = 0;

    private bool isSpawned = false;
    private float spawnTimer=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coinSpawned < maxSpawn)
        {
            isSpawned = false;
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= spawnInterval)
            {
                if(!isSpawned)
                    SpawnCoin();
                isSpawned = true;
                spawnTimer = 0;
            }
        }
    }

    private void SpawnCoin()
    {
        Vector3 randomPosition = new Vector3(Random.Range(this.transform.position.x - 4, this.transform.position.x + 4), this.transform.position.y, Random.Range(this.transform.position.z - 5, this.transform.position.z + 5));
        GameObject generatedObject =  Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        Coin generatedCoin = generatedObject.GetComponent<Coin>();
        generatedCoin.bola = bola;
        generatedCoin.coinSpawner = this;
        coinSpawned++;
    }
}
