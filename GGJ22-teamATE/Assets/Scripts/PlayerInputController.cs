using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public HumanoidMover m_mover;
    private void Update()
    {
        m_mover.m_horizInput = Input.GetAxis("Horizontal");
        m_mover.m_vertInput = Input.GetAxis("Vertical");
    }
}