using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    // untuk mengatur kecepatan bola setelah memantul
    public float multiplier;
    // untuk mengatur warna bumper
    public Color color;
    // komponen renderer pada object yang akan diubah
    private Renderer r;
    public Animator bumperAnimator;

    private void Start()
    {
        r = GetComponent<Renderer>();
        bumperAnimator = GetComponent<Animator>();
        r.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            bumperAnimator.SetTrigger("hit");
        }
    }
}
