using System.Collections;
using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    private bool right = true;

    private Animator animator;
    private bool stop = false;


    Vector3 lastPosition = Vector3.zero;
    float speed;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        if (right && !stop) 
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Speed", speed);
            transform.position = Vector2.MoveTowards(
                transform.position, 
                new Vector2(4, 5), 
                1 * Time.deltaTime);
        }

        else if (!right && !stop)
        {
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Speed", speed);
            transform.position = Vector2.MoveTowards(
                transform.position, 
                new Vector2(-12, 0), 
                1 * Time.deltaTime);
        }

        if (transform.position.x <= -12 && transform.position.x <= 0)
        {
            StartCoroutine(RightMove());
        }
        else if (transform.position.x >= 4 && transform.position.y >= 5)
        {
            StartCoroutine(LeftMove());
        }

        if (stop)
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                new Vector2(-12, 0), 
                0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            print("Coollider");
            stop = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            print("Coollider2");
            stop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            stop = false;
        }
    }

    IEnumerator RightMove()
    {
        yield return new WaitForSeconds(2);
        right = true;
    }

    IEnumerator LeftMove()
    {
        yield return new WaitForSeconds(2);
        right = false;
    }

}
