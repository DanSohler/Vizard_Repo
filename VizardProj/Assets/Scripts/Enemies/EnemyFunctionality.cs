using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunctionality : SpellEffect
{
    [SerializeField] private float maxHealth = 1;
    private float currentHealth;

    [SerializeField] private EnemyHealth healthBar;
    [SerializeField] Collider attackRange;
    [SerializeField] bool isAttacking = false;
    [SerializeField] PlayerCam playerCamScript;
    [SerializeField] VerbDisable disableScript;

    private void Start()
    {
        currentHealth = maxHealth;
        playerCamScript = GetComponent<PlayerCam>();

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            enemyAnimator.SetTrigger("EnemyTrigger");
        }

        if (playerCamScript.currentState == menuState.menuEnabled)
        {
            Debug.Log("Begin attack phase");
        }
    }


    public IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        disableScript.DisableVerb();
    }

}

public enum enemyState 
{ 
    attacking,
    idle
}



