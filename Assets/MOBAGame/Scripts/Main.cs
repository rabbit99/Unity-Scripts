using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private Skill m_skill;

    // Start is called before the first frame update
    void Start()
    {
        EquipmentSkill();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipmentSkill()
    {
        m_skill = new FireBall();
    }

    public void UnEquipmentSkill()
    {
        m_skill = null;
    }

    public void EquipmentEffectDamages(bool value)
    {
        if(value)
        {
            m_skill = new Damages(m_skill);
        }
        else
        {
            Effect temp = (Effect)m_skill;
            m_skill = temp.skill;
        }
    }

    public void EquipmentEffectStun(bool value)
    {
        if (value)
        {
            m_skill = new Stun(m_skill);
        }
        else
        {
            Effect temp = (Effect)m_skill;
            m_skill = temp.skill;
        }
    }

    public void EquipmentEffectExplosion(bool value)
    {
        if (value)
        {
            m_skill = new Explosion(m_skill);
        }
        else
        {
            Effect temp = (Effect)m_skill;
            m_skill = temp.skill;
        }
    }

    public void UseSkill()
    {
        Debug.Log("玩家使用招式");
        if (m_skill != null)
        {
            m_skill.Spell();
            m_skill.Show();
        }
    }
}
