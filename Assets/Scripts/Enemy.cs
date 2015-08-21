using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float moveSpeed = 2f;		// The speed the enemy moves at.

    private GameObject player;

    public bool isUp = false;

    private Camera _camera;

    private Vector3 direction;

    private Vector3 lastUFO;
    private Vector3 lastMouse;
    private Vector3 lastPosition;

    private RaycastHit2D hitGround;
    private RaycastHit2D hitEnemy;

	void Awake()
	{
        player = GameObject.FindGameObjectWithTag("Player");
        _camera = FindObjectOfType<Camera>() as Camera;
        lastPosition = transform.position;

	}

	void FixedUpdate ()
	{

        rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	

        if (player && _camera && isUp && Input.GetMouseButton(0))
        {
			direction = (player.transform.position - _camera.ScreenToWorldPoint(Input.mousePosition)).normalized;

			//改变transform
			float tempx= (((lastPosition.y - lastUFO.y) * (lastMouse.x -lastUFO.x))/(lastMouse.y - lastUFO.y)) + lastUFO.x;
			
			transform.position = new Vector3(tempx,lastPosition.y,lastPosition.z);
			

			

			/*
			if ((player.transform.position != lastUFO) || (_camera.ScreenToWorldPoint(Input.mousePosition) != lastMouse))
			{
				
				float tempx= (((lastPosition.y - lastUFO.y) * (lastMouse.x -lastUFO.x))/(lastMouse.y - lastUFO.y)) + lastUFO.x;
				
				transform.position = new Vector3(tempx,lastPosition.y,lastPosition.z);
				
				lastUFO = player.transform.position;
				
				lastMouse = _camera.ScreenToWorldPoint(Input.mousePosition);
				
				lastPosition = transform.position;
			}

			*/

            
            
            Quaternion Rotation = Quaternion.Euler(0f, 0f, 360f-(Mathf.Atan2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * Mathf.Rad2Deg));

            transform.rotation = Rotation;

            
			rigidbody2D.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);


			lastUFO = player.transform.position;
			
			lastMouse = _camera.ScreenToWorldPoint(Input.mousePosition);
			
			lastPosition = transform.position;

        }
        

        
		
	}



	
	
}
