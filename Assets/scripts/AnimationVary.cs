using UnityEngine;
using System.Collections;

public class AnimationVary : MonoBehaviour {
    int var;
    Animator localAnim;
    float animTime;
    bool anim_Play;
    // Use this for initialization
    void Start () {
        //anim_Play = false;
        localAnim = GetComponent<Animator>();
        var = UnityEngine.Random.Range(0, 1);
        localAnim.SetFloat("Direction", 1);
        if (var == 1 || var == 0) //reverse play an animation
        {
            localAnim.Play("RopeAnimator");
            Debug.Log("Fuck you dolphin");
        } else
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
        //if (anim_Play && animTime < 1)           //If animation is toggled on
        //    animTime += 0.3f * Time.deltaTime;   //Increase animTime, Don't let animTime go beyond 1
        //else if (!anim_Play && animTime > 0)     //If animation is toggled off/reversed
        //    animTime -= 0.3f * Time.deltaTime;   //Decrease animTime, Don't let animTime go below 0

        //GetComponent<Animator>().Play("RopeAnimator", 0, animTime);
    }
}
