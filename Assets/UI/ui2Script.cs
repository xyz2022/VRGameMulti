using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ui2Script : MonoBehaviour
{
    [SerializeField] private SceneLoader.SceneNames nextScene;

    SceneLoader loader;

    void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
        var root = GetComponent<UIDocument>().rootVisualElement;
        var buttonComplete = root.Q<UnityEngine.UIElements.Button>("buttonInGameComplete");
        buttonComplete.clickable.clickedWithEventInfo += B_clicked;
        var buttonFail = root.Q<UnityEngine.UIElements.Button>("buttonInGameFail");
        buttonFail.clickable.clickedWithEventInfo += F_clicked;
        //DontDestroyOnLoad(gameObject);
    }
    private void B_clicked(EventBase e)
    {
        Button button = (Button)e.target;
        print("Got: " + button.text);
        //SceneLoader.nextScene = SceneLoader.SceneNames.Level2Scene;
        loader.LoadScene(nextScene);
    }
    private void F_clicked(EventBase e)
    {
        Button button = (Button)e.target;
        print("Got: " + button.text);
        loader.LoadScene(SceneLoader.SceneNames.LoseScene);
    }
}
