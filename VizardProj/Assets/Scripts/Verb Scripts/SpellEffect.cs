using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    [Header("SpellScript Reference")]
    public SpellScript refSpellScript;
    public GameObject refSpellScriptVolume;
    [Header("Target References")]
    public Animator doorAnimator;
    public Animator chestAnimator;
    public Animator enemyAnimator;
    [Header("Enemy References")]
    [SerializeField] private float enemyDamage = 1;
    [SerializeField] private EnemyFunctionality enemyScript;
    public void SpellResult(SpellTarget spellTarget)
    {
        //Damages enemies
        if (spellTarget == SpellTarget.enemy)
        {
            enemyScript.DamageEnemy(enemyDamage);
        }
        //Opens doors
        if (spellTarget == SpellTarget.door)
        {
            doorAnimator.SetTrigger("DoorTrigger");
            refSpellScriptVolume.SetActive(false);
        }
        //unlocks chests
        if (spellTarget == SpellTarget.chest)
        {
            chestAnimator.SetTrigger("ChestTrigger");
            refSpellScriptVolume.SetActive(false);
        }
    }
}
