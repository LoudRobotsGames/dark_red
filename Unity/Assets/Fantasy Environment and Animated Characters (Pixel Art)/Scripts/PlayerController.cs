using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Vector3 _lastPosition;

    public float speed = 3.5f; //speed of the player
    public float threshold = 0.1f;
    public BoxCollider2D attackTrigger;

    private bool facingRight = true; //for Flip the player
    private bool blockState = false; //for blocking movement of the player
    private bool attack1 = false; //to identify player's attack
    private Vector2 zero = new Vector2(0, 0);
    private bool inputIsBlocked = false;

    private DialogTrigger dialogGiver = null;

    public void BlockInput()
    {
        inputIsBlocked = true;
    }

    public void ReleaseInput()
    {
        inputIsBlocked = false;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        _lastPosition = transform.position;
    }

    //_______________________________________________________________
    //_______________________________________________________________

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = zero;
        if (!inputIsBlocked)
        {
            movement = new Vector2(moveHorizontal, moveVertical);
        }

        //Player Movement
        if (blockState == false)
            rigidbody2D.velocity = movement * speed;
        else
            rigidbody2D.velocity = zero;

        Vector3 pos = transform.position;
        float move = Vector3.Distance(_lastPosition, pos);

        //Player Run
        if (move > threshold)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (rigidbody2D.velocity.sqrMagnitude < (threshold * threshold) * 5f)
        {
            rigidbody2D.velocity = zero;
            animator.SetBool("Run", false);
        }

        _lastPosition = pos;
        //Player Flip Call
        if (movement.x > 0 && !facingRight)
            Flip();
        else if (movement.x < 0 && facingRight)
            Flip();
    }
    //_______________________________________________________________
    //_______________________________________________________________

    void Update()
    {
        if (!inputIsBlocked)
        {
            //Player Attack1 Call
            if (Input.GetButtonDown("Fire1") && attack1 == false && animator.GetBool("Death_bool") == false)
            {
                if (dialogGiver != null)
                {
                    bool inDialog = dialogGiver.AttemptDialog(this);                       
                    if (!inDialog)
                    {
                        BeginAttack();
                    }
                }
                else
                {
                    BeginAttack();
                }
            }

            //Player Hit Call
            if (Input.GetKeyDown(KeyCode.H) && animator.GetBool("Death_bool") == false)
                StartCoroutine("Hit");

            //Player Death Call
            if (Input.GetKeyDown(KeyCode.G) && animator.GetBool("Death_bool") == false)
                StartCoroutine("Death");
        }
    }
    //_______________________________________________________________
    //_______________________________________________________________

    //Player Flip
    void Flip()
    {
        if (blockState == false)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    //_______________________________________________________________
    //_______________________________________________________________

    private void BeginAttack()
    {
        StopCoroutine("Attack1");
        StartCoroutine("Attack1");
    }

    //Player Attack1
    IEnumerator Attack1()
    {
        if (blockState == false)
        {
            animator.SetTrigger("Attack_01");
            animator.SetBool("Idle_in_Fight", true);
            StartCoroutine("BlockstateTimer", 2.4f);

            yield return new WaitForSeconds(0.1f);
            attack1 = true;
            yield return null;
            attack1 = false;
            yield return new WaitForSeconds(0.4f);
            // Wait another five seconds before clearing combat idle
            yield return new WaitForSeconds(5f);
            animator.SetBool("Idle_in_Fight", false);
        }
    }

    //Player Death
    IEnumerator Death()
    {
        animator.SetBool("Death_bool", true);
        animator.SetTrigger("Death_01");
        blockState = true;
        yield return null;
    }

    //Player Hit
    IEnumerator Hit()
    {
        animator.SetTrigger("Hit");
        StartCoroutine("BlockstateTimer", 2.4f);
        yield return null;
    }

    //Timer which blocking movement of the player
    IEnumerator BlockstateTimer(float timer)
    {
        float bstimer = 0f;
        if (animator.GetBool("Death_bool") == false)
        {
            for (bstimer = timer; bstimer >= 0f; bstimer -= 0.1f)
            {
                blockState = true;
                yield return new WaitForSeconds(0.01f);
            }
        }
        if (animator.GetBool("Death_bool") == false)
            blockState = false;
    }

    public void OnAttack()
    {
        Bounds bounds = attackTrigger.bounds;
        int barrels = LayerMask.NameToLayer("Barrels");
        int crates = LayerMask.NameToLayer("Crates");
        int enemies = LayerMask.NameToLayer("Enemies");
        int mask = 1 << barrels;
        mask |= 1 << crates;
        mask |= 1 << enemies;
        Collider2D collider = Physics2D.OverlapBox(bounds.center, bounds.size, 0, mask);
        if (collider != null)
        {
            IAttackable attackable = collider.gameObject.GetComponent<IAttackable>();
            if (attackable != null)
            {
                attackable.Attack();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        DialogTrigger trigger = other.GetComponentInChildren<DialogTrigger>();
        if (trigger != null)
        {
            dialogGiver = trigger;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        DialogTrigger trigger = other.GetComponentInChildren<DialogTrigger>();
        if (trigger != null)
        {
            dialogGiver = null;
        }
    }
}