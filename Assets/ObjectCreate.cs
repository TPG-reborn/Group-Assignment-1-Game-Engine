using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/////// Factory Method Design Pattern Setup Start ///////
public interface Building
{
    void Build(Vector3 pos, Vector3 scale);
}

public class Box : Building
{
    public void Build(Vector3 pos, Vector3 scale)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.transform.position = new Vector3(pos.x, pos.y, pos.z);
        cube.transform.localScale = new Vector3(1, 1, 1);
        cube.AddComponent<BoxCollider>();
    }
}

public class Sphere : Building
{
    public void Build(Vector3 pos, Vector3 scale)
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = new Vector3(pos.x, pos.y, pos.z);
        sphere.transform.localScale = new Vector3(1, 1, 1);
    }
}

public abstract class FactoryCreator
{
    public abstract Building Type(int type);
}

public class BuildingFactory : FactoryCreator
{
    public override Building Type(int type)
    {
        if (type == 1)
        {
            return new Box();
        }

        if (type == 2)
        {
            return new Sphere();
        }

        return null;
    }
}

//////// Factory Method Design Pattern Setup End /////////

public class ObjectCreate : MonoBehaviour
{
    public GameObject barn;
    BuildingFactory factory = new BuildingFactory();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //createCube();
            Building builder = factory.Type(1);
            builder.Build(gameObject.transform.position, new Vector3(1, 1, 1));
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            //createSphere();
            Building builder2 = factory.Type(2);
            builder2.Build(gameObject.transform.position, new Vector3(1, 1, 1));
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //createBarn();
        }
    }

    //public void createCube()
    //{
    //    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    float posX = gameObject.transform.position.x;
    //    float posY = gameObject.transform.position.y;
    //    float posZ = gameObject.transform.position.z;
    //
    //    cube.transform.position = new Vector3(posX, posY, posZ);
    //    cube.transform.localScale = new Vector3 (1, 1, 1);
    //    cube.AddComponent<BoxCollider>();
    //}
    //
    //public void createSphere()
    //{
    //    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    float posX = gameObject.transform.position.x;
    //    float posY = gameObject.transform.position.y;
    //    float posZ = gameObject.transform.position.z;
    //
    //    sphere.transform.position = new Vector3(posX, posY, posZ);
    //    sphere.transform.localScale = new Vector3(1, 1, 1);
    //}
    //
    //public void createBarn()
    //{
    //    float posX = gameObject.transform.position.x;
    //    float posY = gameObject.transform.position.y;
    //    float posZ = gameObject.transform.position.z;
    //    Instantiate(barn, new Vector3(posX, posY, posZ), Quaternion.identity);
    //}
}
