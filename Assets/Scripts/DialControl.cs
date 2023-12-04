using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialControl : MonoBehaviour
{
    [SerializeField] Image handle;
    [SerializeField] Image fill;
    [SerializeField] Text valTxt;
    Vector3 mousePos;

    public void onHandleDrag()
    {
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - fill.rectTransform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle < 0) ? (360 + angle) : angle;
        float fillAmount = angle / 360f;
        fill.fillAmount = fillAmount;
        Quaternion r = Quaternion.AngleAxis(angle, Vector3.forward);
        handle.rectTransform.rotation = r;

        //if(angle >=260 || angle <= 320)
        //{
        //    Quaternion r = Quaternion.AngleAxis(angle+180f, Vector3.forward);
        //    handle.rotation = r;
        //    angle = ((angle >= 260) ? (angle - 360) : angle) + 45;
        //    fill.fillAmount = 0.35f - (angle / 360f);
        //    valTxt.text = Mathf.Round((fill.fillAmount * 100) / 0.35f).ToString();
        //}
    }
}
