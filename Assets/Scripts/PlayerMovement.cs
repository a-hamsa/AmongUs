using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // components
    [SerializeField] bool hasControl;
    public static PlayerMovement localPlayer;

    [SerializeField] Rigidbody myRB;
    [SerializeField] Animator myAnim;
    [SerializeField] Transform myAvatar;
    

    CapsuleCollider cpsColider;

    // player movement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    // player color
    static Color myColor;
    SpriteRenderer myAvatarSprite;


    // role
    [SerializeField] bool isImposter;
    [SerializeField] InputAction KILL;

    PlayerMovement target;
    [SerializeField] Collider myCollider;

    bool IsDead;

    private void Awake()
    {
        KILL.performed += KillTarget;
    }

    //static Sprite myAccsSprite;
    //SpriteRenderer myAccsHolder;

    private void OnEnable()
    {
        WASD.Enable();
        KILL.Enable();
    }
    private void OnDisable()
    {
        WASD.Disable();
        KILL.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (hasControl)
        {
            localPlayer = this;
        }

        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        myAvatar = transform.GetChild(0);
        myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();


        // myAccsHolder = transform.GetChild(1).GetComponent<SpriteRenderer>();



        if (myColor == Color.clear)
            myColor = Color.white;
        if (!hasControl)
            return;
        myAvatarSprite.color = myColor;


        //if (myAccsSprite != null)
        //    myAccsHolder.sprite = myAccsSprite;


    }

    // Update is called once per frame
    void Update()
    {
        if (!hasControl)
            return;

        movementInput = WASD.ReadValue<Vector2>();
        if (movementInput.x != 0)
        {
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }

        myAnim.SetFloat("Speed", movementInput.magnitude);
    }

    private void FixedUpdate()
    {
        myRB.velocity = movementInput * movementSpeed;
    }

    public void SetColor(Color newColor)
    {
        myColor = newColor;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = newColor;
        }
    }


    public void SetRole(bool newRole)
    {
        isImposter = newRole;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement tempTarget = other.GetComponent<PlayerMovement>();
            if (isImposter)
            {
                if (tempTarget.isImposter)
                    return;
                else
                {
                    target = tempTarget;
                    // Debug.Log(target.name);
                }
            }
        }
    }

    void KillTarget(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Performed)
        {
            if (target == null)
                return;
            else
            {
                if (target.IsDead)
                    return;
                transform.position = target.transform.position;
                target.Die();
                target = null;
            }
        }
    }


=======
    //public void SetAccs(Sprite newAccs)
    //{
    //    myAccsSprite = newAccs;
    //    myAccsHolder.sprite = myAccsSprite;
//
    //}

    public void Die()
    {
        IsDead = true;

        myAnim.SetBool("IsDead", IsDead);
        myCollider.enabled = false;

        cpsColider.isTrigger = false;
        
    }
}
