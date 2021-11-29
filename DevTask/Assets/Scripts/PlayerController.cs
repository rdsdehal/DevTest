using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public float speed = 12f;
	public bool isPlayer = false;

	// Use this for initialization
	void Start()
	{
		if (!isPlayer)
		{
			speed = -speed;
		}
	}

	// Update is called once per frame
	void Update()
	{
		Rigidbody rb = GetComponent<Rigidbody>();

		if (Input.GetKey(KeyCode.A))
			rb.AddForce(Vector3.left * speed);
		if (Input.GetKey(KeyCode.D))
			rb.AddForce(Vector3.right * speed);
		if (Input.GetKey(KeyCode.W))
			rb.AddForce(Vector3.forward * speed);
		if (Input.GetKey(KeyCode.S))
			rb.AddForce(Vector3.back * speed);

	}

	// Method to handle the collision
	private void OnCollisionEnter(Collision collision)
	{
		Collider cb = GetComponent<Collider>();
		if (collision.gameObject.tag == "BlueWall" && isPlayer)
		{
			Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), cb);
		}
		if (collision.gameObject.tag == "RedWall" && !isPlayer)
		{
			Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), cb);
		}
		if (collision.gameObject.tag == "Enemy" && isPlayer)
		{
			Debug.Log("LOST");
			this.gameObject.SetActive(false);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		}
		if (collision.gameObject.tag == "Win" && isPlayer)
		{
			Debug.Log("WON");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		}
	}

}
