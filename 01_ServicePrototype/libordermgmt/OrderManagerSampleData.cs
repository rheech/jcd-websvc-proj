using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libordermgmt
{
    public class OrderManagerSampleData : OrderManager
    {
        public OrderManagerSampleData() : base()
        {
            this.Reset();

            CustomerInfo info = new CustomerInfo();
            info.CompanyName = "Dell Korea";
            info.Address = "서울특별시 강남구 강남대로 298 푸르덴셜타워 12층 델 인터내셔널";
            info.EMail = "email_kr@dell.com";

            this.InsertCustomer(info);

            info = new CustomerInfo();
            info.CompanyName = "White House";
            info.Address = "1600 Pennsylvania Ave NW, Washington, DC 20500";
            info.EMail = "sample@email.com";
            
            this.InsertCustomer(info);

            info = new CustomerInfo();
            info.CompanyName = "KAIST";
            info.Address = "291 Daehak-ro, Yuseong-gu, Daejeon, South Korea";
            info.EMail = "kaist@emailsample.com";

            this.InsertCustomer(info);

            // http://www.bluelinemedia.com/bus-advertising
            AdService service = new AdService();
            service.ServiceName = "Bus Exterior";
            service.Price = 20000;

            this.InsertAdService(service);

            service = new AdService();
            service.ServiceName = "Bus Interior";
            service.Price = 25000;

            this.InsertAdService(service);

            service = new AdService();
            service.ServiceName = "Bus Stop / Bus Shelter";
            service.Price = 50000;

            this.InsertAdService(service);

            service = new AdService();
            service.ServiceName = "Bench";
            service.Price = 15000;

            this.InsertAdService(service);

            BusStopInfo[] bus = GetBusStopList();

            foreach (BusStopInfo b in bus)
            {
                InsertBusStop(b);
            }
        }

        private BusStopInfo[] GetBusStopList()
        {
            BusStopInfo busStop;
            List<BusStopInfo> busStopList;
            string[] list;
            string[] line;

            list = System.IO.File.ReadAllLines("bus_stops_data.txt", System.Text.Encoding.UTF8);
            busStopList = new List<BusStopInfo>();

            foreach (string s in list)
            {
                line = s.Split('|');

                //04-236|뚝섬역8번출구|Ttukseom Station Exit 8
                busStop = new BusStopInfo();
                busStop.BusStopID = line[0];
                busStop.NameKor = line[1];

                // if english name exists
                if (line.Length > 2)
                {
                    busStop.NameEng = line[2].ToLower();
                }

                busStopList.Add(busStop);
            }

            return busStopList.ToArray();
        }
    }
}
