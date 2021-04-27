using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

	public GameObject PlayerExplosion;
	public GameObject meteor;
	
	public float spawnTime;
	float timer;
	float time = 0;
	[SerializeField] Text countUpText;
	[SerializeField] Text GameOver;

	void Start () {
		timer = spawnTime;
	}
	
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			Spawn();
			timer = spawnTime;
		}
		float h = Input.GetAxis("Horizontal");

		transform.position = transform.position + (Vector3.right * 10 * h *Time.deltaTime);

		time += 1 * Time.deltaTime;
		countUpText.text = "Time: " + time.ToString("0");

	}

	void Spawn()
	{
		GameObject g = Instantiate(meteor);
		g.transform.position = transform.position + new Vector3(Random.Range(-21, 21), 30, 0);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(collision.gameObject);
		GameObject g = Instantiate(PlayerExplosion);
		g.transform.position = transform.position;
		Destroy(gameObject);
		GameOver.text = "You Crashed!" + "\n" +
			"Time: " + time.ToString("0") + " seconds" + "\n" + "\n" +
			"Press Space to start over";
	}

}
