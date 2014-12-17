using System;
using System.Collections.Generic;
using ReadDataAccessModel;

namespace ReadDataFromAccessClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press an key when the service is Ready");
            Console.ReadKey(true);
            decimal result = 0;

            //---------------------------·½Ê½Ò»

            using (ReadDataClient proxy = new ReadDataClient("BasicHttpBinding_IReadData"))
            {
                //proxy.Open();
                //DataFromAccess[] obj = proxy.ReadRecords(Convert.ToDateTime("2009-6-14"));
                DataFromAccess[] obj = proxy.ReadRecordsWithReadTime(Convert.ToDateTime("2009-6-14"), Convert.ToDateTime("2009-6-19"));
                Console.WriteLine(obj.Length.ToString());
                Console.WriteLine(obj[0].CardNo);
                Console.WriteLine(obj[0].InOrOut);
                Console.WriteLine(obj[0].IOTime);
                Console.WriteLine(obj[obj.Length-1].CardNo);
                Console.WriteLine(obj[obj.Length-1].InOrOut);
                Console.WriteLine(obj[obj.Length-1].IOTime);
            }



            Console.WriteLine(string.Format("Result:{0}", result));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }

        public List<DataFromAccess> ReadRecords(DateTime laseReadTime)
        {
            List<DataFromAccess> DataFromAccessList = new List<DataFromAccess>();
            using (ReadDataClient proxy = new ReadDataClient("BasicHttpBinding_IReadData"))
            {
                //proxy.Open();
                DataFromAccess[] obj = proxy.ReadRecords(laseReadTime);
                //for (int i = 0; i < obj.Length; i++)
                //{
                //    InOutStatusEnum inOut;
                //    switch (obj[i].InOrOut)
                //    {
                //        case ReadDataAccessModel.InOutStatusEnum.In:
                //            inOut = InOutStatusEnum.In;
                //            break;
                //        case ReadDataAccessModel.InOutStatusEnum.Out:
                //            inOut = InOutStatusEnum.Out;
                //            break;
                //        default:
                //            inOut = InOutStatusEnum.All;
                //    }
                //}
                return DataFromAccessList;
            }
        }

    }
}
