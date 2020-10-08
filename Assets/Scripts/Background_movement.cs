using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 400f)
        {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 1, Space.World);
        }
    }
}
