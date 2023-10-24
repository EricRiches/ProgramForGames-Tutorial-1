using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public static Player player;

    [SerializeField] private float speed;
    private Vector3 _moveDirection;

    public int MaxAmmo = 120;
    public int AmmoBag = 60;
    private int AmmoBagStore = 0;
    public int AmmoLoaded = 30;
    public int MagSize = 30;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    bool isGrounded;
    bool isCrouching = false;

    Rigidbody rb;
    public GameObject projectile;
    public Transform projectilePos;

    
    public TMP_Text AmmoLoadedText;
    public TMP_Text AmmoBagText;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InputManager.Init(this);
        InputManager.SetGameControls();
    }

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDirection;

        //check if player is on the ground
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y);
    }

    public void setIsJumping()
    {
        //if player is on the ground then make the player jump
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        
    }
    public void setIsCrouching()
    {
        //if player is not already crouching scale down the player and set isCrouching to true
        if (isCrouching == false)
        {
            transform.localScale -= new Vector3(0, 1, 0); 
            isCrouching = true;
        }
        //if player is crouching then scale up player and set isCrouching to false
        else
        {
            transform.localScale += new Vector3(0, 1, 0); 
            isCrouching = false;
        }
    }

    public void SetMovementDirection(Vector3 currentDirection)
    {
        _moveDirection = currentDirection;
    }
    
    public void shoot()
    {

        if (AmmoLoaded > 0)
        {
            Rigidbody rbBullet = Instantiate(projectile, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
            rbBullet.AddForce(Vector3.forward * 32f, ForceMode.Impulse);

            AmmoLoaded = AmmoLoaded - 1;
            AmmoLoadedText.text = "Ammo: " + AmmoLoaded + "/" + MagSize; 
        }
    }

    public void Reload()
    {
        if (AmmoLoaded < MagSize && AmmoBag > 0)
        {
            AmmoBagStore = AmmoBag;
            AmmoBag = AmmoBag - (MagSize - AmmoLoaded);
            if (AmmoBag < 0)
            {
                AmmoBag = 0;
            }
            if (AmmoBagStore >= MagSize)
            {
                AmmoLoaded = MagSize;

            } 
            else if(AmmoBagStore + AmmoLoaded >= MagSize)
            {
                AmmoLoaded = MagSize;
            }
            else
            {
                AmmoLoaded = AmmoLoaded + AmmoBagStore;
            }

            

            AmmoLoadedText.text = "Ammo: " + AmmoLoaded + "/" + MagSize;
            AmmoBagText.text = AmmoBag + " / " + MaxAmmo;
        }
    }
    
    public void UpdateAmmo(int ammoAmount)
    {
        if (AmmoBag + ammoAmount > MaxAmmo)
        {
            AmmoBag = MaxAmmo;
        }
        else
        {
            AmmoBag = AmmoBag + ammoAmount;
        }
        AmmoBagText.text = AmmoBag + " / " + MaxAmmo;
    }


    /*public void UpdateScore()
    {
        Score = Score + 1;
        scoreText.text = "Score: " + Score;
        Debug.Log("yes");
    }*/

}
