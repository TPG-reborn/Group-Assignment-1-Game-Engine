using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

abstract class AbstractLoad: MonoBehaviour
{
    public abstract void whenLoad();
    public abstract void whenSave();

    //Set the name of the referenced DLL file
    const string DLL_NAME = "DLL TUTORIAL 2";

    //Referencing all of the needed functions from the DLL
    [DllImport(DLL_NAME)]
    public static extern void SavePos(string file);

    [DllImport(DLL_NAME)]
    public static extern void LoadPos(string file);

    [DllImport(DLL_NAME)]
    public static extern float setX(float x);

    [DllImport(DLL_NAME)]
    public static extern float setY(float y);

    [DllImport(DLL_NAME)]
    public static extern float setZ(float z);

    [DllImport(DLL_NAME)]
    public static extern float getX();

    [DllImport(DLL_NAME)]
    public static extern float getY();

    [DllImport(DLL_NAME)]
    public static extern float getZ();

}

class SaveLoad : AbstractLoad
{
   

    //Check for the inputs below at every frame
    /*
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    whenSave();
        //}
        //
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    whenLoad();
        //}
    }
    */

    //What to do when saving position of the cube
    public override void whenSave()
    {
        //Store the float values of the X,Y,Z position of the cube
        float posX = gameObject.transform.position.x;
        float posY = gameObject.transform.position.y;
        float posZ = gameObject.transform.position.z;

        //Set the X,Y,Z position of the cube that will be saved using the functions in the DLL
        setX(posX);
        setY(posY);
        setZ(posZ);

        //Show saved position in debug log
        Debug.Log("Saved Cube Position: " + posX + ", " + posY + ", " + posZ);

        //Save cube position values in the text file
        SavePos("Position.txt");
    }

    public override void whenLoad()
    {
        //Read the values stored in the text file
        LoadPos("Position.txt");

        //Get X,Y,Z float values from the loaded text file 
        float posX = getX();
        float posY = getY();
        float posZ = getZ();

        //Set cube poosition to the values gathered from the text file
        transform.position = new Vector3(posX, posY, posZ);

        //Show loaded position in debug log
        Debug.Log("Loaded Cube Position: " + posX + ", " + posY + "," + posZ);
    }
}

class SaveLoadDecorator : AbstractLoad
{
    public override void whenSave()
    {

        GameObject[] cubes;
        cubes = GameObject.FindGameObjectsWithTag("Cube");

        Vector3[] positions = new Vector3[cubes.Length];

        foreach (GameObject cube in cubes)
        {
            for (int i = 0; i <= positions.Length; i++)
            {
                positions[i].x = cube.transform.position.x;
                positions[i].y = cube.transform.position.y;
                positions[i].z = cube.transform.position.z;

                setX(positions[i].x);
                setY(positions[i].y);
                setZ(positions[i].z);
            }
        }
       
    }

    public override void whenLoad()
    {
        GameObject[] cubes;
        cubes = GameObject.FindGameObjectsWithTag("Cube");

        Vector3[] positions = new Vector3[cubes.Length];

        foreach (GameObject cube in cubes)
        {
            for (int i = 0; i <= positions.Length; i++)
            {
                cube.transform.position = new Vector3(positions[i].x, positions[i].y, positions[i].z);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            whenSave();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            whenLoad();
        }
    }
}
