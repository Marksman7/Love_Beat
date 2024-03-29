using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_01_Three_way : MonoBehaviour
{
    private float[] move_set = {
        223, 246, 270
        };


    public GameObject[] animations;

    private bool inaction_animation = false;

    private bool down_active = false;

    public float speed = 6;

    public bool in_motion = false;

    public float stay_on_target;

    // Start is called before the first frame update
    void Start()
    {
        stay_on_target = this.gameObject.transform.position.y;
        set_animations();
    }

    void set_animations()
    {
        animations[0].SetActive(true);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        inaction_animation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (in_motion == true)
        {
            find_target_move();
            stop_moving();
            //Debug.Log("check");
        }
        else if(down_active == true)
        {
            //Debug.Log("check");
            check_move_down();
        }
        else
        {
            move_actions();
        }
    }

    private void move_actions()
    {
        if (Input.GetKeyDown(KeyCode.Q) && this.gameObject.transform.position.y < move_set[2])
        {
            stay_on_target = move_set[2];
            inaction_animation = true;
            animations[0].SetActive(false);
            animations[3].SetActive(true);
            Invoke("set_animations", .5f);
            in_motion = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && this.gameObject.transform.position.y < move_set[1])
        {
            stay_on_target = move_set[1];
            inaction_animation = true;
            animations[0].SetActive(false);
            animations[2].SetActive(true);
            Invoke("set_animations", .5f);
            in_motion = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            stay_on_target = move_set[0];
            inaction_animation = true;
            animations[0].SetActive(false);
            animations[1].SetActive(true);
            Invoke("set_animations", .5f);
            //in_motion = true;
        }
    }

    private void find_target_move()
    {
        if ((stay_on_target + 1) > this.gameObject.transform.position.y && stay_on_target != move_set[0])
        {
            move_up();
        }
    }
    
    private void move_up()
    {
        this.transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void move_down()
    {
        this.transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    private void check_move_down()
    {
        if(move_set[0] < this.gameObject.transform.position.y)
        {
            move_down();
        }
        else
        {
            down_active = false;
        }
    }

    private void stop_moving()
    {
        if (move_set[0] == stay_on_target)
        {
            if (move_set[0] < this.gameObject.transform.position.y)
            {

                in_motion = false;
                //down_active = true;
            }
        }
        else if (move_set[1] == stay_on_target)
        {
            if ((move_set[1] < this.gameObject.transform.position.y))
            {
                in_motion = false;
                down_active = true;
            }
        }
        else if (move_set[2] == stay_on_target)
        {
            if (move_set[2] < this.gameObject.transform.position.y)
            {

                in_motion = false;
                down_active = true;
            }
        }
    }
}
