using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SaveLoad : MonoBehaviour
{
    //Set the name of the referenced DLL file
    const string DLL_NAME = "DLL TUTORIAL 2";

    //Referencing all of the needed functions from the DLL
    [DllImport(DLL_NAME)]
    private static extern void SavePos(string file);

    [DllImport(DLL_NAME)]
    private static extern void LoadPos(string file);

    [DllImport(DLL_NAME)]
    private static extern float setX(float x);

    [DllImport(DLL_NAME)]
    private static extern float setY(float y);

    [DllImport(DLL_NAME)]
    private static extern float setZ(float z);

    [DllImport(DLL_NAME)]
    private static extern float getX();

    [DllImport(DLL_NAME)]
    private static extern float getY();

    [DllImport(DLL_NAME)]
    private static extern float getZ();

    void Start()
    {
        
    }

    //Check for the inputs below at every frame
    void Update()
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

    //What to do when saving position of the cube
    public void whenSave()
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

    public void whenLoad()
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
