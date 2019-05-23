using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : Effect
{
    public int Damage = 1;

    public Damages(Skill skill)
    {
        this.skill = skill;
    }

    public override void Spell()
    {
        skill.Spell();
    }

    public override void Show()
    {
        skill.Show();
        Debug.Log("造成 傷害 "+ Damage);
    }
}
