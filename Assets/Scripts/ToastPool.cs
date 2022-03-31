using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToastPool : MonoBehaviour
{
    TextToast[] toastPool = new TextToast[7];

    [SerializeField]
    TextToast ToastObjectToCreate;

    private int numberOfUsedToasts;

    static ToastPool instance;

    public static ToastPool Instance { get { return instance; } }

    static System.Object padLock = new System.Object();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < toastPool.Length; i++)
        {
            RectTransform rt = GetComponent<RectTransform>();
            toastPool[i] = Instantiate(ToastObjectToCreate,this.transform);
            toastPool[i].gameObject.SetActive(false);
        }
    }

    public void SendToastFromLocation(Vector3 locationOfToast, string whatToToast, int colorIndex)
    {
        TextToast toastOut = findAvailableToastFromPool();
        toastOut.AlterToastFlightPlan(numberOfUsedToasts);
        toastOut.sendToast(locationOfToast, whatToToast, colorIndex);
    }

    TextToast findAvailableToastFromPool()
    {
        TextToast toastToReturn = findUnoccupiedToast();
        toastToReturn.enabled = true;
        return toastToReturn;
    }

    TextToast findUnoccupiedToast()
    {
        for (int i = 0; i < toastPool.Length; i++)
        {
            if (!toastPool[i].gameObject.activeInHierarchy)
            {
                return toastPool[0];
            }
            
            //  else numberOfUsedToasts++; 
        }
        return toastPool[0];
        // return toastPool[0];
    }

}
