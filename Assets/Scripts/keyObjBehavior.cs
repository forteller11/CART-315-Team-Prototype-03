using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyObjBehavior : MonoBehaviour
{
    public GameObject ceiling;

    // Start is called before the first frame update
    void Start()
    {
        ceiling = GameObject.Find("Dungeon Ceiling Door");
        ceiling.SetActive(true);
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
        }
    }
}
