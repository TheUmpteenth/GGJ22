
using UnityEngine;

public class HumanoidMover : MonoBehaviour
{
    public CharacterController m_characterController;
    public float m_speed = 3;
    public float m_jumpHeight = 3;
    
    public Animator m_animator;
    public bool m_facingLeft;
    
    // gravity
    public float m_gravity = 9.87f;
    private float m_verticalSpeed;

    private float m_actualSpeed;
    public float m_acceleration = 10f;

    public float m_horizInput;
    public float m_vertInput;
    public float m_jump;

    private float m_zPos;
    
    
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            m_animator.SetTrigger("walk");
        }
        else { m_animator.SetTrigger("stopwalk"); }





        Move(m_horizInput, m_vertInput);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_zPos = transform.position.z;
    }
    
    public static float CalculateJumpForce(float gravityStrength, float jumpHeight)
    {
        //h = v^2/2g
        //2gh = v^2
        //sqrt(2gh) = v
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }

    public void Push(float mass)
    {
        m_actualSpeed = 0;
    }

    private void Move(float horizontalMove, float verticalMove)
    {
        if (m_characterController.isGrounded)
        {
            if (m_jump > 0)
            {
                m_verticalSpeed += CalculateJumpForce(m_gravity, m_jumpHeight);
                m_animator.SetTrigger("jump");
            }
            else
            {
                m_verticalSpeed = 0;
            }
        }
        else
        {
            m_verticalSpeed -= m_gravity * Time.deltaTime;
        }
        Vector3 gravityMove = new Vector3(0, m_verticalSpeed, 0);
        
        if (m_actualSpeed< m_speed)
        {
            m_actualSpeed += m_acceleration * Time.deltaTime * Mathf.Abs(horizontalMove);
            if (m_actualSpeed > m_speed)
                m_actualSpeed = m_speed;
        }
        
        Vector3 move = /*transform.right * verticalMove +*/ transform.forward * horizontalMove;
        m_characterController.Move(m_actualSpeed * Time.deltaTime * move * (m_facingLeft ? -1f : 1f) + gravityMove * Time.deltaTime);
        
        m_animator.SetBool("moving", move.sqrMagnitude > 0);
        //m_animator.SetBool("Moving", move.sqrMagnitude > 0);
        //m_animator.SetTrigger("walk");


        if ((horizontalMove > 0 && m_facingLeft) || (horizontalMove < 0 && !m_facingLeft))
        {
            m_facingLeft = !m_facingLeft;
            Vector3 angles = transform.localRotation.eulerAngles;
            angles.y += 180;
            if (angles.y > 360)
            {
                angles.y -= 360;
            }
            transform.localRotation = Quaternion.Euler(angles);

            //m_animator.SetTrigger("walk");
        }
        


    }
}