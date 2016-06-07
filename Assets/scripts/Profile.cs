using UnityEngine;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;

public class Profile : MonoBehaviour {

    private string path = @"Assets/Resources/SaveFiles/Save.txt";
    private int highest = 1;
    private bool fail;
    // Use this for initialization
    void Start () {
        prepareSave();
        highest = GetHighestLvlComplete();
        fail = false;
    }

    public bool DidFail()
    {
        return fail;
    }
    public void SetFail(bool value)
    {
        fail = value;
    }

    public int GetHighestLvlComplete()
    {
        //Load up the save file and check the highest completed level. 
        Debug.Log("Highest???");
        for (int i = 11; i > 1; i--) {
            string level = "Level:" + i.ToString();
            if (AvoEx.AesEncryptor.DecryptString(File.ReadAllText(path).ToString()).ToString().Contains(level))
            {
                Debug.Log("Checked highest");
                highest = i;
                i = 0;
            }
        }
        Debug.Log(AvoEx.AesEncryptor.DecryptString(File.ReadAllText(path)) + "gethighestlvlcomplete");
        return highest;
    }

    /*
    * appends completed level to the saved file. 
    */
    public void lvlComplete(int x)
    {
        //decrypt();
        if (x > highest)
        {
            highest = x;
            string level = "Level:" + highest.ToString();
            int isItWritten = AvoEx.AesEncryptor.DecryptString(File.ReadAllText(path)).Contains(level) ? 1 : 0;
            //Debug.Log(AvoEx.AesEncryptor.DecryptString(File.ReadAllText(path)) + "lvlcomplete");
            if(isItWritten == 0)
            {
                System.IO.File.WriteAllText(path, AvoEx.AesEncryptor.Encrypt(level) + "\n");
            }
            Debug.Log(AvoEx.AesEncryptor.DecryptString(File.ReadAllText(path)) + "lvlcomplete");

        }
        //encrypt();
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
            System.IO.File.WriteAllText(path, AvoEx.AesEncryptor.Encrypt("Start save") + "\n");
            Debug.Log("Created Save file - prepare");
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
                System.IO.File.WriteAllText(path, AvoEx.AesEncryptor.Encrypt("Start save") + "\n");
                Debug.Log("Created Save file - reset");
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
