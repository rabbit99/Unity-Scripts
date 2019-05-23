using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : Skill
{
    public Skill skill;
    

    public Effect(Skill _skill)
    {
        this.skill = _skill;

        if (_skill is Effect)
        {
            Skill first_temp = Check(_skill);
            first_temp.all_Effect.Add(this);
        }
        else
        {
            _skill.all_Effect.Add(this);
        }

    }

    public static Skill Check(Skill skill)
    {
        Skill skill_temp = null;
        Effect temp = (Effect)skill;

        if (temp.skill is Effect)
        {
            skill_temp = Check(temp.skill);
        }else
        {
            skill_temp = temp.skill;
        }

        return skill_temp;
    }

    public static Skill UnDoEffect<T>(Skill m_skill)
    {
        if (!(m_skill is Effect))
        {
            Debug.Log("UnDoEffect  失敗");
            return m_skill;
        }

        Skill temp = Effect.Check(m_skill);
        Debug.Log("開始UnDoEffect");
        Debug.Log("temp.all_Effect.Count = " + temp.all_Effect.Count);

        if (temp.all_Effect.Count == 1)
        {
            m_skill = temp.all_Effect[0].skill;
            temp.all_Effect.RemoveAt(0);
            return m_skill;
        }

        for (int i = 0; i < temp.all_Effect.Count; i++)
        {
            if (temp.all_Effect[i] is T)
            {
                Debug.Log("temp.all_Effect[i] is T , i = " + i);
                if (i == 0)
                {
                    temp.all_Effect[i + 1].skill = temp.all_Effect[i].skill;
                }
                else if (i == temp.all_Effect.Count - 1)
                {
                    m_skill = temp.all_Effect[i].skill;
                }
                else
                {
                    temp.all_Effect[i + 1].skill = temp.all_Effect[i - 1];
                }

                temp.all_Effect.RemoveAt(i);
                break;
            }
        }
        Debug.Log("UnDoEffect end");
        return m_skill;
    }

}
