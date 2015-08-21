using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    public Rigidbody2D bullet;
    
	public float createTime = 5f;
    public float createDelay = 3f;
   


   void Start()
    {
        InvokeRepeating("Bullet", createTime, createDelay);
    }

   void Bullet()
   {

      Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
   }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
