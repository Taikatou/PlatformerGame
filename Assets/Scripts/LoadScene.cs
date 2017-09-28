using UnityEngine;

public class LoadScene : MonoBehaviour {

    public GameObject loadingImage;

    public void Load(int level)
    {
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
