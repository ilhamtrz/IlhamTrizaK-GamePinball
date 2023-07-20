using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public BallController ballController;
    public Collider ballCollider;

    public TrapSpawner trapSpawner;
    public float existTime;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= existTime)
        {
            Destroy(gameObject);
            trapSpawner.trapSpawned--;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other == ballCollider)
        {
            ballController.ResetPosition();
            Destroy(gameObject);
            trapSpawner.trapSpawned--;
        }
    }
}
