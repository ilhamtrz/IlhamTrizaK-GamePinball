using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
	public KeyCode input;
	private HingeJoint hinge;


	private float targetPressed;
	private float targetRelease;

	private void Start()
    {
		// hinge joint disimpan saat start terlebih dahulu
		hinge = GetComponent<HingeJoint>();
		targetPressed = hinge.limits.max;
		targetRelease = hinge.limits.min;
	}
    private void Update()
	{
		ReadInput();
		MovePaddle();
	}

	private void ReadInput()
	{
		// langsung menggunakan variabel yang sudah dibuat saat Start
		JointSpring jointSpring = hinge.spring;

		// mengubah value spring saat input ditekan dan dilepas
		if (Input.GetKey(input))
		{
			jointSpring.targetPosition = targetPressed;
		}
		else
		{
			jointSpring.targetPosition = targetRelease;
		}

		// disni pun langsung menggunakan variabel
		hinge.spring = jointSpring;
	}

	private void MovePaddle()
	{
		// Move Paddle Here
	}
}
