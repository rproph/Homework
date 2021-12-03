using System;

namespace ConsoleApp2
{
    public class Shops
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PhoneData[] Phones { get; set; }
        public void FindAvailablePhonesCount()
        {
            int iosCount = 0;
            int androidCount = 0;

            foreach (PhoneData phone in Phones)
            {
                if (phone.IsAvailable == true)
                {
                    if (phone.OperationSystemType.Equals("IOS"))
                    {
                        iosCount++;
                    }
                    else if (phone.OperationSystemType.Equals("Android"))
                    {
                        androidCount++;
                    }
                }
            }

            Console.WriteLine($"Shop Id: {Id}, shop name : {Name}. \nDescription : {Description}. \nAvailable IOS phones count : {iosCount} \nAvailable Android phones count : {androidCount}");
        }
    }
}
