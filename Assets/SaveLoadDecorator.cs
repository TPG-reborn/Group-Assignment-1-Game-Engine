using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//SAVE ALL CUBE OBJECTS USING DECORATOR PATTERN

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
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Console.Write("Save");
            whenSave();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Console.Write("Load");
            whenLoad();
        }
    }
}
