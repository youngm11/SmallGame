using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Destroy the bullet after 3 seconds
        Destroy(this.gameObject, 3f);

        //Get components to use
        rb = GetComponent<Rigidbody2D>();

        //Set the direction to point at the player
        GameObject player = GameObject.Find("Player");
        direction = player.transform.position - transform.position;
        direction = direction.normalized;

        //Add a force to the rigidbody to get it to move
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
