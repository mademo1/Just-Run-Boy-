using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_and_V_Movement : MonoBehaviour
{
    private int x, y, startpostionx, startpostiony;
    public int limitxright, limitxleft, limitytop, limitybot, velocity;
    public bool hor_or_ver, right_or_left, top_or_bot;

    // Start is called before the first frame update
    void Start()
    {
        x = velocity;
        startpostionx = transform.position.x;
        y = velocity;
        startpostiony = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (hor_or_ver == false)
        {
            if (top_or_bot == true)
            {
                transform.Translate(new Vector2(0, y) * Time.deltaTime * 1, Space.World);

                if (transform.position.y > startpostiony + limitytop)
                {
                    y = -velocity;
                }

                if (transform.position.y < startpostiony - limitybot)
                {
                    y = velocity;
                }
            }

            if (top_or_bot == false)
            {
                transform.Translate(new Vector2(0, -y) * Time.deltaTime * 1, Space.World);

                if (transform.position.y < startpostiony - limitybot)
                {
                    y = -velocity;
                }

                if (transform.position.y > startpostiony + limitybot)
                {
                    y = velocity;
                }
            }
        }

        if (hor_or_ver == true)
        {
            if (right_or_left == true)
            {
                transform.Translate(new Vector2(x, 0) * Time.deltaTime * 1, Space.World);

                if (transform.position.x > startpostionx + limitxright)
                {
                    x = -velocity;
                }

                if (transform.position.x < startpostionx - limitxleft)
                {
                    x = velocity;
                }
            }

            if (right_or_left == false)
            {
                transform.Translate(new Vector2(-x, 0) * Time.deltaTime * 1, Space.World);

                if (transform.position.x < startpostionx - limitxleft)
                {
                    x = -velocity;
                }

                if (transform.position.x > startpostionx + limitxright)
                {
                    x = velocity;
                }
            }
        }
    }
}