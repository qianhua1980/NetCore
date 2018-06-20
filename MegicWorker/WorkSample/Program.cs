using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkSample
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = GetConfig();
            var data = GetData();

            //var filterData = from s1 in data.DataList
            //        join s2 in config on s1.Name equals s2
            //        select s1;

            //var distinationEntity = new DistinationEntity();

            //distinationEntity.DistinationDataList = filterData.Select(x => new DistinationEntityItem { DistinationName = x.Name, DistinationCode = x.Code   }).ToList();



            //var b = filterData;

            var workFactory = new WorkFactory(new Worker(), data);
                workFactory.AddConfig(a => GetConfig1(a)).AddConfig(a => GetConfig2(a));
            var b = workFactory.Run();

            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }

        public static List<string> GetConfig()
        {
            var list = new List<string>()
            {
                "a", "b", "c"
            };
            return list;
        }

        public static void GetConfig1(List<string> config)
        {
            config.Add("a");
            config.Add("b");
            config.Add("c");
        }

        public static void GetConfig2(List<string> config)
        {
            config.Add("d");
        }

        public static DataEntity GetData()
        {
            var data = new DataEntity
            {
                DataList = new List<DataEntityItem>
                {
                    new DataEntityItem{ Name = "a", Code = "code1", Description = "a-code1"},
                    new DataEntityItem{ Name = "b", Code = "code2", Description = "a-code2"},
                    new DataEntityItem{ Name = "c", Code = "code3", Description = "a-code3"},
                    new DataEntityItem{ Name = "d", Code = "code4", Description = "a-code4"},
                    new DataEntityItem{ Name = "e", Code = "code5", Description = "a-code5"},
                    new DataEntityItem{ Name = "f", Code = "code6", Description = "a-code6"},
                }
            };
            return data;
        }


    }

    public class DataEntity
    {
        public List<DataEntityItem> DataList { get; set; }
    }

    public class DataEntityItem
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }

    public class DistinationEntity
    {
        public List<DistinationEntityItem> DistinationDataList { get; set; }
    }

    public class DistinationEntityItem
    {
        public string DistinationName { get; set; }

        public string DistinationCode { get; set; }
    }


}
