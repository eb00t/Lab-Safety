using UnityEngine;

public class WalkEnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    [SerializeField] private Transform canvas;

    private void Awake()
    {
        initScale = transform.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (transform.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        if (_direction == 1)
        {
            transform.localScale = new Vector3(Mathf.Abs(initScale.x) * -1, initScale.y, initScale.z);
            canvas.rotation = new Quaternion(canvas.rotation.x, canvas.rotation.y, 180, canvas.rotation.w);
        }
        else if (_direction == -1)
        {
            transform.localScale = new Vector3(Mathf.Abs(initScale.x) * 1, initScale.y, initScale.z);
            canvas.rotation = new Quaternion(canvas.rotation.x, canvas.rotation.y, 0, canvas.rotation.w);
        }

        //Move in that direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed, transform.position.y, transform.position.z);
    }
}