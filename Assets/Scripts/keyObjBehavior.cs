using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyObjBehavior : MonoBehaviour
{
    public GameObject ceiling;
    Animator rumbleAlertBAnim;

    // Start is called before the first frame update
    void Start()
    {
        ceiling = GameObject.Find("Dungeon Ceiling Door");
        ceiling.SetActive(true);
        rumbleAlertBAnim = GameObject.Find("Rumble Alert B").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Trigger Zone B")
        {
            Debug.Log("*RUMBLE 2*");
            ceiling.SetActive(false);
            rumbleAlertBAnim.SetTrigger("modeSwapped");
        }
    }
}
