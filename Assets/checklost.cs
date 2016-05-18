using UnityEngine;
using System.Collections;

public class checklost : MonoBehaviour {

    private Animator animator;
    private GameObject go;
    private Profile other;
    // Use this for initialization
    void Start () {
        other = GameObject.Find("Master").GetComponent<Profile>();
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (other.DidFail())
        {
            animator.SetBool("loose", true);
        }
        else
        {
            animator.SetBool("loose", false);
        }
	}
}
