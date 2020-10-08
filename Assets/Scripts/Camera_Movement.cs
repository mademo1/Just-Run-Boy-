using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 202)
        {
            transform.Translate(new Vector2(Character_Mechanics.velocity, 0) * Time.deltaTime * 1, Space.World);
        }

        if (transform.position.x > 202)
        {
            transform.Translate(new Vector2(0, 0) * Time.deltaTime * 1, Space.World);
        }
    }
}
