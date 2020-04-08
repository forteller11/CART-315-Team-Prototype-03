using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBehavior : MonoBehaviour
{
    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.Find("Tower");
        tower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Trigger Zone A")
        {
            Debug.Log("*RUMBLE*");
            tower.SetActive(true);
        }
    }
}
