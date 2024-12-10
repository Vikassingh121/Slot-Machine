using System.Collections;
using UnityEngine;

public class SymbolRow : MonoBehaviour
{
   private float rotationSpeed;
   public bool isRotatingStop;

   public string stoppedSlot;
   private int randomValue;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isRotatingStop= true;
       
        GameController.HandlePulled += StartRotating;
    }


    private void StartRotating()
    {
        
        stoppedSlot = "";
        
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        isRotatingStop= false;
        rotationSpeed = 0.05f;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -2.2f)
            {
                transform.position = new Vector2(transform.position.x, 1.1f);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 1.1f);

            yield return new WaitForSeconds(rotationSpeed);
        }

        randomValue = Random.Range(60, 100);               

        for (int i = 0; i<randomValue; i++)
        {
            if (transform.position.y<= -2.2f)
            {
                transform.position = new Vector2(transform.position.x, 1.1f);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 1.1f);

            if (i> Mathf.RoundToInt(randomValue* 0.25f))
            {
                rotationSpeed = 0.25f;
            }
            if (i > Mathf.RoundToInt(randomValue * .5f))
            {
                rotationSpeed = 0.1f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
            {
                rotationSpeed = 0.15f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
            {
                rotationSpeed = 0.2f;
            }
            yield return new WaitForSeconds(rotationSpeed);
        }

        if(transform.position.y == -1.1f)
        {
            stoppedSlot = "Bell";

        }
        else if (transform.position.y == 0f)
        {
            stoppedSlot = "Cherry";

        }
        else if (transform.position.y == 1.1f)
        {
            stoppedSlot = "Seven";

        }
        else if (transform.position.y == 2.2f)
        {
            stoppedSlot = "Bar";

        }
        if (transform.position.y == -2.2f)
        {
            stoppedSlot = "Bar";

        }

        isRotatingStop = true;
    }

    private void OnDestroy()
    {
        GameController.HandlePulled -= StartRotating;
    }
     
}
