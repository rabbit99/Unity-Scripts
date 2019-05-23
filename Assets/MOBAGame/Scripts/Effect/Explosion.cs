using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Effect
{
    public int radius = 1;

    public Explosion(Skill skill) : base(skill)
    {
    }

    public override void Spell()
    {
        skill.Spell();
        Debug.Log("附加增強爆炸效果");
    }

    public override void Show()
    {
        skill.Show();
        Debug.Log("爆炸出 半徑 "+radius+" 公尺的範圍");
    }
}
