using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetInteger("AnimState", 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetInteger("AnimState", 2);
    }
}
