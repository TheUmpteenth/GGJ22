using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Collider m_girl;
    public Collider m_boy;
    public HumanoidMover m_human;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(m_girl, m_boy);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody && !collision.rigidbody.isKinematic)
        {
            m_human.Push(collision.rigidbody.mass);
        }
    }
}
