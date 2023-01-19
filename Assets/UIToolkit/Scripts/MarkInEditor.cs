using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(CommentedUIEditor))]
public class MarkInEditor : Editor {
    public VisualTreeAsset m_InspectorXML;

    private string oldText;
    private TextField _textField;
    private VisualElement root;

    public override VisualElement CreateInspectorGUI() {
        oldText = PlayerPrefs.GetString("text", oldText);

        // Create a new VisualElement to be the root of our inspector UI
        root = new VisualElement();

        m_InspectorXML.CloneTree(root);
        root = root.Q<VisualElement>();

        root.style.height = new StyleLength(100f);
        
        _textField = root.Q<TextField>("InputText");

        _textField.RegisterValueChangedCallback(TextChange);
        _textField.SetValueWithoutNotify(oldText);
        
       ChangeTextFieldStyle(100f);

       // Return the finished inspector UI
        return root;
    }

    private void ChangeTextFieldStyle(float offset) {
        _textField.style.height = new StyleLength(( _textField.style.height.value.value + offset));
        root.style.height = new StyleLength((root.style.height.value.value + offset));
        root.style.color = Color.red;
    }


    private void TextChange(ChangeEvent<string> input) {

        var value = input.newValue;
        value = input.newValue.Replace("<br>", "\n");
        if (value.EndsWith("\n")) {
            ChangeTextFieldStyle(20f);
        }
        oldText = value;
        
        // ChangeTextFieldStyle(10);
        
        PlayerPrefs.SetString("text", oldText);
    }
}
