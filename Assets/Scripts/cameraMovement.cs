using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector2(0,2);

    [Range(0, 1)] public float LerpPerFrameX = 0.1f;
    [Range(0, 1)] public float LerpPerFrameY = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xx = Mathf.Lerp(transform.position.x - offset.x, player.transform.position.x, LerpPerFrameX) + offset.x;
        float yy = Mathf.Lerp(transform.position.y - offset.y, player.transform.position.y, LerpPerFrameY) + offset.y;
        
        transform.position = new Vector3(xx,yy,transform.position.z);
    }
}
