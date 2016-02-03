using UnityEngine;
using System.Collections;
using System.IO;

public class Profile : MonoBehaviour {

    private string path = "Assets/Resources/SaveFiles/Save.txt";
    private int highest;
    // Use this for initialization
    void Start () {
        highest = 1;
        //prepareSave();
	}

    private void encrypt() //To encrypt the save file
    {

    }

    private void decrypt() //To decrypt the save file
    {

    }
    /*
    * appends completed level to the saved file. 
    */

    public int GetHighestLvlComplete()
    {
        //Load up the save file and check the highest completed level. 

        return highest;
    }
	public void lvlComplete(int x)
    {
        if(x == 2)
        {
            System.IO.File.AppendAllText(path, "Level:2\n");
        }
        if (x == 3)
        {
            System.IO.File.AppendAllText(path, "Level:3\n");
        }
        if (x == 4)
        {
            System.IO.File.AppendAllText(path, "Level:4\n");
        }
        if (x == 5)
        {
            System.IO.File.AppendAllText(path, "Level:5\n");
        }
        if (x == 6)
        {
            System.IO.File.AppendAllText(path, "Level:6\n");
        }
        if (x == 7)
        {
            System.IO.File.AppendAllText(path, "Level:7\n");
        }
        if (x == 8)
        {
            System.IO.File.AppendAllText(path, "Level:8\n");
        }
        if (x == 9)
        {
            System.IO.File.AppendAllText(path, "Level:9\n");
        }
        if (x == 10)
        {
            System.IO.File.AppendAllText(path, "Level:10\n");
        }
    }
    public void prepareSave()
    {
        //create Folder   
        if (!Directory.Exists("Assets/Resources/SaveFiles"))
        {
            Directory.CreateDirectory("Assets/Resources/SaveFiles");
        }
        if (!File.Exists(path))
        {
            System.IO.File.WriteAllText(path, "save\n");
        }
    }
    /*
    * For resetting your saved file to nothing. 
    */
    public void resetSave()
    {
        if (Directory.Exists("Assets/Resources/SaveFiles"))
        {
            if (File.Exists(path))
            {
                System.IO.File.WriteAllText(path, "save\n");
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
