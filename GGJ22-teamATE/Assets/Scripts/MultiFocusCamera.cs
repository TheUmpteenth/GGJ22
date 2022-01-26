using System;
using System.Collections.Generic;
using UnityEngine;

public class MultiFocusCamera : MonoBehaviour
{
    public List<Transform> m_targets;

    public Camera m_camera;

    public float m_baseDist = -30;

    private void Awake()
    {
        Debug.Assert(m_targets.Count == 2, "Camera Controller can only handle 2 objects");
    }

    private void Update()
    {
        float dist = Mathf.Abs((m_targets[0].position - m_targets[1].position).magnitude);

        Vector3 pos = m_targets[0].position - ((m_targets[0].position - m_targets[1].position) * 0.5f);

        pos.z = m_baseDist - dist;

        if (m_camera != null && m_camera.orthographic)
        {
            m_camera.orthographicSize = dist;
        }

        transform.position = pos;
    }
}