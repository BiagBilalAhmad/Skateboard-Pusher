using Spine.Unity;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;
    private JointMotor2D fmotor;
    private JointMotor2D bmotor;
    public float accelaration;
    public float brake;

    public bool isGrounded;
    public LayerMask mask;

    public Transform groundCheck;
    public float groundcheckRadius;
    bool playingGame;
    Vector3 startPosition;
    public Transform body;
    private void Start()
    {
        startPosition = transform.position;
        fmotor = frontWheel.motor;
        bmotor = backWheel.motor;
        playingGame = true;
    }
    public SkeletonAnimation SkeletonAnimation;

    public void FixedUpdate()
    {
        if (playingGame)
        {
            float horizontal = Input.GetAxis("Vertical");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckRadius, mask);

            fmotor.motorSpeed = -accelaration * -horizontal;
            bmotor.motorSpeed = -accelaration * -horizontal;
            frontWheel.motor = fmotor;
            backWheel.motor = bmotor;
            if (!isGrounded)
            {
                if (transform.localScale.x >= 1 && Input.GetKeyDown(KeyCode.A))
                {
                    transform.localScale = new Vector2(-1, 1);
                }
                else if (transform.localScale.y <= 1 && Input.GetKeyDown(KeyCode.D))
                {
                    transform.localScale = new Vector2(1, 1);
                }
            }
        }
        
       /* if (Input.GetKey(KeyCode.S))
        {
            if (transform.localScale.x >= 1)
            {
                fmotor.motorSpeed = -accelaration;
                bmotor.motorSpeed = -accelaration;
                frontWheel.motor = fmotor;
                backWheel.motor = bmotor;
            }
            else
            {
                fmotor.motorSpeed = accelaration;
                bmotor.motorSpeed = accelaration;
                frontWheel.motor = fmotor;
                backWheel.motor = bmotor;
            }
            
        }*/
        
        
        

    }
    public void restartGame()
    {
        frontWheel.enabled = false;
        backWheel.enabled = false;
        transform.position = startPosition;
        body.rotation = gameOver.startPosition;
        Time.timeScale = 1;
        frontWheel.enabled = true;
        backWheel.enabled = true;
    }
}
