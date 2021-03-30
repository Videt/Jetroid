using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float closeDelay = 0.5f;

    Animator animator;
    new BoxCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    void EnableCollider2D()
    {
        collider2D.enabled = true;
    }

    void DisableCollider2D()
    {
        collider2D.enabled = false;
    }

    public void Open()
    {
        animator.SetInteger("AnimState", 1);
    }

    public void Close()
    {
        StartCoroutine(CloseNow());
    }

    IEnumerator CloseNow()
    {
        yield return new WaitForSeconds(closeDelay);
        animator.SetInteger("AnimState", 2);
    }
}
