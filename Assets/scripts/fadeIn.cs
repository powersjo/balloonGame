using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour {

    private GameObject[] letters;

    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }
    //This IEnumerator does the actual fade in and out.
    IEnumerator DoFade()
    {
        CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
        canvasgroup.interactable = false; //buttons and such can't be clicked
        int divisor = 4; //2 = 4 seconds, 3 = 6, 4 = 8 ... etc
        while (canvasgroup.alpha < 1)
        {
            canvasgroup.alpha += Time.deltaTime / divisor;
            yield return null;
        }
        while (canvasgroup.alpha > 0)
        {
            canvasgroup.alpha -= Time.deltaTime / divisor;
            yield return null;
        }

        yield return null;
    }

    void Start()
    {
        Color[] colorBox = new Color[8];
        colorBox[0] = Color.red;
        colorBox[1] = Color.blue;
        colorBox[2] = Color.yellow;
        colorBox[3] = Color.green;
        colorBox[4] = Color.cyan;
        colorBox[5] = Color.magenta;
        colorBox[6] = Color.white;
        colorBox[7] = new Color(255,165,0); //Orange
        if (letters == null)
        {
            letters = GameObject.FindGameObjectsWithTag("Letter");
        }
        foreach(GameObject letter in letters)
        {
            letter.gameObject.GetComponent<Text>().color = colorBox[Random.Range(0,8)];
        }
        FadeMe();
    }
}
