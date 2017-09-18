using UnityEngine;
using UnityEngine.UI;

public class HeartUIManager : MonoBehaviour
{
    public Image[] Hearts;
    public Sprite HeartOn;
    public Sprite HeartOff;
    
    void Start ()
    {
        PlayerLife.StaticLife.AddLifeDeletate(UpdateLifes);
    }

    void UpdateLifes(int lifes)
    {
        for(int i = 0; i < Hearts.Length; i++)
        {
            bool lifeOn = lifes > i;
            Hearts[i].sprite = lifeOn ? HeartOn : HeartOff;
        }
    }
}
