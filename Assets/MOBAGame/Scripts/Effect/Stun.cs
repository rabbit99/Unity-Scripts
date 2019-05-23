using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : Effect
{
    public int duration;

    public Stun(Skill skill) : base(skill)
    {
    }

    public override void Spell()
    {
        skill.Spell();
        Debug.Log("附加強力震撼效果");
    }

    public override void Show()
    {
        skill.Show();
        Debug.Log("暈眩 "+ duration+" 秒");
    }
}
