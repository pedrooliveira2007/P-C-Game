using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    //mask where the mouse can access the world position
    [SerializeField]
    private LayerMask moveMask;


    [SerializeField]
    private Camera cam;
    //  [SerializeField]
    //private Animator? anim;
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private Vector3 _velocity;

    internal bool attackMove = false;
    internal bool attacking = false;


    void Start()
    {
        cam = Camera.main;
        //   anim = GetComponentInChildren<Animator>();
        _controller = GetComponent<CharacterController>();
        _velocity = Vector3.zero;
        //  anim?.SetBool("Idle", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateVelocity();
        UpdatePosition();
    }
    private void Update()
    {
        UpdateAttack();
    }


    private void UpdateVelocity()
    {
        if (Input.GetMouseButton(0))
        {
            //  if (anim?.GetBool("isDead") == false)
            if (!attacking)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000, moveMask))
                {
                    transform.LookAt(new Vector3(hit.point.x, 0, hit.point.z));
                    transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                    _velocity.z = 20f;

                    //  anim?.SetBool("isWalking", true);
                    //  anim?.SetBool("Idle", false);
                }
            }

            else
            {
                _velocity.z = 0f;
                //  anim?.SetBool("Idle", true);
                //  anim?.SetBool("isWalking", false);
            }
        }

        else
        {
            _velocity.z = 0f;
            //  anim?.SetBool("Idle", true);
            //  anim?.SetBool("isWalking", false);
        }


    }

    private void UpdatePosition()
    {
        Vector3 motion = _velocity * Time.deltaTime;
        _controller.Move(transform.TransformVector(motion));
    }


    private bool MousePoint()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, moveMask))
        {
            transform.LookAt(new Vector3(hit.point.x, 0, hit.point.z));
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            return true;
        }
        return false;
    }


    private void UpdateAttack()
    {/*
        if (!attacking)
        {
            // Horizontal Breaker.
            if (Input.GetButtonDown("1st Ability"))
            {

            }

            // Duelist Advance.
            else if (Input.GetButtonDown("2nd Ability"))
            {
                if (MousePoint())
                {
                    attacking = true;
                    //   anim?.SetInteger("Ability", 2);
                }

            }

            // Guardian's Will.
            else if (Input.GetButtonDown("3rd Ability"))
            {

                if (MousePoint())
                {
                    attacking = true;
                    //  anim?.SetInteger("Ability", 3);
                }

            }

            // Healing Faith.
            else if (Input.GetButtonDown("4th Ability"))
            {
                if (MousePoint())
                {
                    attacking = true;
                    //  anim?.SetInteger("Ability", 4);
                }

            }

            // Leapard's Dash.
            else if (Input.GetButtonDown("5th Ability"))
            {

                if (MousePoint())
                {
                    attacking = true;
                    //   anim?.SetInteger("Ability", 5);
                }

            }

            // Sky's Wrath.
            else if (Input.GetButtonDown("6th Ability"))
            {

                if (MousePoint())
                {
                    attacking = true;
                    //   anim?.SetInteger("Ability", 6);
                }

            }

        }

        else
        {
            //   anim?.SetBool("isWalking", false);
            //   anim?.SetBool("Idle", false);
        }
        */
    }


    internal void Heal()
    {
        //  UI.AdjustHP(stat.baseHeal);
    }
}