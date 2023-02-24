using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Points : MonoBehaviour
{

    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            points = points + 1;
            other.GetComponent<Collectable_pick>().destory_this();
        }
    }
}
