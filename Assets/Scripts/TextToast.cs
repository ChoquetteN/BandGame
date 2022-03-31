using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToast : MonoBehaviour
{
    Text wordsOnToast;
    public float howLongIsToast;
    private float toastCountDown;
    public float howFastIsToast;
    public float howHighUpScreenDoesToastGo;  
    private float toastHeight; 
    private bool isToastSent = false;
    private const float spaceBetweenToasts = .05f;
    [SerializeField]
    Color[] colorOfText;



    public void sendToast(Vector3 location, string whatToToast , int colorIndex)
    {
        if (wordsOnToast == null)
        {
            assignWordsOnToastObject();
        }
        GetComponent<RectTransform>().anchoredPosition = location;
        wordsOnToast.text = whatToToast;
        wordsOnToast.color = colorOfText[colorIndex];
        isToastSent = true;
        toastCountDown = howLongIsToast;
        gameObject.SetActive(true);
    }

    public void AlterToastFlightPlan(int numberOfActiveToasts)
    {
        toastHeight = howHighUpScreenDoesToastGo;
        toastHeight -= (spaceBetweenToasts * numberOfActiveToasts);
    }


    void Update()
    {
        if (isToastSent)
        {
            wordsOnToast.transform.position = Vector3.Lerp(wordsOnToast.transform.position, new Vector3(wordsOnToast.transform.position.x, (toastHeight * Screen.height), wordsOnToast.transform.position.z), howFastIsToast);
            checkIfToastIsOver();
        }
    }

    private void checkIfToastIsOver()
    {
        toastCountDown -= Time.deltaTime;
        if (toastCountDown <= 0)
        {
            wordsOnToast.text = " ";
            isToastSent = false;
            gameObject.SetActive(false);
        }
    }

    private void assignWordsOnToastObject()
    {
        wordsOnToast = this.GetComponent<Text>();
    }
}
