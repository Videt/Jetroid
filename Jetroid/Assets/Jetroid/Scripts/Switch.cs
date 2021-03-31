using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public DoorTrigger[] doorTriggers;
    public bool sticky;

    private bool down = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        down = true;

        animator.SetInteger("AnimState", 1);

        foreach (DoorTrigger trigger in doorTriggers)
        {
            if (trigger != null)
                trigger.Toggle(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (sticky && down)
            return;

        down = false;

        animator.SetInteger("AnimState", 2);

        foreach (DoorTrigger trigger in doorTriggers)
        {
            if (trigger != null)
                trigger.Toggle(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = sticky ? Color.red : Color.green;
        foreach (var trigger in doorTriggers)
            Gizmos.DrawLine(transform.position, trigger.door.transform.position);
    }
}
