using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuable : MonoBehaviour
{
    public int pointAwarded;
    public Animator animator;

    public void PlayLootAnimation()
    {
        animator.SetTrigger("Looted");
    }

    public void OnLoot()
    {
        Destroy(gameObject);
    }
}
