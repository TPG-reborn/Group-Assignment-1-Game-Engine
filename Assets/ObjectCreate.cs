using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            createCube();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            createSphere();
        }
    }

    public void createCube()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        float posX = gameObject.transform.position.x;
        float posY = gameObject.transform.position.y;
        float posZ = gameObject.transform.position.z;

        cube.transform.position = new Vector3(posX, posY, posZ);
        cube.transform.localScale = new Vector3 (1, 1, 1);
        cube.AddComponent<BoxCollider>();
    }

    public void createSphere()
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        float posX = gameObject.transform.position.x;
        float posY = gameObject.transform.position.y;
        float posZ = gameObject.transform.position.z;

        sphere.transform.position = new Vector3(posX, posY, posZ);
        sphere.transform.localScale = new Vector3(1, 1, 1);
    }
}
