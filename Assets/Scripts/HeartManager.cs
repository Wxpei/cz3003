using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public List<Image> heartImages;

    public GameObject heartPrefab;
       
    public void SetupHeartManager(int noOfLife)
    {
        heartImages = new List<Image>();
        for (int i = 0; i < noOfLife; i++)
        {
            GameObject obj = Instantiate(heartPrefab, transform);

            heartImages.Add(obj.GetComponent<Image>());
        }

    }

    public void DeductLife()
    {
        Image currentImage = heartImages[0];
        heartImages.RemoveAt(0);
        Destroy(currentImage.gameObject);
    }
}
