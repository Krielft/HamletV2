using System.Collections;
using System.Collections.Generic;
using Hamlet.Game.Runtime.Player;
using Hamlet.Game.Runtime.PNJs;
using UnityEngine;

namespace Hamlet.Game.Runtime
{
    public class ForgeBuilding : MonoBehaviour
    {
        [SerializeField]
        ResourceData[] resourceData;
        [SerializeField]
        ToolData[] toolData;
        public int test;

        int rollSellPrice;
        float rollMultiplier;
        int rollBattlePower;

        /*public void GetItem(int type)
        {
            switch (type)
            {
                case 1:

                    if (Inventory.Instance.GetItemQuantity(resourceData[0], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[0], 3);
                        Inventory.Instance.AddItem(toolData[0], 1);
                    }
                    break;

                case 2:

                    if (Inventory.Instance.GetItemQuantity(resourceData[1], 3) && Inventory.Instance.GetItemQuantity(resourceData[0], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[1], 3);
                        Inventory.Instance.RemoveItem(resourceData[0], 3);
                        Inventory.Instance.AddItem(toolData[1], 1);
                    }
                    break;

                case 3:
                    if (Inventory.Instance.GetItemQuantity(resourceData[2], 3) && Inventory.Instance.GetItemQuantity(resourceData[1], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[2], 3);
                        Inventory.Instance.RemoveItem(resourceData[1], 3);
                        Inventory.Instance.AddItem(toolData[2], 1);
                    }

                    break;

                case 4:
                    if (Inventory.Instance.GetItemQuantity(resourceData[3], 3) && Inventory.Instance.GetItemQuantity(resourceData[2], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[3], 3);
                        Inventory.Instance.RemoveItem(resourceData[2], 3);
                        Inventory.Instance.AddItem(toolData[3], 1);
                    }
                    break;

                case 5:
                    if (Inventory.Instance.GetItemQuantity(resourceData[4], 3) && Inventory.Instance.GetItemQuantity(resourceData[3], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[4], 3);
                        Inventory.Instance.RemoveItem(resourceData[3], 3);
                        Inventory.Instance.AddItem(toolData[4], 1);
                    }
                    break;

                case 6:
                    if (Inventory.Instance.GetItemQuantity(resourceData[5], 3) && Inventory.Instance.GetItemQuantity(resourceData[4], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[5], 3);
                        Inventory.Instance.RemoveItem(resourceData[4], 3);
                        Inventory.Instance.AddItem(toolData[5], 1);
                    }
                    break;

                case 11:
                    if (Inventory.Instance.GetItemQuantity(resourceData[0], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[0], 3);
                        Inventory.Instance.AddItem(toolData[6], 1);
                    }
                    break;

                case 12:
                    if (Inventory.Instance.GetItemQuantity(resourceData[1], 3) && Inventory.Instance.GetItemQuantity(resourceData[0], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[0], 3);
                        Inventory.Instance.RemoveItem(resourceData[1], 3);
                        Inventory.Instance.AddItem(toolData[7], 1);
                    }
                    break;

                case 13:
                    if (Inventory.Instance.GetItemQuantity(resourceData[2], 3) && Inventory.Instance.GetItemQuantity(resourceData[1], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[1], 3);
                        Inventory.Instance.RemoveItem(resourceData[2], 3);
                        Inventory.Instance.AddItem(toolData[8], 1);
                    }
                    break;

                case 14:
                    if (Inventory.Instance.GetItemQuantity(resourceData[3], 3) && Inventory.Instance.GetItemQuantity(resourceData[2], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[2], 3);
                        Inventory.Instance.RemoveItem(resourceData[3], 3);
                        Inventory.Instance.AddItem(toolData[9], 1);
                    }
                    break;

                case 15:
                    if (Inventory.Instance.GetItemQuantity(resourceData[4], 3) && Inventory.Instance.GetItemQuantity(resourceData[3], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[3], 3);
                        Inventory.Instance.RemoveItem(resourceData[4], 3);
                        Inventory.Instance.AddItem(toolData[10], 1);
                    }
                    break;

                case 16:
                    if (Inventory.Instance.GetItemQuantity(resourceData[5], 3) && Inventory.Instance.GetItemQuantity(resourceData[4], 3))
                    {
                        Inventory.Instance.RemoveItem(resourceData[4], 3);
                        Inventory.Instance.RemoveItem(resourceData[5], 3);
                        Inventory.Instance.AddItem(toolData[11], 1);
                    }
                    break;



            }

            
            ///Inventory.Instance.GetItemQuantity(resourceData[0], 3);
            ///Inventory.Instance.RemoveItem(resourceData[0], 2);


        }*/

        public void Testitem(int lvl)
        {
            int l = lvl % 6;
            Debug.Log(l);

            if (l == 0)
                TestItemIron(0, lvl);

            else
                TestItemv2(l, lvl);

            /*if (lvl == 0 || lvl == 10 || lvl == 20 || lvl == 30 || lvl == 40 || lvl == 50 || lvl == 60 || lvl == 70 || lvl == 80)
            {
                TestItemIron(0, lvl);
            }

            else if (lvl == 1 || lvl == 11 || lvl == 21 || lvl == 31 || lvl == 41 || lvl == 51 || lvl == 61 || lvl == 71 || lvl == 81)
            {
                TestItemv2(1, lvl);
            }

            else if (lvl == 2 || lvl == 12 || lvl == 22 || lvl == 32 || lvl == 42 || lvl == 52 || lvl == 62 || lvl == 72 || lvl == 82)
            {
                TestItemv2(2, lvl);
            }

            else if (lvl == 3 || lvl == 13 || lvl == 23 || lvl == 33 || lvl == 43 || lvl == 53 || lvl == 63 || lvl == 73 || lvl == 83)
            {
                TestItemv2(3, lvl);
            }

            else if (lvl == 4 || lvl == 14 || lvl == 24 || lvl == 34 || lvl == 44 || lvl == 54 || lvl == 64 || lvl == 74 || lvl == 84)
            {
                TestItemv2(4, lvl);
            }

            else if (lvl == 5 || lvl == 15 || lvl == 25 || lvl == 35 || lvl == 45 || lvl == 55 || lvl == 65 || lvl == 75 || lvl == 85)
            {
                TestItemv2(5, lvl);
            }*/

            /*switch (lvl)
            {
                case 0:
                    TestItemIron(0, lvl);
                    break;

                case 1:
                    TestItemv2(1, lvl);
                    break;

                case 2:
                    TestItemv2(2, lvl);
                    break;

                case 3:
                    TestItemv2(3, lvl);
                    break;

                case 4:
                    TestItemv2(4, lvl);
                    break;

                case 5:
                    TestItemv2(5, lvl);
                    break;
            }*/
        }

        public void TestItemIron(int res, int lvl)
        {
            if (Inventory.Instance.HasEnoughResources(resourceData[res], 3))
            {
                Inventory.Instance.RemoveItem(resourceData[res], 3);
                //Inventory.Instance.AddItem(toolData[lvl], 1);
                ToolCraft(lvl, 0);
            }
        }

        public void TestItemv2(int res, int lvl)
        {
            Debug.Log("TestItem recu");
            if (Inventory.Instance.HasEnoughResources(resourceData[res], 3) && Inventory.Instance.HasEnoughResources(resourceData[res-1], 3))
            {
                Inventory.Instance.RemoveItem(resourceData[res], 3);
                Inventory.Instance.RemoveItem(resourceData[res - 1], 3);

                ToolCraft(lvl, res);
                Debug.Log("toolcraft envoyé");

                //Inventory.Instance.AddItem(toolData[lvl], 1);
            }
        }

        public void ToolCraft(int lvl, int res)
        {


            if (res == 0)
            {
                rollSellPrice = 1;
                if (lvl >= 36)
                {
                    rollBattlePower = Random.Range(1, 10);
                    rollMultiplier = 0;
                }
                else
                {
                    rollBattlePower = 0;
                    rollMultiplier = Random.Range(10, 15) / 10.0f;
                }

            }

            if (res == 1)
            {
                rollSellPrice = 2;
                
                if (lvl >= 36)
                {
                    rollBattlePower = Random.Range(11, 20);
                    rollMultiplier = 0;
                }
                    
                else
                {
                    rollMultiplier = Random.Range(12, 17) / 10.0f;
                    rollBattlePower = 0;
                }
                    
            }

            if (res == 2)
            {
                rollSellPrice = 3;
                
                if (lvl >= 36)
                {
                    rollBattlePower = Random.Range(21, 30);
                    rollMultiplier = 0;
                }
                    
                else
                {
                    rollMultiplier = Random.Range(15, 20) / 10.0f;
                    rollBattlePower = 0;
                }
                    
            }

            if (res == 3)
            {
                rollSellPrice = 4;
                
                if (lvl >= 36)
                {
                    rollBattlePower = Random.Range(31, 50);
                    rollMultiplier = 0;
                }

                else
                {
                    rollMultiplier = Random.Range(17, 23) / 10.0f;
                    rollBattlePower = 0;
                }
                    
            }

            if (res == 4)
            {
                rollSellPrice = 5;
                
                if (lvl >= 36)
                {
                    rollBattlePower = Random.Range(51, 70);
                    rollMultiplier = 0;
                }
                    
                else
                {
                    rollMultiplier = Random.Range(20, 30) / 10.0f;
                    rollBattlePower = 0;
                }
                    
            }

            if (res == 5)
            {
                rollSellPrice = 6;
                
                if (lvl >= 36)
                {
                    rollBattlePower = Random.Range(71, 100);
                    rollMultiplier = 0;
                }

                else
                {
                    rollMultiplier = Random.Range(25, 35) / 10.0f;
                    rollBattlePower = 0;
                }
                    
            }


            int toolID = Inventory.Instance.Tools.Count;

            Tool toolInstance = new(toolData[lvl].name, rollMultiplier, rollSellPrice, toolID, rollBattlePower );

            Inventory.Instance.AddToolToInventory(toolInstance);

            Debug.Log($"Votre {toolData[lvl].name} a un multiplicateur : {rollMultiplier} et son BattlePower : {rollBattlePower}");


        }
    }
}
