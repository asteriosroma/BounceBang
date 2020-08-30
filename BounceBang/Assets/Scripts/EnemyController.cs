using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public BallController bc;
    Rigidbody enemy_rb;
    public float enemy_speed;
    bool moving_right;
    bool moving_left;
    void Start()
    {
        enemy_rb = GetComponent<Rigidbody>();
        enemy_speed = 18;
        moving_left = true;
        moving_right = false;
    }
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        if (bc.ball_rb.isKinematic)
        {
            if (moving_left)
            {
                enemy_rb.velocity = new Vector3(0, 0, -enemy_speed);
                if (transform.position.z <= -4.5)
                {
                    moving_left = false;
                    moving_right = true;
                }
            }
            if (moving_right)
            {
                enemy_rb.velocity = new Vector3(0, 0, enemy_speed);
                if (transform.position.z >= 4.5)
                {
                    moving_right = false;
                    moving_left = true;
                }
            }
        }
        else
        {
            float dif = bc.transform.position.z - transform.position.z;
            if (dif > 0.5)
            {
                enemy_rb.velocity = new Vector3(0, 0, enemy_speed);
            }
            if (dif < -0.5)
            {
                enemy_rb.velocity = new Vector3(0, 0, -enemy_speed);
            }
            if(dif >= -0.5 && dif <= 0.5)
            {
                enemy_rb.velocity = Vector3.zero;
            }
        }
    }
}
