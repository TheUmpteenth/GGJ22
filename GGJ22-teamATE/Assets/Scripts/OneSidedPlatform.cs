using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSidedPlatform : MonoBehaviour
{
    public Collider m_trigger;
    public Collider m_collider;
    public bool m_impassible;
    
    public void EnablePassThrough(Collider other)
    {
        if (!m_impassible)
        {
            Physics.IgnoreCollision(other, m_collider, false);
        }
    }

    public void DisablePassThrough(Collider other)
    {
        if (!m_impassible)
        {
            Physics.IgnoreCollision(other, m_collider, true);
        }
    }

    public void MakeImpassible(bool impassible = true)
    {
        m_impassible = impassible;
    }
}
