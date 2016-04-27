using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSprite : MonoBehaviour {

    // Use this for initialization
    private string[] sprites;
	void Start () {
        sprites = new string[7];
        sprites[0] = @"Balloon\Blue";
        sprites[1] = @"Balloon\Green";
        sprites[2] = @"Balloon\Light-Blue";
        sprites[3] = @"Balloon\Orange";
        sprites[4] = @"Balloon\Yellow";
        sprites[5] = @"Balloon\Pink";
        sprites[6] = @"Sprites\Cloud-clip-art";
        this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(sprites[UnityEngine.Random.Range(0, 7)]);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
