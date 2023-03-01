using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_pick : MonoBehaviour
{

    public float speed = 4;

    private int[] spawn_set= {
        223, 246, 270
        };

    // Start is called before the first frame update
    void Start()
    {
        //600 = x
        //210.285 = y
        //-600 = z

        //this.transform.position = new Vector3(700, Random.Range(215, 285), -600);
        this.transform.SetPositionAndRotation(new Vector3(700, spawn_set[Random.Range(0,3)], -600), new Quaternion(0, 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Move_Left();
        out_of_bounds();
    }

    void Move_Left()
    {
        this.transform.Translate(-speed * Time.deltaTime, 0 ,0);
    }

    private void out_of_bounds()
    {
        if (this.transform.position.x < 400)
        {
            destory_this();
        }
    }

    public void destory_this()
    {
        
            Destroy(this.gameObject);
        
    }
}
