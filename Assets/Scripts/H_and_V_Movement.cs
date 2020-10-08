using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_and_V_Movement : MonoBehaviour
{
    private float x, y;
    public float velocity, posicioninicialx, posicioninicialy;
    public float limitxder, limitxizq, limityarriba, limityabajo;
    public bool hor_o_ver, der_o_izq, arriba_o_abajo;

    // Start is called before the first frame update
    void Start()
    {
        x = 1;
        posicioninicialx = transform.position.x;
        y = 1;
        posicioninicialy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (hor_o_ver == false)
        {
            if (arriba_o_abajo == true)
            {
                transform.Translate(new Vector2(0, y) * Time.deltaTime * 1, Space.World);

                if (transform.position.y > posicioninicialy + limityarriba)
                {
                    y = -velocity;
                }

                if (transform.position.y < posicioninicialy - limityabajo)
                {
                    y = velocity;
                }
            }

            if (arriba_o_abajo == false)
            {
                transform.Translate(new Vector2(0, -y) * Time.deltaTime * 1, Space.World);

                if (transform.position.y < posicioninicialy - limityabajo)
                {
                    y = -velocity;
                }

                if (transform.position.y > posicioninicialy + limityarriba)
                {
                    y = velocity;
                }
            }
        }

        if (hor_o_ver == true)
        {
            if (der_o_izq == true)
            {
                transform.Translate(new Vector2(x, 0) * Time.deltaTime * 1, Space.World);

                if (transform.position.x > posicioninicialx + limitxder)
                {
                    x = -velocity;
                    GetComponent<SpriteRenderer>().flipX = false;
                }

                if (transform.position.x < posicioninicialx - limitxizq)
                {
                    x = velocity;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }

            if (der_o_izq == false)
            {
                transform.Translate(new Vector2(-x, 0) * Time.deltaTime * 1, Space.World);

                if (transform.position.x < posicioninicialx - limitxizq)
                {
                    x = -velocity;
                    GetComponent<SpriteRenderer>().flipX = true;
                }

                if (transform.position.x > posicioninicialx + limitxder)
                {
                    x = velocity;
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }
}