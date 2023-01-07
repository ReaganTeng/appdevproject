using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    public enum InventoryType
    {
        HAT,
        CHEST,
        WEAPON,
        SHOE
    }

    public InventoryType Type;
    [SerializeField] private GameObject Select;
    [SerializeField] private Image InventoryHeader;
    Inventory inventory;
    [SerializeField] private List<GameObject> slots;

    //Text
    public GameObject nameText;
    public GameObject rarityAndTypeText;
    public GameObject armorOrAttackText;
    public GameObject modifiersText;

    //equip slots
    private GameObject hatEquip;
    private GameObject chestEquip;
    private GameObject weaponEquip;
    private GameObject shoeEquip;

    //change page
    private GameObject nextPage;
    private GameObject prevPage;
    private int page;

    // Start is called before the first frame update
    void Start()
    {
        Type = InventoryType.HAT;
        Select = GameObject.Find("Select Indicator");
        InventoryHeader = GameObject.Find("Header Indicator").GetComponent<Image>();
        inventory = Inventory.instance;

        //Text
        nameText = GameObject.Find("Name");
        nameText.SetActive(false);
        rarityAndTypeText = GameObject.Find("Rarity/Type");
        rarityAndTypeText.SetActive(false);
        armorOrAttackText = GameObject.Find("Armor/Attack");
        armorOrAttackText.SetActive(false);
        modifiersText = GameObject.Find("Modifiers");
        modifiersText.SetActive(false);

        //equip slots
        hatEquip = GameObject.Find("HatEquipDisplay");
        chestEquip = GameObject.Find("ChestEquipDisplay");
        weaponEquip = GameObject.Find("WeaponEquipDisplay");
        shoeEquip = GameObject.Find("ShoeEquipDisplay");

        //change page buttons
        nextPage = GameObject.Find("NextPageButton");
        prevPage = GameObject.Find("PrevPageButton");
        ResetPage();

        UpdateEquipmentDisplay();
    }

    private void DisableTextDisplay()
    {
        nameText.SetActive(false);
        rarityAndTypeText.SetActive(false);
        armorOrAttackText.SetActive(false);
        modifiersText.SetActive(false);
    }

    private void ActivateTextDisplay()
    {
        nameText.SetActive(true);
        rarityAndTypeText.SetActive(true);
        armorOrAttackText.SetActive(true);
        modifiersText.SetActive(true);
    }

    private void UpdateEquipmentDisplay()
    {
        //equip slots display
        if (CharacterInScene.SceneCharacter.hat == null)
        {
            hatEquip.SetActive(false);
        }
        else
        {
            hatEquip.SetActive(true);

            //set background
            if (CharacterInScene.SceneCharacter.hat.rarity == Equipment.Rarity.COMMON)
            {
                hatEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Grey");
            }
            else if (CharacterInScene.SceneCharacter.hat.rarity == Equipment.Rarity.UNCOMMON)
            {
                hatEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Green");
            }
            else if (CharacterInScene.SceneCharacter.hat.rarity == Equipment.Rarity.RARE)
            {
                hatEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Blue");
            }

            //set icon
            hatEquip.transform.Find("Icon").GetComponent<Image>().sprite = CharacterInScene.SceneCharacter.hat.icon;
        }

        if (CharacterInScene.SceneCharacter.chest == null)
        {
            chestEquip.SetActive(false);
        }
        else
        {
            chestEquip.SetActive(true);

            //set background
            if (CharacterInScene.SceneCharacter.chest.rarity == Equipment.Rarity.COMMON)
            {
                chestEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Grey");
            }
            else if (CharacterInScene.SceneCharacter.chest.rarity == Equipment.Rarity.UNCOMMON)
            {
                chestEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Green");
            }
            else if (CharacterInScene.SceneCharacter.chest.rarity == Equipment.Rarity.RARE)
            {
                chestEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Blue");
            }

            //set icon
            chestEquip.transform.Find("Icon").GetComponent<Image>().sprite = CharacterInScene.SceneCharacter.chest.icon;
        }

        if (CharacterInScene.SceneCharacter.weapon == null)
        {
            weaponEquip.SetActive(false);
        }
        else
        {
            weaponEquip.SetActive(true);

            //set background
            if (CharacterInScene.SceneCharacter.weapon.rarity == Equipment.Rarity.COMMON)
            {
                weaponEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Grey");
            }
            else if (CharacterInScene.SceneCharacter.weapon.rarity == Equipment.Rarity.UNCOMMON)
            {
                weaponEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Green");
            }
            else if (CharacterInScene.SceneCharacter.weapon.rarity == Equipment.Rarity.RARE)
            {
                weaponEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Blue");
            }

            //set icon
            weaponEquip.transform.Find("Icon").GetComponent<Image>().sprite = CharacterInScene.SceneCharacter.weapon.icon;
        }

        if (CharacterInScene.SceneCharacter.shoe == null)
        {
            shoeEquip.SetActive(false);
        }
        else
        {
            shoeEquip.SetActive(true);

            //set background
            if (CharacterInScene.SceneCharacter.shoe.rarity == Equipment.Rarity.COMMON)
            {
                shoeEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Grey");
            }
            else if (CharacterInScene.SceneCharacter.shoe.rarity == Equipment.Rarity.UNCOMMON)
            {
                shoeEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Green");
            }
            else if (CharacterInScene.SceneCharacter.shoe.rarity == Equipment.Rarity.RARE)
            {
                shoeEquip.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Blue");
            }

            //set icon
            shoeEquip.transform.Find("Icon").GetComponent<Image>().sprite = CharacterInScene.SceneCharacter.shoe.icon;
        }

        //inventory display
        if (slots.Count > 0)
        {
            if (Type == InventoryType.HAT)
            {
                for (int i = 0; i < slots.Count; ++i)
                {
                    if (inventory.HatList.Count > i + ((page - 1) * 4))
                    {
                        //set background
                        if (inventory.HatList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.COMMON)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Grey");
                            slots[i].SetActive(true);
                        }
                        else if (inventory.HatList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.UNCOMMON)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Green");
                            slots[i].SetActive(true);
                        }
                        else if (inventory.HatList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.RARE)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Blue");
                            slots[i].SetActive(true);
                        }

                        //set icon
                        slots[i].transform.Find("Icon").GetComponent<Image>().sprite = inventory.HatList[i + ((page - 1) * 4)].icon;
                    }
                    else
                    {
                        slots[i].SetActive(false);
                    }
                }
            }
            else if (Type == InventoryType.CHEST)
            {
                for (int i = 0; i < slots.Count; ++i)
                {
                    if (inventory.HatList.Count > i + ((page - 1) * 4))
                    {
                        //set background
                        if (inventory.ChestList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.COMMON)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Grey");
                            slots[i].SetActive(true);
                        }
                        else if (inventory.ChestList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.UNCOMMON)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Green");
                            slots[i].SetActive(true);
                        }
                        else if (inventory.ChestList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.RARE)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Blue");
                            slots[i].SetActive(true);
                        }

                        //set icon
                        slots[i].transform.Find("Icon").GetComponent<Image>().sprite = inventory.ChestList[i + ((page - 1) * 4)].icon;
                    }
                    else
                    {
                        slots[i].SetActive(false);
                    }
                }
            }
            else if (Type == InventoryType.WEAPON)
            {
                for (int i = 0; i < slots.Count; ++i)
                {
                    if (inventory.WeaponList.Count > i + ((page - 1) * 4))
                    {
                        //set background
                        if (inventory.WeaponList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.COMMON)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Grey");
                            slots[i].SetActive(true);
                        }
                        else if (inventory.WeaponList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.UNCOMMON)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Green");
                            slots[i].SetActive(true);
                        }
                        else if (inventory.WeaponList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.RARE)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Blue");
                            slots[i].SetActive(true);
                        }

                        //set icon
                        slots[i].transform.Find("Icon").GetComponent<Image>().sprite = inventory.WeaponList[i + ((page - 1) * 4)].icon;
                    }
                    else
                    {
                        slots[i].SetActive(false);
                    }
                }
            }
            else if (Type == InventoryType.SHOE)
            {
                for (int i = 0; i < slots.Count; ++i)
                {
                    if (inventory.ShoeList.Count > i + ((page - 1) * 4))
                    {
                        //set background
                        if (inventory.ShoeList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.COMMON)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Grey");
                            slots[i].SetActive(true);
                        }
                        else if (inventory.ShoeList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.UNCOMMON)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Green");
                            slots[i].SetActive(true);
                        }
                        else if (inventory.ShoeList[i + ((page - 1) * 4)].rarity == Equipment.Rarity.RARE)
                        {
                            slots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Blue");
                            slots[i].SetActive(true);
                        }

                        //set icon
                        slots[i].transform.Find("Icon").GetComponent<Image>().sprite = inventory.ShoeList[i + ((page - 1) * 4)].icon;
                    }
                    else
                    {
                        slots[i].SetActive(false);
                    }
                }
            }
        }
        else
        {
            Debug.Log("The number of slots is not more than 0");
        }
    }

    public void MoveSelect(GameObject moveto)
    {
        Color commonColor = new Color(0.8f, 0.8f, 0.8f);
        Color uncommonColor = Color.green;
        Color rareColor = Color.blue;

        //had to make the select indicator a child because dragging wouldn't work if not
        Select.transform.position = moveto.transform.position;
        Select.transform.SetParent(moveto.transform);
        Select.transform.SetAsFirstSibling();

        //check if user pressed one of the equipment slots for the character
        if (moveto.name == "Hat Background")
        {
            Type = InventoryType.HAT;
            InventoryHeader.sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Hat");
            UpdateEquipmentDisplay();
            DisableTextDisplay();
            ResetPage();
        }
        else if (moveto.name == "Chest Background")
        {
            Type = InventoryType.CHEST;
            InventoryHeader.sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Chest");
            UpdateEquipmentDisplay();
            DisableTextDisplay();
            ResetPage();
        }
        else if (moveto.name == "Weapon Background")
        {
            Type = InventoryType.WEAPON;
            InventoryHeader.sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Weapon");
            UpdateEquipmentDisplay();
            DisableTextDisplay();
            ResetPage();
        }
        else if (moveto.name == "Shoe Background")
        {
            Type = InventoryType.SHOE;
            InventoryHeader.sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Shoe");
            UpdateEquipmentDisplay();
            DisableTextDisplay();
            ResetPage();
        }
        //if an item is equipped
        else if (moveto == hatEquip)
        {
            Type = InventoryType.HAT;
            InventoryHeader.sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Hat");
            UpdateEquipmentDisplay();
            ResetPage();

            //text update
            if (CharacterInScene.SceneCharacter.hat != null)
            {
                nameText.GetComponent<Text>().text = CharacterInScene.SceneCharacter.hat.Name;

                if (CharacterInScene.SceneCharacter.hat.rarity == Equipment.Rarity.COMMON)
                {
                    rarityAndTypeText.GetComponent<Text>().color = commonColor; //grey
                    rarityAndTypeText.GetComponent<Text>().text = "Common Headpiece";
                }
                else if (CharacterInScene.SceneCharacter.hat.rarity == Equipment.Rarity.UNCOMMON)
                {
                    rarityAndTypeText.GetComponent<Text>().color = uncommonColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Uncommon Headpiece";
                }
                else if (CharacterInScene.SceneCharacter.hat.rarity == Equipment.Rarity.RARE)
                {
                    rarityAndTypeText.GetComponent<Text>().color = rareColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Rare Headpiece";
                }

                armorOrAttackText.GetComponent<Text>().text = "Armor: " + CharacterInScene.SceneCharacter.hat.armor;
                modifiersText.GetComponent<Text>().text = "Modifiers:";


                if (CharacterInScene.SceneCharacter.hat.extraStrength != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Strength +" + CharacterInScene.SceneCharacter.hat.extraStrength;
                }
                if (CharacterInScene.SceneCharacter.hat.extraIntelligence != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Intelligence +" + CharacterInScene.SceneCharacter.hat.extraIntelligence;
                }
                if (CharacterInScene.SceneCharacter.hat.extraAgility != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Agility +" + CharacterInScene.SceneCharacter.hat.extraAgility;
                }
                if (CharacterInScene.SceneCharacter.hat.extraVitality != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Vitality +" + CharacterInScene.SceneCharacter.hat.extraVitality;
                }
                if (CharacterInScene.SceneCharacter.hat.extraLuck != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Luck +" + CharacterInScene.SceneCharacter.hat.extraLuck;
                }
                ActivateTextDisplay();
            }
        }
        else if (moveto == chestEquip)
        {
            Type = InventoryType.CHEST;
            InventoryHeader.sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Chest");
            UpdateEquipmentDisplay();
            ResetPage();

            //text update
            if (CharacterInScene.SceneCharacter.chest != null)
            {
                nameText.GetComponent<Text>().text = CharacterInScene.SceneCharacter.chest.Name;

                if (CharacterInScene.SceneCharacter.chest.rarity == Equipment.Rarity.COMMON)
                {
                    rarityAndTypeText.GetComponent<Text>().color = commonColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Common Headpiece";
                }
                else if (CharacterInScene.SceneCharacter.chest.rarity == Equipment.Rarity.UNCOMMON)
                {
                    rarityAndTypeText.GetComponent<Text>().color = uncommonColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Uncommon Headpiece";
                }
                else if (CharacterInScene.SceneCharacter.chest.rarity == Equipment.Rarity.RARE)
                {
                    rarityAndTypeText.GetComponent<Text>().color = rareColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Rare Headpiece";
                }

                armorOrAttackText.GetComponent<Text>().text = "Armor: " + CharacterInScene.SceneCharacter.chest.armor;
                modifiersText.GetComponent<Text>().text = "Modifiers:";


                if (CharacterInScene.SceneCharacter.chest.extraStrength != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Strength +" + CharacterInScene.SceneCharacter.chest.extraStrength;
                }
                if (CharacterInScene.SceneCharacter.chest.extraIntelligence != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Intelligence +" + CharacterInScene.SceneCharacter.chest.extraIntelligence;
                }
                if (CharacterInScene.SceneCharacter.chest.extraAgility != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Agility +" + CharacterInScene.SceneCharacter.chest.extraAgility;
                }
                if (CharacterInScene.SceneCharacter.chest.extraVitality != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Vitality +" + CharacterInScene.SceneCharacter.chest.extraVitality;
                }
                if (CharacterInScene.SceneCharacter.chest.extraLuck != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Luck +" + CharacterInScene.SceneCharacter.chest.extraLuck;
                }
                ActivateTextDisplay();
            }
        }
        else if (moveto == weaponEquip)
        {
            Type = InventoryType.WEAPON;
            InventoryHeader.sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Weapon");
            UpdateEquipmentDisplay();
            ResetPage();

            //text update
            if (CharacterInScene.SceneCharacter.weapon != null)
            {
                nameText.GetComponent<Text>().text = CharacterInScene.SceneCharacter.weapon.Name;

                if (CharacterInScene.SceneCharacter.weapon.rarity == Equipment.Rarity.COMMON)
                {
                    rarityAndTypeText.GetComponent<Text>().color = commonColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Common Weapon";
                }
                else if (CharacterInScene.SceneCharacter.weapon.rarity == Equipment.Rarity.UNCOMMON)
                {
                    rarityAndTypeText.GetComponent<Text>().color = uncommonColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Uncommon Weapon";
                }
                else if (CharacterInScene.SceneCharacter.weapon.rarity == Equipment.Rarity.RARE)
                {
                    rarityAndTypeText.GetComponent<Text>().color = rareColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Rare Weapon";
                }

                armorOrAttackText.GetComponent<Text>().text = "Attack: " + CharacterInScene.SceneCharacter.weapon.attack;
                modifiersText.GetComponent<Text>().text = "Modifiers:";


                if (CharacterInScene.SceneCharacter.weapon.extraStrength != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Strength +" + CharacterInScene.SceneCharacter.weapon.extraStrength;
                }
                if (CharacterInScene.SceneCharacter.weapon.extraIntelligence != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Intelligence +" + CharacterInScene.SceneCharacter.weapon.extraIntelligence;
                }
                if (CharacterInScene.SceneCharacter.weapon.extraAgility != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Agility +" + CharacterInScene.SceneCharacter.weapon.extraAgility;
                }
                if (CharacterInScene.SceneCharacter.weapon.extraVitality != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Vitality +" + CharacterInScene.SceneCharacter.weapon.extraVitality;
                }
                if (CharacterInScene.SceneCharacter.weapon.extraLuck != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Luck +" + CharacterInScene.SceneCharacter.weapon.extraLuck;
                }
                ActivateTextDisplay();
            }
        }
        else if (moveto == shoeEquip)
        {
            Type = InventoryType.SHOE;
            InventoryHeader.sprite = Resources.Load<Sprite>("Images/Equipment_Assets/Shoe");
            UpdateEquipmentDisplay();
            ResetPage();

            //text update
            if (CharacterInScene.SceneCharacter.shoe != null)
            {
                nameText.GetComponent<Text>().text = CharacterInScene.SceneCharacter.shoe.Name;

                if (CharacterInScene.SceneCharacter.shoe.rarity == Equipment.Rarity.COMMON)
                {
                    rarityAndTypeText.GetComponent<Text>().color = commonColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Common Headpiece";
                }
                else if (CharacterInScene.SceneCharacter.shoe.rarity == Equipment.Rarity.UNCOMMON)
                {
                    rarityAndTypeText.GetComponent<Text>().color = uncommonColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Uncommon Headpiece";
                }
                else if (CharacterInScene.SceneCharacter.shoe.rarity == Equipment.Rarity.RARE)
                {
                    rarityAndTypeText.GetComponent<Text>().color = rareColor;
                    rarityAndTypeText.GetComponent<Text>().text = "Rare Headpiece";
                }

                armorOrAttackText.GetComponent<Text>().text = "Armor: " + CharacterInScene.SceneCharacter.shoe.armor;
                modifiersText.GetComponent<Text>().text = "Modifiers:";


                if (CharacterInScene.SceneCharacter.shoe.extraStrength != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Strength +" + CharacterInScene.SceneCharacter.shoe.extraStrength;
                }
                if (CharacterInScene.SceneCharacter.shoe.extraIntelligence != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Intelligence +" + CharacterInScene.SceneCharacter.shoe.extraIntelligence;
                }
                if (CharacterInScene.SceneCharacter.shoe.extraAgility != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Agility +" + CharacterInScene.SceneCharacter.shoe.extraAgility;
                }
                if (CharacterInScene.SceneCharacter.shoe.extraVitality != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Vitality +" + CharacterInScene.SceneCharacter.shoe.extraVitality;
                }
                if (CharacterInScene.SceneCharacter.shoe.extraLuck != 0)
                {
                    modifiersText.GetComponent<Text>().text += "\n Luck +" + CharacterInScene.SceneCharacter.shoe.extraLuck;
                }
                ActivateTextDisplay();
            }
        }
        //if an inventory slot is seleted
        else
        {
            if (Type == InventoryType.HAT)
            {
                for (int i = 0; i < slots.Count; ++i)
                {
                    if (slots[i] == moveto)
                    {
                        Hat temp = inventory.HatList[i + ((page - 1) * 4)];

                        nameText.GetComponent<Text>().text = temp.Name;

                        if (temp.rarity == Equipment.Rarity.COMMON)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = commonColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Common Hat";
                        }
                        else if (temp.rarity == Equipment.Rarity.UNCOMMON)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = uncommonColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Uncommon Hat";
                        }
                        else if (temp.rarity == Equipment.Rarity.RARE)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = rareColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Rare Hat";
                        }

                        armorOrAttackText.GetComponent<Text>().text = "Attack: " + temp.armor;
                        modifiersText.GetComponent<Text>().text = "Modifiers:";


                        if (temp.extraStrength != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Strength +" + temp.extraStrength;
                        }
                        if (temp.extraIntelligence != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Intelligence +" + temp.extraIntelligence;
                        }
                        if (temp.extraAgility != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Agility +" + temp.extraAgility;
                        }
                        if (temp.extraVitality != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Vitality +" + temp.extraVitality;
                        }
                        if (temp.extraLuck != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Luck +" + temp.extraLuck;
                        }
                        ActivateTextDisplay();

                        break;
                    }
                }
            }
            else if (Type == InventoryType.CHEST)
            {
                for (int i = 0; i < slots.Count; ++i)
                {
                    if (slots[i] == moveto)
                    {
                        Chest temp = inventory.ChestList[i + ((page - 1) * 4)];

                        nameText.GetComponent<Text>().text = temp.Name;

                        if (temp.rarity == Equipment.Rarity.COMMON)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = commonColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Common Chest";
                        }
                        else if (temp.rarity == Equipment.Rarity.UNCOMMON)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = uncommonColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Uncommon Chest";
                        }
                        else if (temp.rarity == Equipment.Rarity.RARE)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = rareColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Rare Chest";
                        }

                        armorOrAttackText.GetComponent<Text>().text = "Attack: " + temp.armor;
                        modifiersText.GetComponent<Text>().text = "Modifiers:";


                        if (temp.extraStrength != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Strength +" + temp.extraStrength;
                        }
                        if (temp.extraIntelligence != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Intelligence +" + temp.extraIntelligence;
                        }
                        if (temp.extraAgility != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Agility +" + temp.extraAgility;
                        }
                        if (temp.extraVitality != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Vitality +" + temp.extraVitality;
                        }
                        if (temp.extraLuck != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Luck +" + temp.extraLuck;
                        }
                        ActivateTextDisplay();

                        break;
                    }
                }
            }
            else if (Type == InventoryType.WEAPON)
            {
                for (int i = 0; i < slots.Count; ++i)
                {
                    if (slots[i] == moveto)
                    {
                        Weapon temp = inventory.WeaponList[i + ((page - 1) * 4)];

                        nameText.GetComponent<Text>().text = temp.Name;

                        if (temp.rarity == Equipment.Rarity.COMMON)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = commonColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Common Weapon";
                        }
                        else if (temp.rarity == Equipment.Rarity.UNCOMMON)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = uncommonColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Uncommon Weapon";
                        }
                        else if (temp.rarity == Equipment.Rarity.RARE)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = rareColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Rare Weapon";
                        }

                        armorOrAttackText.GetComponent<Text>().text = "Attack: " + temp.attack;
                        modifiersText.GetComponent<Text>().text = "Modifiers:";


                        if (temp.extraStrength != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Strength +" + temp.extraStrength;
                        }
                        if (temp.extraIntelligence != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Intelligence +" + temp.extraIntelligence;
                        }
                        if (temp.extraAgility != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Agility +" + temp.extraAgility;
                        }
                        if (temp.extraVitality != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Vitality +" + temp.extraVitality;
                        }
                        if (temp.extraLuck != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Luck +" + temp.extraLuck;
                        }
                        ActivateTextDisplay();

                        break;
                    }
                }
            }
            else //shoe
            {
                for (int i = 0; i < slots.Count; ++i)
                {
                    if (slots[i] == moveto)
                    {
                        Shoe temp = inventory.ShoeList[i + ((page - 1) * 4)];

                        nameText.GetComponent<Text>().text = temp.Name;

                        if (temp.rarity == Equipment.Rarity.COMMON)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = commonColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Common Shoe";
                        }
                        else if (temp.rarity == Equipment.Rarity.UNCOMMON)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = uncommonColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Uncommon Shoe";
                        }
                        else if (temp.rarity == Equipment.Rarity.RARE)
                        {
                            rarityAndTypeText.GetComponent<Text>().color = rareColor;
                            rarityAndTypeText.GetComponent<Text>().text = "Rare Shoe";
                        }

                        armorOrAttackText.GetComponent<Text>().text = "Attack: " + temp.armor;
                        modifiersText.GetComponent<Text>().text = "Modifiers:";


                        if (temp.extraStrength != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Strength +" + temp.extraStrength;
                        }
                        if (temp.extraIntelligence != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Intelligence +" + temp.extraIntelligence;
                        }
                        if (temp.extraAgility != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Agility +" + temp.extraAgility;
                        }
                        if (temp.extraVitality != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Vitality +" + temp.extraVitality;
                        }
                        if (temp.extraLuck != 0)
                        {
                            modifiersText.GetComponent<Text>().text += "\n Luck +" + temp.extraLuck;
                        }
                        ActivateTextDisplay();

                        break;
                    }
                }
            }
        }
    }


    public void Drag(GameObject temp)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (temp.transform.parent.parent.name == "Inventory Border")
        {
            temp.transform.parent.parent.SetAsLastSibling();
        }
        else
        {
            temp.transform.parent.SetAsLastSibling();
        }
        Vector2 temp2 = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        temp.transform.position = temp2;
#else
        if (temp.transform.parent.parent.name == "Inventory Border")
        {
            temp.transform.parent.parent.SetAsLastSibling();
        }
        else
        {
            temp.transform.parent.SetAsLastSibling();
        }
        Vector2 temp2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        temp.transform.position = temp2;
#endif
    }

    public void DropToEquip(GameObject temp)
    {
        RectTransform currentPanel = temp.transform.parent.GetComponent<RectTransform>();
        RectTransform dropPanel;
        GameObject moveToObject = null;
        Vector2 pointerLocation;

#if UNITY_ANDROID && !UNITY_EDITOR
        pointerLocation =   Input.GetTouch(0).position;
#else
        pointerLocation = Input.mousePosition;
#endif

        //find current dropPanel
        if (Type == InventoryType.HAT)
        {
            dropPanel = GameObject.Find("Hat Background").GetComponent<RectTransform>();
        }
        else if (Type == InventoryType.CHEST)
        {
            dropPanel = GameObject.Find("Chest Background").GetComponent<RectTransform>();
        }
        else if (Type == InventoryType.WEAPON)
        {
            dropPanel = GameObject.Find("Weapon Background").GetComponent<RectTransform>();
        }
        else
        {
            dropPanel = GameObject.Find("Shoe Background").GetComponent<RectTransform>();
        }

        //remove the equipped item if pointer is outside of the rectTransform
        if (RectTransformUtility.RectangleContainsScreenPoint(dropPanel, pointerLocation, Camera.main))
        {
            for (int i = 0; i < slots.Count; ++i)
            {
                if (slots[i] == temp)
                {
                    if (Type == InventoryType.HAT)
                    {
                        moveToObject = hatEquip;
                        Hat HatToEquip = inventory.HatList[i + ((page - 1) * 4)];
                        CharacterInScene.SceneCharacter.hat = HatToEquip;
                        inventory.HatList.Remove(HatToEquip);
                        break;
                    }
                    else if (Type == InventoryType.CHEST)
                    {
                        moveToObject = chestEquip;
                        Chest ChestToEquip = inventory.ChestList[i + ((page - 1) * 4)];
                        CharacterInScene.SceneCharacter.chest = ChestToEquip;
                        inventory.ChestList.Remove(ChestToEquip);
                        break;
                    }
                    else if (Type == InventoryType.WEAPON)
                    {
                        moveToObject = weaponEquip;
                        Weapon WeaponToEquip = inventory.WeaponList[i + ((page - 1) * 4)];
                        CharacterInScene.SceneCharacter.weapon = WeaponToEquip;
                        inventory.WeaponList.Remove(WeaponToEquip);
                        break;
                    }
                    else
                    {
                        moveToObject = shoeEquip;
                        Shoe ShoeToEquip = inventory.ShoeList[i + ((page - 1) * 4)];
                        CharacterInScene.SceneCharacter.shoe = ShoeToEquip;
                        inventory.ShoeList.Remove(ShoeToEquip);
                        break;
                    }
                }
            }
            temp.transform.localPosition = Vector2.zero;
            MoveSelect(moveToObject);
            UpdateEquipmentDisplay();
        }
        else
        {
            temp.transform.localPosition = Vector2.zero;
        }
    }

    public void DropFromEquip(GameObject temp)
    {
        RectTransform currentPanel = temp.transform.parent.GetComponent<RectTransform>();
        Vector2 pointerLocation;

#if UNITY_ANDROID && !UNITY_EDITOR
        pointerLocation =  Input.GetTouch(0).position;
#else
        pointerLocation = Input.mousePosition;
#endif

        if (Type == InventoryType.HAT)
        {
            if (hatEquip.activeSelf)
            {
                if (!RectTransformUtility.RectangleContainsScreenPoint(currentPanel, pointerLocation, Camera.main))
                {
                    CharacterInScene.SceneCharacter.unequipHat();
                    DisableTextDisplay();
                }
            }
        }
        else if (Type == InventoryType.CHEST)
        {
            if (chestEquip.activeSelf)
            {
                if (!RectTransformUtility.RectangleContainsScreenPoint(currentPanel, pointerLocation, Camera.main))
                {
                    CharacterInScene.SceneCharacter.unequipChest();
                    DisableTextDisplay();
                }
            }
        }
        else if (Type == InventoryType.WEAPON)
        {
            if (weaponEquip.activeSelf)
            {
                if (!RectTransformUtility.RectangleContainsScreenPoint(currentPanel, pointerLocation, Camera.main))
                {
                    CharacterInScene.SceneCharacter.unequipWeapon();
                    DisableTextDisplay();
                }
            }
        }
        else
        {
            if (shoeEquip.activeSelf)
            {
                if (!RectTransformUtility.RectangleContainsScreenPoint(currentPanel, pointerLocation, Camera.main))
                {
                    CharacterInScene.SceneCharacter.unequipShoe();
                    DisableTextDisplay();
                }
            }
        }
        temp.transform.localPosition = Vector2.zero;
        UpdateEquipmentDisplay();
    }

    public void GoTocharacter()
    {
        CharacterInScene.instance.SaveStats();
        SceneManager.LoadScene("Character");
    }

    private void ResetPage()
    {
        int lastPage;
        page = 1;

        if (Type == InventoryType.HAT)
        {
            lastPage = (int)((inventory.HatList.Count / 4) + 1);
        }
        else if (Type == InventoryType.CHEST)
        {
            lastPage = (int)((inventory.ChestList.Count / 4) + 1);
        }
        else if (Type == InventoryType.WEAPON)
        {
            lastPage = (int)((inventory.WeaponList.Count / 4) + 1);
        }
        else
        {
            lastPage = (int)((inventory.ShoeList.Count / 4) + 1);
        }

        if (page != lastPage)
        {
            nextPage.SetActive(true);
        }
        else
        {
            nextPage.SetActive(false);
        }

        prevPage.SetActive(false);
    }

    public void GoToNextPage()
    {
        int lastPage;
        prevPage.SetActive(true);

        if (Type == InventoryType.HAT)
        {
            lastPage = (int)((inventory.HatList.Count / 4) + 1);
        }
        else if (Type == InventoryType.CHEST)
        {
            lastPage = (int)((inventory.ChestList.Count / 4) + 1);
        }
        else if (Type == InventoryType.WEAPON)
        {
            lastPage = (int)((inventory.WeaponList.Count / 4) + 1);
        }
        else
        {
            lastPage = (int)((inventory.ShoeList.Count / 4) + 1);
        }

        if (page < lastPage)
        {
            ++page;
            if (page == lastPage)
            {
                nextPage.SetActive(false);
            }
            else
            {
                nextPage.SetActive(true);
            }
        }
        UpdateEquipmentDisplay();
    }

    public void GoToPrevPage()
    {
        nextPage.SetActive(true);

        if (page > 1)
        {
            --page;
            if (page == 1)
            {
                prevPage.SetActive(false);
            }
            else
            {
                prevPage.SetActive(true);
            }
        }
        UpdateEquipmentDisplay();
    }
}
