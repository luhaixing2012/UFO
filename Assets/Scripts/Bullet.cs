using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	private GameObject player;
	public float speed;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");

		Quaternion Rotation = Quaternion.Euler(0f, 0f, 360f-(Mathf.Atan2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * Mathf.Rad2Deg));
		
		transform.rotation = Rotation;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(transform.position.y < player.transform.position.y)
		{
			rigidbody2D.velocity = new Vector2 (0, speed);
		}

	}

	void OnTriggerEnter2D (Collider2D col) 
	{
		if(col.tag == "ground")
		{
			Destroy (gameObject);
		}

	}


}
