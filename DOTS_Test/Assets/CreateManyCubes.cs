using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManyCubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < x; ++i)
        {
            for(int j = 0; j < y; ++j)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(i, 0, j);
                cube.transform.SetParent(transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField]
    int x;
    [SerializeField]
    int y;
}