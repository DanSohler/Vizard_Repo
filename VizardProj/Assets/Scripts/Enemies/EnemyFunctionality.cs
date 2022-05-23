using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunctionality : SpellEffect
{
    [SerializeField] private float maxHealth = 1;
    private float currentHealth;

    [SerializeField] private EnemyHealth healthBar;
    [SerializeField] bool isAttacking = false;
    [SerializeField] PlayerCam playerCamScript;
    [SerializeField] VerbDisable disableScript;

    private enemyState currentState;

    private void Start()
    {
        currentState = enemyState.idle;
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

        if (currentState == enemyState.attacking)
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                currentState = enemyState.attacking;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentState = enemyState.idle;
        }
    }


    public IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(2f);
        disableScript.DisableVerb();
    }

}

public enum enemyState 
{ 
    attacking,
    idle
}



