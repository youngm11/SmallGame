using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public Camera cam;
    public GameObject bullet;
    private float spawn_timer = 0;

    public int max_bullets_at_a_time = 5;
    public float min_spawn_time = 0.25f;
    public float max_spawn_time = 1f;

    // Update is called once per frame
    void Update()
    {
        //Spawn Bullets when the timer counts down
        spawn_timer -= Time.deltaTime;
        if(spawn_timer <= 0)
        {
           // Set the spawn time somewhere between the min and max spawn time
            spawn_timer = Random.Range(min_spawn_time, max_spawn_time);

            // Set the number of bullets to spawn between 1 and max bullets
            int bullets_to_spawn = Random.Range(1, max_bullets_at_a_time + 1);

            //Spawn that number of bullets
            for (int i = 0; i < bullets_to_spawn; i++)
            {
                SpawnBullet();
            }
        }
    }

    public void SpawnBullet()
    {
        GameObject new_bullet = Instantiate(bullet);
        int x_pos, y_pos;

        //50% chance to spawn
        if(Random.value < 0.5f) //Spawn at left/right
        {
            if (Random.value < 0.5f) // Spawn on the left
            {
                x_pos = 0;
            }
            //Spawn on the right
            else
            {
                x_pos = cam.scaledPixelWidth;
            }

            //Spawn at a random height
            y_pos = Random.Range(0, cam.scaledPixelHeight);
        }
        else //Spawn on the top/bottom
        {
            if (Random.value < 0.5f) // Spawn on the bottom
            {
                y_pos = 0;
            }
            //Spawn on the top
            else
            {
                y_pos = cam.scaledPixelHeight;

            }
        }

        //Spawn at a random width
        x_pos = Random.Range(0, cam.scaledPixelWidth);

        //Convert to world position
        Vector3 spawn_point = new Vector3(x_pos, y_pos, 0);
        spawn_point = cam.ScreenToWorldPoint(spawn_point);
        spawn_point.z = 0;

        //Position the bullet
        new_bullet.transform.position = spawn_point;
    }
}
