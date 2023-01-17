using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(SpawnShop))]
public class MarkInEditor : Editor
{
    public VisualTreeAsset m_InspectorXML;
    
    public override VisualElement CreateInspectorGUI() {
        
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();

        m_InspectorXML.CloneTree(myInspector);

        // Return the finished inspector UI
        return myInspector;
    }
}
