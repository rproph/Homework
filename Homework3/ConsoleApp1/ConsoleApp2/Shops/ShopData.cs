using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class ShopData
    {
        public Shops[] Shops { get; set; }

        public void MakeBuyRequest()
        {
            while (true)
            {
                List<PhoneData> phoneList = new List<PhoneData>();
                int outOfStock = 0;
                string storeName;
                int stopper = 0;
                Console.WriteLine("Which mobile phone do you want to buy ?");

                string phoneName = Console.ReadLine();

                if (phoneName.ToLower().Equals("break"))
                {
                    break;
                }

                foreach (Shops shop in Shops)
                {
                    foreach (PhoneData phone in shop.Phones)
                    {
                        if (phoneName.ToLower().Equals(phone.Model.ToLower()) && phone.IsAvailable == true)
                        {
                            phoneList.Add(phone);

                            Console.WriteLine($"Shop id : {shop.Id},\nShop name : {shop.Name},\n{phone.DisplayPhone()}\n");
                        }
                        else if (phoneName.ToLower().Equals(phone.Model.ToLower()) && phone.IsAvailable == false)
                        {
                            Console.WriteLine($"This phone is out of stock in {shop.Name}\n");

                            outOfStock++;
                        }
                    }
                }

                try
                {
                    if (outOfStock > 1)
                    {
                        continue;
                    }
                    else if (phoneList.Count == 0)
                    {
                        Console.WriteLine("This mobile phone is not found");

                        throw new PhoneCannotBeDoundException("Phone cannot be found.");

                        continue;
                    }
                }
                catch (PhoneCannotBeDoundException ex)
                {
                    Console.WriteLine($"Error {ex.Message}.");
                }

                try
                {
                    while (true)
                    {
                        if (phoneList.Count > 1)
                        {
                            Console.WriteLine($"In which store do you want to buy the mobile phone { phoneName}");

                            storeName = Console.ReadLine();

                            foreach (Shops shop in Shops)
                            {
                                if (storeName.ToLower().Equals(shop.Name.ToLower()))
                                {
                                    Console.WriteLine($"Order for { phoneList[0].Model} ({ phoneList[0].OperationSystemType}), price ${ phoneList[0].Price}, market launch date { phoneList[0].MarketLaunchDate}, in shop {shop.Name} has been successfully placed.");

                                    stopper++;
                                }
                            }
                        }
                        else if (phoneList.Count == 1)
                        {
                            Console.WriteLine($"In which store do you want to buy the mobile phone { phoneName}");

                            storeName = Console.ReadLine();

                            foreach (Shops shop in Shops)
                            {
                                if (storeName.ToLower().Equals(shop.Name.ToLower()) && phoneList[0].ShopId == shop.Id)
                                {
                                    Console.WriteLine($"Order for { phoneList[0].Model} ({ phoneList[0].OperationSystemType}), price ${ phoneList[0].Price}, market launch date { phoneList[0].MarketLaunchDate}, in shop {shop.Name} has been successfully placed.");

                                    stopper++;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("This shop is not found.");

                            throw new StoreCannotBeFoundException("Store cannot be found.");

                            break;
                        }

                        if (stopper > 0)
                        {
                            break;
                        }
                    }
                }
                catch(StoreCannotBeFoundException ex)
                {
                    Console.WriteLine($"Error {ex.Message}.");
                }
                

                break;
            }
        }
    }
}
