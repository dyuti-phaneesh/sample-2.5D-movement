using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // where ray hits collider
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;

        // downwards, only detects terrain layer
        if(Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if(hit.collider != null) //if ray hits terrain, move player above point
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        // left and right

        if (x != 0 && x < 0)
            sr.flipX = true;
        else if (x != 0 && x > 0)
            sr.flipX = false;
        //if (y != 0 && y < 0)
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        //else if(y != 0 && y > 0)
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
}
