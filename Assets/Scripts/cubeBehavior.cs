using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBehavior : MonoBehaviour
{
    public GameObject tower;
    Animator rumbleAlertAAnim;
    public bool towerActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.Find("Tower");
        rumbleAlertAAnim = GameObject.Find("Rumble Alert A").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(towerActivated)
        {
            tower.SetActive(true);
        }
        Debug.Log(towerActivated);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Trigger Zone A")
        {
            Debug.Log("*RUMBLE*");
            towerActivated = true;
            rumbleAlertAAnim.SetTrigger("modeSwapped");
        }
    }
}
