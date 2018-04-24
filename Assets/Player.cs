using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool debugAnimations = false;

    public float movementSpeed = 7.0f;
    public float turningSpeed = 800.0f;
    public float gravity = 16.0f;
    public float jumpForce = 8.0f;
    public float verticalVelocity;
    public float downwardsFallMultiplier;
    private int currentAnimationParam = 0;
    public bool isMoving;
    public int score;


    private Vector3 movement;

    //public Tower tower;
    public GameObject chicken;

    public CharacterController controller;
	public Animator animControl;
    public MeshRenderer renderer;
    //public CharacterSelection cs;

    public string _pickUpLayer = "PickUp";
    public string _playerLayer = "Player";

    private float _pressTime = 0;
    private float _animTimer;
    private float _throwTimer = 0;
    private bool _readyToThrow = true;
    private bool _throwFar = false;
    private GameObject _enemy;
    private Vector3 _throwDirection;
    private bool _animFinished = false;

    public string horizontal = "Horizontal_P1";
    public string vertical = "Vertical_P1";
    public string fire1Button = "Fire1_P1";
    public string fire2Button = "Fire2_P1";
    public string fire3Button = "Fire3_P1";
    public string fire4Button = "Fire4_P1";
    //public string jumpButton = "Jump_P1";

    public GameObject mainCamera;

    public bool isHit = false;
    public bool isIncapacitated = false;
    public GameObject hitEffect;
    public GameObject chargeEffect;

    private bool _isWindingUp = false;
    private bool _isThrowing = false;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        renderer = GetComponent<MeshRenderer>();
        //tower = GetComponent<Tower>();
		//animControl = gameObject.GetComponentInChildren<Animator>();
        mainCamera = GameObject.Find("Main Camera");
        //hitEffect = transform.Find("Hit").gameObject;
        chargeEffect = transform.Find("ChargeShot").gameObject;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");                       // Horizontal Input
        float moveVertical = Input.GetAxis("Vertical");                           // Vertical Input
        //bool jump = Input.GetButtonDown(jumpButton);                            // Jump Input

		if (moveHorizontal == 0 && moveVertical == 0) {                          // If player not moving
            //PlayAnimation (0);                                                   // Play's Idle animation
            isMoving = false;
		}
		else 
		{
			//PlayAnimation(1);                                                   // Plays Run animation
            isMoving = true;
		}

        Vector3 verticalMovement = new Vector3(0, verticalVelocity, 0);         // Get vertical movement in Vector3 form

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);             // Get the movement Vector3
        movement = Vector3.ClampMagnitude(movement, 1.0f);                      // Eliminate faster diagonal movement

        //Only Update the player's rotation if he's moving. This way we keep the rotation.
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Rotate();
        }
        controller.Move(movement * movementSpeed * Time.deltaTime);             // Move player on X and Z
        controller.Move(verticalMovement * Time.deltaTime);                     // Move player on Y
    }

    

    void Rotate()
    {
        float step = turningSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement), step);
    }

    
}