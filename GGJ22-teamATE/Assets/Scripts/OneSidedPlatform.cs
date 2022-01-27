using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSidedPlatform : MonoBehaviour
{
    public Collider m_trigger;
    public Collider m_collider;
    public void Activate(Collider other)
    {
        Physics.IgnoreCollision(other, m_collider, false);
    }

    public void Deactivate(Collider other)
    {
        Physics.IgnoreCollision(other, m_collider, true);
    }
}
