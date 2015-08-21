using UnityEngine;
using System.Collections;

public class Liner : MonoBehaviour
{
    private LineRenderer line_renderer;

    public Camera _camera;

    private Vector3 direction;

    Vector3 ground_P;

   
    bool isGround = false;

    bool isEnemy = false;

    private RaycastHit2D hitGround;
    private RaycastHit2D hitEnemy;

    // Use this for initialization
    void Start()
    {
        line_renderer = (LineRenderer)this.gameObject.GetComponent<LineRenderer>();
        line_renderer.SetWidth(1f, 3f);
        line_renderer.SetColors(Color.red, Color.green);
        line_renderer.SetVertexCount(2);
    }

    // Update is called once per frame
    void Update()
    {
       
            direction = (_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            isGround = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(direction.x, direction.y), Screen.height, 1 << LayerMask.NameToLayer("Ground"));

            hitGround = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(direction.x, direction.y), Screen.height, 1 << LayerMask.NameToLayer("Ground"));


            if (isGround)
            {

                ground_P = new Vector3(hitGround.point.x, hitGround.point.y, transform.position.z);

            }

            isEnemy = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(direction.x, direction.y), Screen.height, 1 << LayerMask.NameToLayer("Enemies"));

            hitEnemy = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(direction.x, direction.y), Screen.height, 1 << LayerMask.NameToLayer("Enemies"));



            
           




        if (Input.GetMouseButton(0))
        {
            if (line_renderer.enabled == false)
            {
                line_renderer.enabled = true;
            }
            line_renderer.SetPosition(0, transform.position);
            line_renderer.SetPosition(1, ground_P);



            if (isEnemy)
            {

                hitEnemy.transform.gameObject.GetComponent<Enemy>().isUp = true;

            }


        }
        else if (Input.GetMouseButtonUp(0))
        {
            line_renderer.enabled = false;

            
        }

        
    }


}
