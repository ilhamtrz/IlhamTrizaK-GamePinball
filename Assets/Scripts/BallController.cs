using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // set max speed nya di inspector
    public float maxSpeed;

    private Rigidbody rig;
    private Vector3 resetPosition;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        resetPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    private void Update()
    {
        // cek besaran (magnitude) kecepatannya
        if (rig.velocity.magnitude > maxSpeed)
        {
            // kalau melebihi buat vector velocity baru dengan besaran max speed
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }
    }

    public void ResetPosition()
    {
        this.transform.position = new Vector3(resetPosition.x,resetPosition.y,resetPosition.z);
        rig.velocity = new Vector3(0, 0, 0);
    }
}
