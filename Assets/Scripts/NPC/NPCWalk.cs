using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    private bool left = false, right = true;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (right && !left) 
        {
            animator.SetFloat("Horizontal", transform.position.x);
            transform.position = Vector2.MoveTowards(
                transform.position, 
                new Vector2(4, 5), 
                1 * Time.deltaTime);
        }

        else if (left && !right)
        {
            animator.SetFloat("Horizontal", transform.position.x);
            transform.position = Vector2.MoveTowards(
                transform.position, 
                new Vector2(-12, 0), 
                1 * Time.deltaTime);
        }

        if (transform.position.x <= -12 && transform.position.x <= 0)
        {
            right = true;
            left = false;
        }
        else if (transform.position.x >= 4 && transform.position.y >= 5)
        {
            right = false;
            left = true;
        }
    }
}
