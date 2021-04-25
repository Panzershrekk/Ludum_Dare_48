using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuable : MonoBehaviour
{
    public int pointAwarded;
    public Animator animator;
    public AudioSource lootSound;
    public ParticleSystem particle;

    public void PlayLootAnimation()
    {
        animator.SetTrigger("Looted");
        particle.Play();
        lootSound.Play();
    }

    public void OnLoot()
    {
        Destroy(gameObject);
    }
}
