using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButton : MonoBehaviour
{
    public GameObject startButton;   
    // Start is called before the first frame update
    public void HideStart() {
        startButton.SetActive(false);
    }
}
