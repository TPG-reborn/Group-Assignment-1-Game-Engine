using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/////// Factory Method Design Pattern Setup Start ///////

public class Prefab : MonoBehaviour
{
    public GameObject _prefab;
    //void convert(GameObject prefab)
    //{
    //    _prefab = prefab;
    //}

    public Prefab(GameObject prefab)
    {
        _prefab = prefab;
    }
}

public interface Building
{
    void Build(Vector3 pos, Vector3 scale);
    void Destruct();
}

public class Box : Building
{
    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    public void Build(Vector3 pos, Vector3 scale)
    {
        cube.SetActive(true);
        cube.transform.position = new Vector3(pos.x, pos.y, pos.z);
        cube.transform.localScale = new Vector3(1, 1, 1);
        cube.AddComponent<BoxCollider>();
    }
    public void Destruct()
    {
        cube.SetActive(false);
    }
}

public class Sphere : Building
{
    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    public void Build(Vector3 pos, Vector3 scale)
    {
        sphere.SetActive(true);
        sphere.transform.position = new Vector3(pos.x, pos.y, pos.z);
        sphere.transform.localScale = new Vector3(1, 1, 1);
    }
    public void Destruct()
    {
        sphere.SetActive(false);
    }
}

public class Office : Building
{
    GameObject officePrefab = (GameObject)GameObject.Instantiate(Resources.Load("Office"));
    public void Build(Vector3 pos, Vector3 scale)
    {
        officePrefab = GameObject.Instantiate(officePrefab, pos, Quaternion.identity);
        officePrefab.SetActive(true);
        officePrefab.transform.position = new Vector3(pos.x, pos.y, pos.z);
        officePrefab.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
    }
    
    public void Destruct()
    {
        officePrefab.SetActive(false);
    }
}

public class Barn : Building
{
    GameObject barnPrefab = (GameObject)GameObject.Instantiate(Resources.Load("Barn"));
    public void Build(Vector3 pos, Vector3 scale)
    {
        barnPrefab = GameObject.Instantiate(barnPrefab, pos, Quaternion.identity);
        barnPrefab.SetActive(true);
        barnPrefab.transform.position = new Vector3(pos.x, pos.y, pos.z);
        barnPrefab.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
    }

    public void Destruct()
    {
        barnPrefab.SetActive(false);
    }
}

public class Factory : Building
{
    GameObject factoryPrefab = (GameObject)GameObject.Instantiate(Resources.Load("Factory"));
    public void Build(Vector3 pos, Vector3 scale)
    {
        factoryPrefab = GameObject.Instantiate(factoryPrefab, pos, Quaternion.identity);
        factoryPrefab.SetActive(true);
        factoryPrefab.transform.position = new Vector3(pos.x, pos.y, pos.z);
        factoryPrefab.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
    }

    public void Destruct()
    {
        factoryPrefab.SetActive(false);
    }
}

public class Tall : Building
{
    GameObject tallPrefab = (GameObject)GameObject.Instantiate(Resources.Load("TallBuilding"));
    public void Build(Vector3 pos, Vector3 scale)
    {
        tallPrefab = GameObject.Instantiate(tallPrefab, pos, Quaternion.identity);
        tallPrefab.SetActive(true);
        tallPrefab.transform.position = new Vector3(pos.x, pos.y, pos.z);
        tallPrefab.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
    }

    public void Destruct()
    {
        tallPrefab.SetActive(false);
    }
}

public class AptBuilding : Building
{
    GameObject aptBuildingPrefab = (GameObject)GameObject.Instantiate(Resources.Load("AptBuilding"));
    public void Build(Vector3 pos, Vector3 scale)
    {
        aptBuildingPrefab = GameObject.Instantiate(aptBuildingPrefab, pos, Quaternion.identity);
        aptBuildingPrefab.SetActive(true);
        aptBuildingPrefab.transform.position = new Vector3(pos.x, pos.y, pos.z);
        aptBuildingPrefab.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
    }

    public void Destruct()
    {
        aptBuildingPrefab.SetActive(false);
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

        if (type == 3)
        {
            return new Office();
        }

        if (type == 4)
        {
            return new Barn();
        }

        if (type == 5)
        {
            return new Factory();
        }

        if (type == 6)
        {
            return new Tall();
        }

        if (type == 7)
        {
            return new AptBuilding();
        }

        return null;
    }
}

//////// Factory Method Design Pattern Setup End /////////


/////// Command Design Pattern Setup Start /////////

public abstract class Commander
{
    public abstract void run();
}

public class Redo : Commander
{
    Vector3 _vec3;
    Building _lastBuilt;

    public Redo(Vector3 vec3, Building lastBuilt)
    {
        _vec3 = vec3;
        _lastBuilt = lastBuilt;
    }

    public override void run()
    {
        _lastBuilt.Build(_vec3, new Vector3(1, 1, 1));
        Debug.Log("Redo");
    }
}

public class Undo : Commander
{
    Building _lastBuilt;

    public Undo(Building lastBuilt)
    {
        _lastBuilt = lastBuilt;
    }

    public override void run()
    {
        _lastBuilt.Destruct();
        Debug.Log("Undo");
    }
}
public class RedoUndoButton
{
    public Commander _cmd;
    public RedoUndoButton(Commander cmd)
    {
        _cmd = cmd;
    }

    public void press()
    {
        _cmd.run();
    }
}

/////// Command Design Pattern Setup End /////////
public class ObjectCreate : MonoBehaviour
{
    public GameObject barn;
    public GameObject barn2;
    BuildingFactory factory = new BuildingFactory();

    Vector3 lastObjPos;
    Building lastObjBuilt;
    Building unwanted;

    Redo redo;
    Undo undo;
    RedoUndoButton button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        redo = new Redo(lastObjPos, lastObjBuilt);
        undo = new Undo(unwanted);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Building builder = factory.Type(1);
            builder.Build(gameObject.transform.position, new Vector3(1, 1, 1));
            lastObjPos = gameObject.transform.position;
            lastObjBuilt = builder;
            unwanted = builder;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Building builder = factory.Type(2);
            builder.Build(gameObject.transform.position, new Vector3(1, 1, 1));
            lastObjPos = gameObject.transform.position;
            lastObjBuilt = builder;
            unwanted = builder;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Building builder = factory.Type(3);
            builder.Build(gameObject.transform.position, new Vector3(0.7f, 0.7f, 0.7f));
            lastObjPos = gameObject.transform.position;
            lastObjBuilt = builder;
            unwanted = builder;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Building builder = factory.Type(5);
            builder.Build(gameObject.transform.position, new Vector3(0.7f, 0.7f, 0.7f));
            lastObjPos = gameObject.transform.position;
            lastObjBuilt = builder;
            unwanted = builder;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Building builder = factory.Type(4);
            builder.Build(gameObject.transform.position, new Vector3(0.7f, 0.7f, 0.7f));
            lastObjPos = gameObject.transform.position;
            lastObjBuilt = builder;
            unwanted = builder;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Building builder = factory.Type(6);
            builder.Build(gameObject.transform.position, new Vector3(0.7f, 0.7f, 0.7f));
            lastObjPos = gameObject.transform.position;
            lastObjBuilt = builder;
            unwanted = builder;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Building builder = factory.Type(7);
            builder.Build(gameObject.transform.position, new Vector3(0.7f, 0.7f, 0.7f));
            lastObjPos = gameObject.transform.position;
            lastObjBuilt = builder;
            unwanted = builder;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            button = new RedoUndoButton(redo);
            button.press();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            button = new RedoUndoButton(undo);
            button.press();
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
