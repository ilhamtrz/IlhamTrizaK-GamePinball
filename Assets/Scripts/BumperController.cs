using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    // untuk mengatur kecepatan bola setelah memantul
    public float multiplier;
    

    // komponen renderer pada object yang akan diubah
    private Renderer r;
    public Animator bumperAnimator;
    public List<Material> bumperColors;
    private int colorIndex = 0;

    private void Start()
    {
        r = GetComponent<Renderer>();
        bumperAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            ChangeColor();
            bumperAnimator.SetTrigger("hit");
        }
    }

    private void ChangeColor()
    {
        colorIndex++;
        if(colorIndex >= bumperColors.Count)
        {
            colorIndex = 0;
            r.material.color = bumperColors[colorIndex].color;
        }
        else
        {
            r.material.color = bumperColors[colorIndex].color;
        }
    }
}
