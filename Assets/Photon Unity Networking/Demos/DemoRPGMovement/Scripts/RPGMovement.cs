using UnityEngine;
using System.Collections;
using InControl;

[RequireComponent( typeof( CharacterController ) )]
public class RPGMovement : MonoBehaviour
{
    public float ForwardSpeed;
    public float BackwardSpeed;
    public float StrafeSpeed;
    public float RotateSpeed;

    CharacterController m_CharacterController;
    Vector3 m_LastPosition;
    Animator m_Animator;
    PhotonView m_PhotonView;
    PhotonTransformView m_TransformView;

    float m_AnimatorSpeed;
    Vector3 m_CurrentMovement;
    float m_CurrentTurnSpeed;

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        m_PhotonView = GetComponent<PhotonView>();
        m_TransformView = GetComponent<PhotonTransformView>();
    }

    void Update()
    {
        if( m_PhotonView.isMine == true )
        {
            ResetSpeedValues();

            UpdateRotateMovement();

            UpdateForwardMovement();
            UpdateBackwardMovement();
            UpdateStrafeMovement();

            MoveCharacterController();
            ApplyGravityToCharacterController();

            ApplySynchronizedValues();
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        Vector3 movementVector = transform.position - m_LastPosition;

        float speed = Vector3.Dot( movementVector.normalized, transform.forward );
        float direction = Vector3.Dot( movementVector.normalized, transform.right );

        if( Mathf.Abs( speed ) < 0.2f )
        {
            speed = 0f;
        }

        if( speed > 0.6f )
        {
            speed = 1f;
            direction = 0f;
        }

        if( speed >= 0f )
        {
            if( Mathf.Abs( direction ) > 0.7f )
            {
                speed = 1f;
            }
        }

        m_AnimatorSpeed = Mathf.MoveTowards( m_AnimatorSpeed, speed, Time.deltaTime * 5f );

        m_Animator.SetFloat( "Speed", m_AnimatorSpeed );
        m_Animator.SetFloat( "Direction", direction );

        m_LastPosition = transform.position;


    }
    void ResetSpeedValues()
    {
        m_CurrentMovement = Vector3.zero;
        m_CurrentTurnSpeed = 0;
    }

    void ApplySynchronizedValues()
    {
        m_TransformView.SetSynchronizedValues( m_CurrentMovement, m_CurrentTurnSpeed );
    }

    void ApplyGravityToCharacterController()
    {
        m_CharacterController.Move( transform.up * Time.deltaTime * -9.81f );
    }

    void MoveCharacterController()
    {
        m_CharacterController.Move( m_CurrentMovement * Time.deltaTime );
    }

    void UpdateForwardMovement()
    {
        if( Input.GetKey( KeyCode.W ) || Input.GetAxisRaw("Vertical") > 0.1f )
        {
            m_CurrentMovement = transform.forward * ForwardSpeed;
        }
    }

    void UpdateBackwardMovement()
    {
        if( Input.GetKey( KeyCode.S ) || Input.GetAxisRaw("Vertical") < -0.1f )
        {
            m_CurrentMovement = -transform.forward * BackwardSpeed;
        }
    }

    void UpdateStrafeMovement()
    {
        if( Input.GetKey( KeyCode.Q ) == true )
        {
            m_CurrentMovement = -transform.right * StrafeSpeed;
        }

        if( Input.GetKey( KeyCode.E ) == true )
        {
            m_CurrentMovement = transform.right * StrafeSpeed;
        }
    }

    void UpdateRotateMovement()
    {
        var inputDevice = InputManager.ActiveDevice;
        if (inputDevice.RightStickX)
        {
            transform.Rotate(0, inputDevice.RightStickX * RotateSpeed, 0);
            // transform.Rotate(Vector3.right, 500.0f * Time.deltaTime * inputDevice.LeftStickY, Space.World);
        }
        //if( Input.GetKey( KeyCode.A ) || Input.GetAxisRaw("Horizontal") < -0.1f )
        //if(inputDevice.RightStickX < -0.1f)
        //{
        //    m_CurrentTurnSpeed = -RotateSpeed;
        //    transform.Rotate(0.0f, -RotateSpeed * Time.deltaTime, 0.0f);
        //}

        ////if( Input.GetKey( KeyCode.D ) || Input.GetAxisRaw("Horizontal") > 0.1f )
        //if(inputDevice.RightStickX > 0.1f)
        //{
        //    m_CurrentTurnSpeed = RotateSpeed;
        //    transform.Rotate(0.0f, RotateSpeed * Time.deltaTime, 0.0f);
        //}
    }
}
