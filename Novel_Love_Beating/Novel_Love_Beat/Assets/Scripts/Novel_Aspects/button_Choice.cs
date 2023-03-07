using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_Choice : MonoBehaviour
{
    private GameObject get_moduel;

    // Start is called before the first frame update
    void Start()
    {
        get_moduel = GameObject.FindGameObjectWithTag("active_moduel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void get_new_moduel(float wait)
    {
        Invoke("wait_here", wait);
    }

    private void wait_here()
    {
        get_moduel = GameObject.FindGameObjectWithTag("active_moduel");
    }

    public void Button00_click()
    {
        get_moduel.GetComponent<Choice>().Button00_click();
    }

    public void Button01_click()
    {
        get_moduel.GetComponent<Choice>().Button01_click();
    }

    public void Button02_click()
    {
        get_moduel.GetComponent<Choice>().Button02_click();
    }

    public void Button03_click()
    {
        get_moduel.GetComponent<Choice>().Button03_click();

    }

    public void Button04_click()
    {
        get_moduel.GetComponent<Choice>().Button04_click();
    }
}
