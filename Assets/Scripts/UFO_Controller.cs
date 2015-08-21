using UnityEngine;
using System.Collections;
using System;

public class UFO_Controller : MonoBehaviour
{


    public Camera _camera;

    private float x;
    private float y;

    public float xSpeed;
    public float ySpeed;

    private Animator anim;



    // Use this for initialization
    void Start()
    {
        anim = transform.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x += (float)Math.Round(Input.acceleration.x, 1) * xSpeed;
        y += ((float)Math.Round(Input.acceleration.y, 1)) * ySpeed;

        if (_camera.WorldToScreenPoint(new Vector3(x, 0, 0)).x < 0.0f)
        {
            x = _camera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        }
        else if (_camera.WorldToScreenPoint(new Vector3(x, 0, 0)).x > (float)Screen.width)
        {
            x = _camera.ScreenToWorldPoint(new Vector3((float)Screen.width, 0, 0)).x;
        }

        if (_camera.WorldToScreenPoint(new Vector3(0, y, 0)).y < 0.0f)
        {
            y = _camera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        }
        else if (_camera.WorldToScreenPoint(new Vector3(0, y, 0)).y > (float)Screen.height)
        {
            y = _camera.ScreenToWorldPoint(new Vector3(0, (float)Screen.height, 0)).y;
        }

        anim.SetFloat("Speed", (float)Math.Round(Input.acceleration.x, 1));
        transform.position = new Vector3(x, y, 0);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 480.0f, 100.0f), "加速器X为：" + Math.Round(Input.acceleration.x, 1).ToString() + "Y为：" + Math.Round(Input.acceleration.y, 1).ToString() + "Z为：" + Math.Round(Input.acceleration.z, 1).ToString());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);

    }
}
