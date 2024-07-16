using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
   private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayExplosion()
    {
        animator.SetTrigger("isExplosion");
    }
}
