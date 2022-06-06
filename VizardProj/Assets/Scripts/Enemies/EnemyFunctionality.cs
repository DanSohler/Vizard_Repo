using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunctionality : SpellEffect
{
    [SerializeField] private float maxHealth = 3;
    private float currentHealth;

    [SerializeField] private EnemyHealth healthBar;
    [SerializeField] PlayerCam playerCamScript;
    [SerializeField] VerbDisable disableScript;

    private enemyState currentState;

    public void Awake()
    {
        currentState = enemyState.idle;
        currentHealth = maxHealth;
        playerCamScript = GetComponent<PlayerCam>();
        disableScript = GetComponent<VerbDisable>();

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            enemyAnimator.SetTrigger("EnemyTrigger");
            refSpellScriptVolume.SetActive(false);
            doorAnimator.SetTrigger("DoorTrigger");
        }

        if (currentState == enemyState.attacking)
        {
            //StartCoroutine(AttackPlayer());
        }

        healthBar.UpdateHealthBar(maxHealth, currentHealth);

        // Debug.Log("1231");
    }

    public void DamageEnemy(float damage)
    {
        currentHealth -= damage;
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
            StopCoroutine(AttackPlayer());
        }
    }


    public IEnumerator AttackPlayer()
    {
        Debug.Log("Attacking Player");
        yield return new WaitForSeconds(3f);
    }

}

public enum enemyState 
{ 
    attacking,
    idle
}



