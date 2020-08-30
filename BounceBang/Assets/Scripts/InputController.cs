using UnityEngine;

public class InputController : MonoBehaviour
{
    public Transform arrow;
    public Transform ball;
    Vector3 ball_direction;
    BallController bc;
    Rigidbody player_rb;
    float player_speed;
    void Start()
    {
        bc = ball.GetComponent<BallController>();
        player_rb = transform.GetComponent<Rigidbody>();
        player_speed = 0.035f;
    }
    void OnMouseDown()
    {
        player_rb.isKinematic = false;
        bc.ReturnBall();
        arrow.position = ball.position;
        arrow.LookAt(transform);
        arrow.gameObject.SetActive(true);
        player_rb.velocity = Vector3.zero;
    }
    private void OnMouseUp()
    {
        if(ball_direction != null)
        {
            arrow.gameObject.SetActive(false);
            bc.ball_rb.isKinematic = false;
            bc.ball_rb.velocity = -ball_direction * bc.ball_speed;
            player_rb.isKinematic = true;
        }
    }
    public void OnMouseDrag()
    {
        if (bc.ball_rb.isKinematic)
        {
            Vector2 mousePos = new Vector2();
            Vector3 point = new Vector3();
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Camera.main.pixelHeight - Input.mousePosition.y;

            point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 19));

            if (point.x < 0)
            {
                transform.position += new Vector3(player_speed, 0, 0);
            }
            if (point.x > 0)
            {
                transform.position += new Vector3(-player_speed, 0, 0);
            }
            if (transform.position.z < point.z)
            {
                transform.position += new Vector3(0, 0, player_speed);
            }
            if (transform.position.z > point.z)
            {
                transform.position += new Vector3(0, 0, -player_speed);
            }
            ChangeArrowLenght();
        }
    }
    void ChangeArrowLenght()
    {
        if (arrow.gameObject.activeInHierarchy)
        {
            Vector3 heading = bc.start_pos - transform.position;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            arrow.localScale = new Vector3(distance / 10, arrow.localScale.y, arrow.localScale.z);
            direction.x = (direction.x + 1) / 2;
            ball_direction = -direction;
            arrow.LookAt(transform);
        }
    }
}
