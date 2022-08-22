using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Animator animator;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!InteractableManager.instance.target) return;
        if(collision.gameObject == InteractableManager.instance.target.gameObject)
        {
            if (breakingGarbageCoroutine == null) breakingGarbageCoroutine = StartCoroutine(BreakingGarbage(InteractableManager.instance.target));
        }
    }

    Coroutine breakingGarbageCoroutine;
    IEnumerator BreakingGarbage(InteractiveObject garbage)
    {
        float t = 0;
        float time = 0.7f;

        animator.SetBool("IsInteracting", true);

        while (t < time)
        {
            t += Time.deltaTime;
            yield return null;
        }

        animator.SetBool("IsInteracting", false);
        breakingGarbageCoroutine = null;

        garbage.SpawnRandomLoot();
        Destroy(garbage.gameObject);
        gameManager.RemoveOneEnergy();
    }
}
