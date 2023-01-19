using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(SpawnShop))]
public class MarkInEditor : Editor
{
    public VisualTreeAsset m_InspectorXML;

    private string oldText;
    private TextField _textField;
    
    public override VisualElement CreateInspectorGUI() {
        oldText = PlayerPrefs.GetString("text", oldText);
        
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement root = new VisualElement();

        m_InspectorXML.CloneTree(root);
        _textField = root.Q<TextField>("InputText");
        
        _textField.RegisterValueChangedCallback(TextChange);
        _textField.SetValueWithoutNotify(oldText);

        // Return the finished inspector UI
        return root;
    }


    private void TextChange(ChangeEvent<string> input) {
        oldText = input.newValue;
        PlayerPrefs.SetString("text", oldText);
    }
}
