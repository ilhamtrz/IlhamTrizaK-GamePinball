using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    public GameObject bola;
    private BallController ballController;
    private Collider ballCollider;

    private void Start()
    {
        ballCollider = bola.GetComponent<Collider>();
        ballController = bola.GetComponent<BallController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == ballCollider)
        {
            ballController.ResetPosition();
        }
    }
}
