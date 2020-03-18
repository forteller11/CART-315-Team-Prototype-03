using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class bgScroll : MonoBehaviour
{
    public Vector2 speed = new Vector2(2, 2);
    public Vector2 direction = new Vector2(-1, 0);
    public bool isLinkedToCamera = false;
    public bool isLooping = false;

    private List<SpriteRenderer> backgroundPart;

    private GameObject player;
    playerMovement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        if(isLooping)
        {
            backgroundPart = new List<SpriteRenderer>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer r = child.GetComponent<SpriteRenderer>();
                if (r != null)
                {
                    backgroundPart.Add(r);
                }
            }

            backgroundPart = backgroundPart.OrderBy(t => t.transform.position.x).ToList();
        }

        player = GameObject.Find("PlayerSprite");
        playerMovementScript = player.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerMovementScript.playerIsMoving == true)
        {
            //Debug.Log(playerMovementScript.x_movement);
            //direction.x = playerMovementScript.x_movement;
            direction.x = playerMovementScript.rb.velocity.x;
            //direction.y = playerMovementScript.rb.velocity.y;
            Vector3 movement = new Vector3(
                speed.x * direction.x,
                speed.y * direction.y,
                0
                );

            movement *= Time.deltaTime;
            transform.Translate(movement);

            if (isLinkedToCamera)
            {
                Camera.main.transform.Translate(movement);
            }

            if(isLooping)
            {
                SpriteRenderer firstChild = backgroundPart.FirstOrDefault();
                SpriteRenderer lastChild = backgroundPart.LastOrDefault();
                if (firstChild != null)
                {
                    if (firstChild.transform.position.x < Camera.main.transform.position.x)
                    {
                        

                            //Debug.Log("I am responding leftward");
                            
                            Vector3 lastPosition = lastChild.transform.position;
                            Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

                            firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

                            backgroundPart.Remove(firstChild);
                            backgroundPart.Add(firstChild);

                    }

                    if (lastChild.transform.position.x > Camera.main.transform.position.x)
                    {

                            Debug.Log("I am responding rightward");

                            Vector3 lastPosition = lastChild.transform.position;
                            Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

                            firstChild.transform.position = new Vector3(lastPosition.x - lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

                            backgroundPart.Remove(firstChild);
                            backgroundPart.Add(firstChild);

                    }
                }
            }
        }
    }
}
