using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_play_jump : MonoBehaviour
{
    private Rigidbody CharacterRb;


    public float fall_speed = 10;
    public float jump_speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        CharacterRb = GetComponent<Rigidbody>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CharacterRb.AddForce(Vector3.up * jump_speed, ForceMode.Impulse);
        }

        if(this.transform.position.y > 210)
        {
            gravity_focus();
        }
        else if(this.transform.position.y < 208)
        {
            Jump_up(.001f);
        }
    }

    void gravity_focus()
    {
        if (this.transform.position.y > 280)
        {
            Jump_down(.8f);
        }
        else if (this.transform.position.y > 260)
        {
            Jump_down(.4f);
        }
        else if (this.transform.position.y > 240)
        {
            Jump_down(.1f);
        }
        else if (this.transform.position.y > 220)
        {
            Jump_down(.02f);
        }
        else if (this.transform.position.y > 210)
        {
            Jump_down(.01f);
        }
    }

    void Jump_down(float slower)
    {
        CharacterRb.AddForce(Physics.gravity * (fall_speed * slower), ForceMode.Acceleration);
    }
    void Jump_up(float slower)
    {
        CharacterRb.AddForce(Physics.gravity * -(fall_speed * slower), ForceMode.Acceleration);
    }
    
}
