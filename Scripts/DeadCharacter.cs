using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCharacter : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Die");
        Destroy(this.gameObject, 0.5f);
    }
}
