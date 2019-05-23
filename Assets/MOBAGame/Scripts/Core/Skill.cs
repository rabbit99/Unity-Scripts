using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public List<Effect> all_Effect = new List<Effect>();

    public virtual void Spell() {
        Debug.Log("======詠唱======");
    }
 
    public virtual void Show() {
        Debug.Log("====放出招式====");
    }

}
