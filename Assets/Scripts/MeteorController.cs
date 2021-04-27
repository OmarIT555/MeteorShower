using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeteorController : MonoBehaviour {

	Rigidbody myBod;
	void Start () {
		myBod = GetComponent<Rigidbody>();
		myBod.velocity = new Vector3(0, -12, 0);
	}

	void Update () {

		if (transform.position.y < -20)
		{
			Destroy(gameObject);
		}
		
	}

}
