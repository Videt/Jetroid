using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour
{
    public float attackDelay = 3f;
    public GameObject projectile;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (attackDelay != 0)
        {
            StartCoroutine(OnAttack());
        }
    }

    void Update()
    {
        animator.SetInteger("AnimState", 0);
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(attackDelay);

        Fire();
        StartCoroutine(OnAttack());
    }

    private void Fire()
    {
        animator.SetInteger("AnimState", 1);
    }

    void OnFire()
    {
        if (projectile != null)
        {
            GameObject clone = Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}
