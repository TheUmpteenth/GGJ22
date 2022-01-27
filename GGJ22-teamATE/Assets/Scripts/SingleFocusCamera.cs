using System;
using System.Collections.Generic;
using UnityEngine;

public class SingleFocusCamera : MonoBehaviour
{
    public Transform m_target;

    public float m_fixedDist = -10f;
    public float m_fixedHeight = -5f;
    public bool m_heightIsFixed = true;


    private void Update()
    {
        Vector3 pos = m_target.position;

        pos.z = m_fixedDist;
        if (m_heightIsFixed)
        {
            pos.y = m_fixedHeight;
        }

        transform.position = pos;
    }
}