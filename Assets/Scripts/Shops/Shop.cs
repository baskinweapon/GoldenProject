using UnityEngine;

//The Shop its a substation when you can buy some inventories and skills
//The shop contain sell and buy (Two UI panel) 
public abstract class Shop : MonoBehaviour {
    public abstract void OpenShopUI();

    public abstract void Buy();
}
