using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameController : MonoBehaviour
{

    public static event Action HandlePulled = delegate { };


    [SerializeField]
    private TextMeshProUGUI m_TextMeshPro;

    [SerializeField]
    private SymbolRow[] Rows;

    [SerializeField]
    private Transform Handle;

    private int prizeValue;

    private bool resultsChecked = false;

    private void Update()
    {
        if (!Rows[0].isRotatingStop|| !Rows[1].isRotatingStop|| !Rows[2].isRotatingStop)
        {
            prizeValue = 0;
            m_TextMeshPro.enabled = false;
            resultsChecked = false;
        }

        if (Rows[0].isRotatingStop && Rows[1].isRotatingStop && Rows[2].isRotatingStop && !resultsChecked)
        {

            CheckForWin();
            m_TextMeshPro.enabled = true;
            m_TextMeshPro.text = "Prize:  " + prizeValue;


        }

    }

   
    private void OnMouseDown()
    {
        if (Rows[0].isRotatingStop&& Rows[1].isRotatingStop&& Rows[2].isRotatingStop)
        {
            StartCoroutine("PullHandle");
        }
    }
    private IEnumerator PullHandle()
    {
        for (int i = 0; i < 15; i += 5)
        {
            Handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }

        HandlePulled();

        for (int i = 0; i < 15; i += 5)
        {
            Handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }



    private void CheckForWin()
    {
        // Implement win condition checking logic here


        if (Rows[0].stoppedSlot == "Bell" && Rows[1].stoppedSlot == "Bell" && Rows[2].stoppedSlot == "Bell")
        {
            prizeValue = 200;
        }

        else if (Rows[0].stoppedSlot == "Cherry" && Rows[1].stoppedSlot == "Cherry" && Rows[2].stoppedSlot == "cherry")
        {
            prizeValue = 400;
        }
        else if (Rows[0].stoppedSlot == "Seven" && Rows[1].stoppedSlot == "Seven" && Rows[2].stoppedSlot == "Seven")
        {
            prizeValue = 600;
        }
        else if (Rows[0].stoppedSlot == "Bar" && Rows[1].stoppedSlot == "Bar" && Rows[2].stoppedSlot == "Bar")
        {
            prizeValue = 800;
        }

        else if (((Rows[0].stoppedSlot == Rows[1].stoppedSlot) && (Rows[0].stoppedSlot == "Bell")) || ((Rows[0].stoppedSlot == Rows[2].stoppedSlot) && (Rows[0].stoppedSlot == "Bell")) || ((Rows[1].stoppedSlot == Rows[2].stoppedSlot) && (Rows[1].stoppedSlot == "Bell")))
        {
            prizeValue = 100;
        }
        else if (((Rows[0].stoppedSlot == Rows[1].stoppedSlot) && (Rows[0].stoppedSlot == "Cherry")) || ((Rows[0].stoppedSlot == Rows[2].stoppedSlot) && (Rows[0].stoppedSlot == "Cherry")) || ((Rows[1].stoppedSlot == Rows[2].stoppedSlot) && (Rows[1].stoppedSlot == "Cherry")))
        {
            prizeValue = 200;
        }
        else if (((Rows[0].stoppedSlot == Rows[1].stoppedSlot) && (Rows[0].stoppedSlot == "Seven")) || ((Rows[0].stoppedSlot == Rows[2].stoppedSlot) && (Rows[0].stoppedSlot == "Seven")) || ((Rows[1].stoppedSlot == Rows[2].stoppedSlot) && (Rows[1].stoppedSlot == "Seven")))
        {
            prizeValue = 300;
        }
        else if (((Rows[0].stoppedSlot == Rows[1].stoppedSlot) && (Rows[0].stoppedSlot == "Bar")) || ((Rows[0].stoppedSlot == Rows[2].stoppedSlot) && (Rows[0].stoppedSlot == "Bar")) || ((Rows[1].stoppedSlot == Rows[2].stoppedSlot) && (Rows[1].stoppedSlot == "Bar")))
        {
            prizeValue = 800;
        }

        resultsChecked = true;
    }

}

