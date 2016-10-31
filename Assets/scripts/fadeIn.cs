using UnityEngine;
using System.Collections;

public class fadeIn : MonoBehaviour {

    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
    {
        CanvasGroup canvasgroup = GetComponent<CanvasGroup>();
        canvasgroup.interactable = false; //buttons and such can't be clicked
        int divisor = 3;
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
        FadeMe();
    }
}
