using UnityEngine;
using System.Collections;
using UnityEngine.UI; //needed for Text
using System; //needed for string

public class LoadingScript : MonoBehaviour {

    public GameObject go;
    private String[] theRandomText;
    public Text loadingText, randomText;
    private float time;
    // Use this for initialization
    void Start () {
        time = UnityEngine.Random.Range(3F, 5F);
        theRandomText = new String[10];
        theRandomText[0] = "Random Hints or Fun Facts!";
        theRandomText[1] = "Click on a balloon to make it pop!";
        theRandomText[2] = "Some balloons are armored and require multiple clicks!";
        theRandomText[3] = "Some balloons spawn two smaller balloons!";
        theRandomText[4] = "If you unlock the infinate level it is just that, an infinate level!";
        theRandomText[5] = "Balloons were invented in 1824, parties were changed forever...";
        theRandomText[6] = "Popping balloons burns calories!";
        theRandomText[7] = "Balloons are known to scare animals and small children...";
        theRandomText[8] = "Surgeons who grew up playing video games make fewer mistakes in surgery!";
        theRandomText[9] = "Helium is not Oxygen.";
        randomText.text = theRandomText[UnityEngine.Random.Range(0, 10)]; //random range excludes the last digit

    }

	
	// Update is called once per frame
	void Update () {
        if (time >= 2.6f)
        {
            time -= Time.deltaTime;
            loadingText.text = "Loading .";
        } else if (time >= 1.3F && time < 2.6F)
        {
            time -= Time.deltaTime;
            loadingText.text = "Loading . .";
        }
        else if (time > 0F && time < 1.3F)
        {
            time -= Time.deltaTime;
            loadingText.text = "Loading . . .";
        } else
        {
            time = UnityEngine.Random.Range(3F, 5F);
        }
    }
}
