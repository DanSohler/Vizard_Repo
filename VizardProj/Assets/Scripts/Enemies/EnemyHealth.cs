using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Image healtbarSprite;
    [SerializeField] private float reduceSpeed = 2f;
    private float target = 1;
    private Camera playerCam;

    private void Start()
    {
        playerCam = Camera.main;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        target = currentHealth / maxHealth;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - playerCam.transform.position);
        healtbarSprite.fillAmount = Mathf.MoveTowards(healtbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.C))
        {
            target = target - 0.25f;
        }

    }


}
