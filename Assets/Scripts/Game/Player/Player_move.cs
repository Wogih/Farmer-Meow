using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField] private float move_speed;
    [SerializeField] private float sprint_koef;

    private Vector2 velocity;
    private Rigidbody2D rb;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.game_stop) return;

        Move();
        Move_animator();
    }

    void Move()
    {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        velocity.Normalize();
        rb.MovePosition((Vector2)transform.position + (velocity * move_speed * Time.fixedDeltaTime));
    }

    void Move_animator()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetFloat("Horizontal", velocity.x);
            animator.SetFloat("Vertical", velocity.y);
        }
        animator.SetFloat("Speed", velocity.magnitude);
    }
}
