using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    [Header("SpellScript Reference")]
    public SpellScript refSpellScript;
    [Header("Target References")]
    public Animator doorAnimator;
    public Animator chestAnimator;
    public Animator enemyAnimator;
    public void SpellResult(SpellTarget spellTarget)
    {
        //Damages enemies
        if (spellTarget == SpellTarget.enemy)
        {
            enemyAnimator.SetTrigger("EnemyTrigger");
        }
        //Opens doors
        if (spellTarget == SpellTarget.door)
        {
            doorAnimator.SetTrigger("DoorTrigger");
        }
        //unlocks chests
        if (spellTarget == SpellTarget.chest)
        {
            chestAnimator.SetTrigger("ChestTrigger");
        }
    }
}
