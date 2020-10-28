using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Move : MonoBehaviour
{
    public float movementspeed = 5;
    public float jumpspeed = 1;
    public  float distandetoground = 1;
    Rigidbody2D rb;

    BoxCollider2D bc;
    int GroundMask;
    Animator animatorr;
    int swordHash = Animator.StringToHash("sword");
    int HEadHash = Animator.StringToHash("HEad");
    // Start is called before the first frame update


    bool IsTurned = false;

    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInParent < BoxCollider2D>();
        animatorr = GetComponent<Animator>();
        GroundMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    //
    //animatorr.SetTrigger(Hash);
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.O))
        {
            animatorr.SetFloat(swordHash, Mathf.Abs(horizontalInput));
           
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
        
            animatorr.SetTrigger(HEadHash);
        }





        if (horizontalInput<0 && !IsTurned) 
        {
            transform.localScale = new Vector2(-1, 1);
            IsTurned = true;
        }
        else
        if (horizontalInput > 0 && IsTurned)
        {
            transform.localScale = new Vector2(1, 1);
            IsTurned = false;
        }

        Vector2 vel = rb.velocity;
        //rb.AddForce(transform.right * movementspeed * horizontalInput); - same , but different
        vel.x = (transform.right * movementspeed * horizontalInput).x;
        if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded() )
        {
            
            //rb.AddForce(transform.up * jumpspeed); - same, but different 
            vel.y = (transform.up * jumpspeed).y;
        }

        rb.velocity = vel;
    }

    private bool IsGrounded()           //ci postava sa nachadza na collidery 
    {
        Vector2 rayStartPosition = transform.position;
        rayStartPosition.y -= (bc.bounds.size.y / 2); //rozmer boxcollideru 

        Debug.DrawRay(rayStartPosition, Vector2.down * distandetoground, Color.red, 1);  //smer, odkial, vypis cervenmy, nma 1sekundu
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, Vector2.down, distandetoground);
        if (hit)
        {
            Debug.Log("hit");
            return true;
        }
        return false;

    }
}