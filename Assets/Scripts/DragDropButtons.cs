using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropButtons : MonoBehaviour
{
    public RectTransform currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static DragDropButtons _Instance;
    public static DragDropButtons Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindAnyObjectByType<DragDropButtons>();
            }
            return _Instance;
        }
    }
}
