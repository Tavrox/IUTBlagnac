using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicExamples : MonoBehaviour
{
    public enum Classes
    {
        None = 0,
        Mage = 1,
        Barbare = 2,
        Rogue = 3
    };


    public List<Classes> availableClasses;


    // Je fais un drag n drop de mon texte dans ce champ
    public TextMeshProUGUI scoreText;
    public int scoreCounter;


    Vector3 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;

        doForExample();
        doVectorSimple();
        doVectorAddition();
        doResetCube();

        StartCoroutine(doCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doResetCube();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Press left");
            transform.position -= new Vector3(1f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (Classes _class in availableClasses)
            {
                Debug.Log("Classe disponible:"+_class);
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Camera.main.transform.position += new Vector3(1f, 1f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            doImproveScore();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            doDestroyMe();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            doRandomMove();
        }
    }

    void doDestroyMe()
    {
        Destroy(gameObject);
    }

    IEnumerator doCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Waiting for..." + i);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Clicked me");
        gameObject.SetActive(false);
    }

    void doResetCube()
    {
        transform.position = initPosition;
    }

    void doForExample()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("Incrémentation:" + i);
        }
    }

    void doRandomMove()
    {
        int _randX = Random.Range(-1, 2);
        int _randY = Random.Range(-1, 2);
        transform.position += new Vector3(_randX, _randY, 0f);
    }

    void doImproveScore()
    {
        scoreCounter++;
        scoreText.text = "Score:"+scoreCounter;
    }

    void doVectorSimple()
    {
        transform.position = new Vector3(10f, 20f, 30f);
    }

    void doVectorAddition()
    {
        Vector3 _one = new Vector3(10f, 5f, 20f);
        Vector3 _two = new Vector3(20f, 30f, 40f);
        Vector3 _result = _one + _two;
        transform.position = _result;
    }
}
