using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float firstJumpForce       = 150;
    [SerializeField] float doubleJumpForce      = 150;
    [SerializeField] float defaultGravityScale  = 10;
    [SerializeField] float fallGravityScale     = 20;

    [SerializeField] int maxJumps               = 2;

    [SerializeField] public Rigidbody2D body;

    int availableJumps;

    Vector2 currentVelocity;


    
    public void Start()
    {
        ResetJumps();
    }

    void Update()
    {
        if (body.velocity.y > 0)
        {
            body.gravityScale = defaultGravityScale;
        } else
        {
            body.gravityScale = fallGravityScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger entered against layer " + collision.gameObject.layer);
        if (collision.gameObject.layer == 3)
        {
            ResetJumps();
        }
    }

    public void PerformJump()
    {
        if (availableJumps > 0)
        {
            ResetVerticalVelocity();
            body.AddForce(Vector2.up * firstJumpForce, ForceMode2D.Impulse);
            availableJumps--;
        }
    }

    void ResetVerticalVelocity()                                                //For additional jumps, reset downward velocity to keep jumps consistent
    {
        currentVelocity = body.velocity;
        currentVelocity.y = 0;
        body.velocity = currentVelocity;
    }

    public void ResetJumps()
    {
       availableJumps = maxJumps;
    }
}
 