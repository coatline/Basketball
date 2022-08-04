using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    bool hasBall;
    //private float shotTime = 4;
    float amount = .035f;
    bool shot;
    public Rigidbody PlayerRb;
    Rigidbody myRb;
    Transform myPos;
    float push;
    public GameObject Player;
    public Transform playerPos;
    public Transform Goal;
    public Image bar;
    static public bool threePointer;
    bool overFlow;

    //the variable amount should be the variable to change for the shot time

    void Awake()
    {
        myPos = GetComponent<Transform>();
        myRb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {

    }        

    // fixed or not?? 
    void Update()
    {

        if (transform.parent != null)
        {
            hasBall = true;
        }
        else
        {
            hasBall = false;
        }

        if ((Input.GetButton("Fire1") || Input.GetButton("Jump")) && hasBall)
        {
            //percentage += amount;
            //Debug.Log(percentage);

            //if (percentage >= shotTime)
            //{

            //}
            //if (percentage < 0)
            //{
            //    has = false;
            //if (percentage >= 2)
            //{

            //}
            //move the player upward
            //rb.AddForce(0, amount * 40, 0);
            //}

            push += amount + amount / 2;
            bar.fillAmount += amount / 2;
            if (bar.fillAmount >= 1)
                overFlow = true;

            PlayerRb.useGravity = false;
            PlayerRb.AddForce(0, 4, 0);

            myRb.useGravity = false;
            myRb.velocity = Vector3.zero;
            myRb.transform.Translate(0, 0.5f * Time.deltaTime, 0);

            //update the z stuff
            //if ((Goal.position.x - playerPos.position.x) > 9.65 || (Goal.position.z - playerPos.position.z) > 9.65 || (Goal.position.z - playerPos.position.z) < 9.65)
            if ((Goal.position.x - playerPos.position.x) > 9.65)
            {
                threePointer = true;
            }
            else
            {
                    threePointer = false;
            }
        };

        if (((Input.GetButtonUp("Fire1") || Input.GetButtonUp("Jump")) && hasBall) || hasBall && overFlow)
        {
            transform.parent = null;

            myRb.constraints = RigidbodyConstraints.FreezeRotation;

            //Debug.Log(percentage);
            hasBall = false;
            shot = true;
            myRb.useGravity = true;

            PlayerRb.useGravity = true;

            //push the ball according to the player's rotation
            myRb.AddForce(new Vector3(Player.transform.forward.x * push, Player.transform.up.y * push * 2, Player.transform.forward.z * push) * 1000);

            push = 0f;
            ScoreManger.Instance.ShotsTaken++;
            bar.fillAmount = 0;
            overFlow = false;
        }

        if (shot)
        {
            //de-parent
            //float probability = Random.Range(percentage, shotTime);
            //shot = true;
            //has = false;
            ////Debug.Log(probability);
            //if (probability >= shotTime - 0.05f)
            //{
            //    shot = true;
            //    has = false;
            //    percentage = 0;
            //    //Debug.Log("yay");
            //}
        }
    }

    //bounce
    public float bounceHeight;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Court") && !hasBall)
        {
            float x = myRb.velocity.y * 1.6f;
            myRb.velocity = new Vector3(0, x, 0);
        }
        else if (collision.gameObject.CompareTag("Court") && hasBall)
        {
            myRb.velocity = new Vector3(0, -6.5f, 0);
        }
        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Court") && hasBall && myRb.velocity.y == 0)
        {
                myRb.velocity = new Vector3(0, -6.5f, 0);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("MoveTheBall"))
        {
            hasBall = true;
            shot = false;

            //SetParent for the ball        
            myPos.transform.SetParent(playerPos, true);

        }
    }
}
