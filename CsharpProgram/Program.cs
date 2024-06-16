using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice = 0;
            int userQty = 0;
            int amount = 0;
            int totalAmount = 0;
            string userOrder = "";
            string userValue = "";
            string orderWillBe = "";
            string SelectedBeverage = "";
            string SelectedBeverageSize = "small";
            List<Bill> userBill = new List<Bill>();
            List<ColdMenu> ColdMenuData = new List<ColdMenu>();
            List<HotMenu> HotMenuData = new List<HotMenu>();
            List<UserSelectedBeverage> UserSelectedBeverages = new List<UserSelectedBeverage>();
            //Cold Menu Start Here
            ColdMenu menus = new ColdMenu();
            menus.menuNo = 1;
            menus.code = "CD001";
            menus.description = "Chocolate Shake";
            menus.rate = 170;
            ColdMenuData.Add(menus);
            ColdMenu menus1 = new ColdMenu();
            menus1.menuNo = 2;
            menus1.code = "CD002";
            menus1.description = "American Mudpie Shake";
            menus1.rate = 220;
            ColdMenuData.Add(menus1);
            ColdMenu menus2 = new ColdMenu();
            menus2.menuNo = 3;
            menus2.code = "CD003";
            menus2.description = "Hazelnut Brownie Shake";
            menus2.rate = 280;
            ColdMenuData.Add(menus2);
            //Cold Menu End Here


            //Hot Menu Start Here
            HotMenu hotmenu = new HotMenu();
            hotmenu.menuNo = 1;
            hotmenu.code = "HT001";
            hotmenu.description = "Americano";
            hotmenu.rate = 100;
            HotMenuData.Add(hotmenu);
            HotMenu hotmenu1 = new HotMenu();
            hotmenu1.menuNo = 2;
            hotmenu1.code = "HT002";
            hotmenu1.description = "Cappuccino";
            hotmenu1.rate = 150;
            HotMenuData.Add(hotmenu1);
            HotMenu hotmenu2 = new HotMenu();
            hotmenu2.menuNo = 3;
            hotmenu2.code = "HT003";
            hotmenu2.description = "Macchiato";
            hotmenu2.rate = 180;
            HotMenuData.Add(hotmenu2);
            //Hot Menu End Here

            //Console.WriteLine("Hello Good Morning!\nWhich Coffee Would You Like To Order?\n1-small\n2-Medium\n3-Large");
            Console.WriteLine("Hello Good Morning!");
            startOrder:
            Console.WriteLine("\nWhich Beverage Would You Like To Order Cold Or Hot?");
            SelectedBeverage = Console.ReadLine();
            //startOrder:
            if(SelectedBeverage.ToLower() == "hot")
            {
                //Console.WriteLine("Which Hot Beverages Would You Like To Order?\n1:- Small Cappicino   -100rs\n2:- Medium Cappicino -150rs\n3:- Large Cappicino  -180rs");
                //Console.WriteLine("\nHot Beverages Menu\n1:- Americano  -100rs\n2:- Cappuccino  -150rs\n3:- Macchiato  -180rs");
                //userChoice = int.Parse(Console.ReadLine());
                Console.WriteLine("\nHot Beverages Menu");
                Console.WriteLine("\n\nPlease Enter Product Srno");
                Console.WriteLine("\nSrno" + ("ProductCode").PadLeft(15).PadRight(19) + ("ProductName").PadRight(15) + "Rate");
                foreach (HotMenu h in HotMenuData)
                {
                    Console.WriteLine(h.menuNo + (h.code).PadLeft(15).PadRight(22) + (h.description).PadRight(15) + h.rate + "rs");
                }
                //userOrder = Console.ReadLine();
                userChoice = int.Parse(Console.ReadLine());
                List<HotMenu> filteredItems = HotMenuData.Where(item => item.menuNo == userChoice).ToList();
                if (filteredItems != null)
                {
                    userOrder = filteredItems[0].description;
                }
            }
            else if (SelectedBeverage.ToLower() == "cold")
            {
                //Console.WriteLine("\nCold Beverages Menu\n1:- Chocolate Shake   -170rs\n2:- American Mudpie Shake -220rs\n3:- Hazelnut Brownie Shake  -280rs");
                //userChoice = int.Parse(Console.ReadLine());
                Console.WriteLine("\nCold Beverages Menu");
                Console.WriteLine("\nPlease Enter Product Srno");
                Console.WriteLine("\nSrno"+ ("ProductCode").PadLeft(15).PadRight(19) + ("ProductName").PadRight(25) +"Rate");
                foreach (ColdMenu c in ColdMenuData)
                {
                    Console.WriteLine(c.menuNo + (c.code).PadLeft(15).PadRight(22) + (c.description).PadRight(25) + c.rate +"rs");
                }
                //userOrder = Console.ReadLine();
                userChoice = int.Parse(Console.ReadLine());
                List<ColdMenu> filteredItems = ColdMenuData.Where(item => item.menuNo == userChoice).ToList();
                if(filteredItems != null)
                {
                userOrder = filteredItems[0].description;
                }
            }
            else
            {
                Console.WriteLine("Please give valid answer");
                goto startOrder;
            }
            //Console.WriteLine("How much cup of coffee you want in {0}?", userOrder + " Cappicino");
            repeatSuggestion:
            if (SelectedBeverage.ToLower() == "hot" || SelectedBeverage.ToLower() == "cold")
            {
                Console.WriteLine("\nWould You like to Add More Qty in {0}?\n YES(y) or NO(n)", userOrder);
                //userQty = int.Parse(Console.ReadLine());
                string userData = Console.ReadLine();
                switch (userData.ToLower())
                {
                    case ("yes"):
                    case ("y"):
                        Console.WriteLine("\nHow Much Qty You Want in {0}?\n 1,2,3,4,5,6,7,8,9,10", userOrder);
                        userQty = int.Parse(Console.ReadLine());
                        break;
                    case ("no"):
                    case ("n"):
                        userQty = 1;
                        break;
                    default:
                        Console.WriteLine("Please give valid answer");
                        goto repeatSuggestion;
                }
            }
            if (userOrder != "")
            {
                if(SelectedBeverage.ToLower() == "hot")
                {
                Console.WriteLine("\nHot-Cup size will be\n S-Small \n M-Medium \n L-Large");
                }
                else if (SelectedBeverage.ToLower() == "cold")
                {
                    Console.WriteLine("\nCold-Cup size will be\n S-Small \n M-Medium \n L-Large");
                }
                SelectedBeverageSize = Console.ReadLine();
            }

            
            //userChoice = (userOrder.Trim()).ToLower() == "small" ? 1 : (userOrder.Trim()).ToLower() == "medium" ? 2 : 3;
            if (SelectedBeverage.ToLower() == "hot")
            {
                //userChoice = (userOrder.Trim()).ToLower() == "americano" ? 1 : (userOrder.Trim()).ToLower() == "cappuccino" ? 2 : 3;
                //amount = userChoice == 1 ? 100 : userChoice == 2 ? 150 : 180;
                foreach(HotMenu h in HotMenuData)
                {
                    if(h.description == userOrder)
                    {
                        amount = h.rate;
                    }
                }
            }
            else if (SelectedBeverage.ToLower() == "cold")
            {
                //userChoice = (userOrder.Trim()).ToLower() == "chocolate" ? 1 : (userOrder.Trim()).ToLower() == "american mudpie" ? 2 : 3;
                //amount = userChoice == 1 ? 170 : userChoice == 2 ? 220 : 280;
                foreach (ColdMenu c in ColdMenuData)
                {
                    if (c.description == userOrder)
                    {
                        amount = c.rate;
                    }
                }
            }
                int sumOfuserQty = userQty * amount;
            //totalAmount = amount + totalAmount;
            totalAmount = sumOfuserQty + totalAmount;

            // Dynamically add data to the userBill list
            Bill bill = new Bill();
            bill.Item = userOrder;
            bill.Qty = userQty;
            bill.Mrp = amount;

            userBill.Add(bill);

            //Console.WriteLine(userBill);

            repeat:
            if (userChoice > 0)
            {             
              Console.WriteLine("\nWould You Like To Order Any Other Beverages?\n YES(y) or NO(n)");
                userValue = Console.ReadLine();
            }
            orderWillBe:
            switch(userValue.ToLower())
            {
                case ("yes"):
                case ("y"):
                    goto startOrder;
                case ("no"):
                case ("n"):
                    Console.WriteLine("\nYour Order Will Be Dine-in(d) or Takeaway(t)");
                    orderWillBe = Console.ReadLine();                    
                    break;
                default:
                    Console.WriteLine("Please give valid answer");
                    goto repeat;
            }

            switch (orderWillBe.ToLower())
            {
                case ("dine-in"):
                case ("d"):
                    Console.WriteLine("\nYour Bill:\n");
                    foreach (var elmt in userBill)
                    {
                        Console.WriteLine("{0}", " Item: " + elmt.Item + ", Qty: " + elmt.Qty + ", Mrp: " + elmt.Mrp);
                    }
                    Console.WriteLine("\nYour Total Amount is: {0}", totalAmount + "rs");
                    Console.WriteLine("Thank You For Coming Visit Again..");
                    break;
                case ("takeaway"):
                case ("t"):
                    Console.WriteLine("\nYour Bill:\n");
                    foreach (var elmt in userBill)
                    {
                        Console.WriteLine("{0}", " Item: " + elmt.Item + ", Qty: " + elmt.Qty + ", Mrp: " + elmt.Mrp);
                    }
                    Console.WriteLine("\nYour Total Amount is: {0}", totalAmount + "rs");
                    Console.WriteLine("Thank You For Shopping With Us Visit Again..");
                    break;
                default:
                    Console.WriteLine("Please give valid answer");
                    goto orderWillBe;
            }
            //if (orderWillBe.ToLower() == "dine-in")
            //{
            //    Console.WriteLine("\nYour Bill:\n");
            //    foreach (var elmt in userBill)
            //    {
            //        Console.WriteLine("{0}", " Item: " + elmt.Item + ", Qty: " + elmt.Qty + ", Mrp: " + elmt.Mrp);
            //    }
            //    Console.WriteLine("\nYour Total Amount is: {0}", totalAmount + "rs");
            //    Console.WriteLine("Thank You For Coming Visit Again..");
            //}
            //else if (orderWillBe.ToLower() == "takeaway")
            //{
            //    Console.WriteLine("\nYour Bill:\n");
            //    foreach (var elmt in userBill)
            //    {
            //       Console.WriteLine("{0}", " Item: " + elmt.Item + ", Qty: " + elmt.Qty + ", Mrp: " + elmt.Mrp);
            //    }
            //    Console.WriteLine("\nYour Total Amount is: {0}", totalAmount + "rs");
            //    Console.WriteLine("Thank You For Shopping With Us Visit Again..");
            //}
        }
    }

    class Bill
    {
        public string Item { get; set; }
        public int Qty { get; set; } 
        public int Mrp { get; set; }
    }

    class ColdMenu
    {
        public int menuNo { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int rate { get; set; }
    }

    class HotMenu
    {
        public int menuNo { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int rate { get; set; }
    }

    class UserSelectedBeverage
    {
        public int menuNo { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int rate { get; set; }
    }
}
