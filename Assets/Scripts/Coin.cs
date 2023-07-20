using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Collider bola;
    public CoinSpawner coinSpawner;
    public float existTime;

    private float timer = 0;
    

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= existTime)
        {
            Destroy(gameObject);
            coinSpawner.coinSpawned--;
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        coinSpawner.coinSpawned--;
    }
}
