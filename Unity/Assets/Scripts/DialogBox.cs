using UnityEngine;
using System.Collections;
using Ink.Runtime;
using UnityEngine.UI;
using System;

public class DialogBox : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkJSONAsset;
    private Story story;

    [SerializeField]
    private Canvas canvas;

    // UI Prefabs
    [SerializeField]
    private Text textPrefab;
    [SerializeField]
    private Button buttonPrefab;

    public delegate void StoryCompleteCallback();

    public StoryCompleteCallback finishedCallback;

    // Use this for initialization
    void Start ()
    {
    }

    public int GetIntVariable(string variable, int defaultValue)
    {
        try
        {
            int var = (int)story.variablesState[variable];
            return var;
        }
        catch(Exception)
        {
            return defaultValue;
        }
    }

    public bool GetBoolVariable(string variable, bool defaultValue)
    {
        try
        {
            bool var = (int)story.variablesState[variable] > 0;
            return var;
        }
        catch (Exception e)
        {
            return defaultValue;
        }
    }

    public bool IsOnStory(TextAsset inkAsset)
    {
        if (inkJSONAsset == inkAsset)
        {
            return true;
        }
        return false;
    }

    public void StartStory(TextAsset inkAsset)
    {
        inkJSONAsset = inkAsset;
        story = new Story(inkJSONAsset.text);
        try
        {
            story.variablesState["trust"] = Game.Instance.Trust;
        }
        catch(Exception)
        {
            // Nothing!
        }
        RefreshView();
    }

    void RefreshView()
    {
        RemoveChildren();

        while (story.canContinue)
        {
            string text = story.Continue().Trim();
            CreateContentView(text);
        }

        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        else
        {
            Button choice = CreateChoiceView("Done.");
            choice.onClick.AddListener(delegate {
                OnFinishedStory();
            });
        }
    }

    void OnFinishedStory()
    {
        int trust = GetIntVariable("trust", -1);
        if (trust != -1)
        {
            Game.Instance.Trust = trust;
        }

        if (finishedCallback != null)
        {
            finishedCallback();
        }
    }

    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(this.transform, false);
    }

    Button CreateChoiceView(string text)
    {
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(this.transform, false);

        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    void RemoveChildren()
    {
        int childCount = this.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
