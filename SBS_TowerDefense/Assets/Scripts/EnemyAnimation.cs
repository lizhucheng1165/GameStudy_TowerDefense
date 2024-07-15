using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMoving(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
    }

    public void TriggerDie()
    {
        animator.SetTrigger("die");
    }

    public void TriggerHit()
    {
        animator.SetTrigger("hit");
    }
}
