using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Used to store the users inputs to make the player move.
    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       //Set the input based on the player's key presses.
       //Horizontal
       if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }
       else if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else
        {
            direction.x = 0;
        }

        //Verticle
        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        else
        {
            direction.y = 0;
        }

        //Make the direction vestor have a length of one
        direction = direction.normalized;
    }

    private void FixedUpdate()
    {
        //Move the character
        rb.MovePosition(rb.position + (direction * speed * Time.fixedDeltaTime));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(Vector3.zero, (Vector3)direction);
    }
}
