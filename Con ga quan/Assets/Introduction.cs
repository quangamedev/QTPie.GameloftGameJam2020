using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] storyContext;

    int currentIndex = 0;

    //Exec when press button
    public void OnPointerClick(PointerEventData eventData)
    {
        Next(storyContext.Length);
    }

    //Reset context to 0 when scene start
    public void Start()
    {
        CurrentIndex = 0;
    }

    //Next button function
    public void Next(int direction)
    {
            CurrentIndex++;
    }

    //Return an int
    public int CurrentIndex
    {

        get
        {
            return currentIndex;
        }
        set
        {
            if (storyContext[currentIndex] != null)
            {
                //set the current active object to inactive, before replacing it
                GameObject activeObject = storyContext[currentIndex];
                activeObject.SetActive(false);
            }

            if (value < 0)
                currentIndex = storyContext.Length - 1;
            else if (value > storyContext.Length - 1)
                LoadNewScene();
            else
                currentIndex = value;
            if (storyContext[currentIndex] != null)
            {
                GameObject activeObject = storyContext[currentIndex];
                activeObject.SetActive(true);
            }
        }
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }
}
