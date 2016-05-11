using UnityEngine;
using System.Collections;
using System.IO;

public class Profile : MonoBehaviour {

    private string path = "Assets/Resources/SaveFiles/Save.txt";
    private int highest = 1;
    // Use this for initialization
    void Start () {
        prepareSave();
        highest = GetHighestLvlComplete();
	}

    private void encrypt() //To encrypt the save file
    {

    }

    private void decrypt() //To decrypt the save file
    {

    }

    public int GetHighestLvlComplete()
    {
        //Load up the save file and check the highest completed level. 
        for (int i = 11; i > 1; i--) {
            string level = "Level:" + i.ToString();
            if (File.ReadAllText(path).Contains(level))
            {
                highest = i;
                i = 0;
            }
        }
        return highest;
    }

    /*
    * appends completed level to the saved file. 
    */
    public void lvlComplete(int x)
    {
        if (x > highest)
        {
            highest = x;
            string level = "Level:" + highest.ToString();
            int isItWritten = File.ReadAllText(path).Contains(level) ? 1 : 0;
            if(isItWritten == 0)
            {
                System.IO.File.AppendAllText(path, level + "\n");
                Debug.Log(level);
            }
            
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
