using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody ball_rb;
    public float ball_speed;
    public Vector3 start_pos;
    void Start()
    {
        ball_rb = GetComponent<Rigidbody>();
        ball_rb.isKinematic = true;
        ball_speed = 16;
        start_pos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "block")
        {
            collision.gameObject.SetActive(false);
            transform.position = start_pos;
            ball_rb.velocity = Vector3.zero;
            ball_rb.isKinematic = true;
        }
        if(collision.gameObject.tag == "enemy")
        {
            ReturnBall();
        }
    }

    public void ReturnBall()
    {
        transform.position = start_pos;
        ball_rb.velocity = Vector3.zero;
        ball_rb.isKinematic = true;
    }
}
