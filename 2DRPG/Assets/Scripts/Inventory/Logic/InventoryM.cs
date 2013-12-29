using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class InventoryM : MonoBehaviour
{
    #region Public Properties
    public List<PickableItemProperties> Inventory;
    public GameObject inventoryGrid;
    #endregion

    private bool ShowGUI = false;

    private GameObject InventorySlot;

    private Rect windowRect;
    private RaycastHit2D hit;
    private Ray ray;
    public LayerMask mask;
    void Awake()
    {

        Inventory = new List<PickableItemProperties>();
        if (PlayerPrefs.HasKey("InvWndX"))
        {
            windowRect = new Rect(PlayerPrefs.GetFloat("InvWndX"), PlayerPrefs.GetFloat("InvWndY"), 300, 300);
        }
        else
        {
            windowRect = new Rect(0, 0, 300, 300);
        }
    }

    void Start()
    {

        inventoryGrid = GameObject.FindGameObjectWithTag("InventoryGrid");
        InventorySlot = (Resources.Load("Slot")) as GameObject;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (ShowGUI == false)
            {
                ShowGUI = true;
            }
            else
            {
                ShowGUI = false;
            }
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Pickable")
        {

            Item newItem = col.gameObject.GetComponent<Item>();
            PickableItemProperties newItems = newItem.item;
            var item = (from r in Inventory
                        where r.id == newItems.id
                        select r).FirstOrDefault();

            if (item == null)
            {
                newItems.count = 1;
                Inventory.Add(newItems);
                
            }
            else
            {
                item.count++;

            }
            Destroy(col.gameObject);
            AddToGUI();
        }
    }

    private void AddToGUI()
    {
        //Remove any existing GameObject from Grid
        var children = new List<GameObject>();
        foreach (Transform child in inventoryGrid.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
        

        //Add all items to inventory
        foreach (var item in Inventory)
        {
            var newSlot = new GameObject();
            newSlot = InventorySlot;
            newSlot.GetComponent<UI2DSprite>().sprite2D = Sprite.Create(item.icon, new Rect(0, 0, 56, 56), Vector2.up);

            var childs = new List<GameObject>();
            foreach (Transform child in newSlot.transform)
            {
                childs.Add(child.gameObject);
            }
            var lbl_name = childs.FirstOrDefault(x => x.name == "lbl_name");
            lbl_name.GetComponent<UILabel>().text = item.name;

            var lbl_count = childs.FirstOrDefault(x => x.name == "lbl_count");
            lbl_count.GetComponent<UILabel>().text = item.count.ToString();

            var lbl_descr = childs.FirstOrDefault(x => x.name == "lbl_descr");
            lbl_descr.GetComponent<UILabel>().text = item.description;

            NGUITools.AddChild(inventoryGrid, newSlot);
        }
        

        //Reorder the grid
        inventoryGrid.GetComponent<UIGrid>().Reposition();
    }



    #region GUI

    //void OnGUI()
    //{
    //    if (ShowGUI)
    //    {
    //        windowRect = GUI.Window(0, windowRect, DoMyWindow, "Inventory");
    //        PlayerPrefs.SetFloat("InvWndX", windowRect.x);
    //        PlayerPrefs.SetFloat("InvWndY", windowRect.y);

    //    }
    //}

    //void DoMyWindow(int windowId)
    //{
    //    int y = 20;
    //    GUI.DragWindow(new Rect(0, 0, 300, 20));


    //    for (int i = 0; i < Inventory.Count; i++)
    //    {
    //        GUI.Button(new Rect(20, y, 64, 64), Inventory[i].icon);
    //        GUI.Label(new Rect(85, y, 150, 150), Inventory[i].name);
    //        GUI.Label(new Rect(85, y + 20, 200, 150), Inventory[i].description);
    //        GUI.Label(new Rect(85, y + 40, 200, 150), Inventory[i].count.ToString());
    //        y += 70;
    //    }
    //}


    #endregion
}
