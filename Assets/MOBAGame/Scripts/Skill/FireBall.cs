using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Skill
{
    public override void Spell()
    {
        base.Spell();
        Debug.Log("火球術");
    }

    public override void Show()
    {
        base.Show();
        Debug.Log("丟出一顆火球");
    }
}
