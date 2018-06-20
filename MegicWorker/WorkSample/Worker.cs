using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WorkSample
{
    public class Worker
    {
        public List<DataEntityItem> Filter(List<string> config, DataEntity data)
        {
            var filterData = from s1 in data.DataList
                             join s2 in config on s1.Name equals s2
                             select s1;
            return filterData.ToList();
        }

        public void GetResult(List<DataEntityItem> filterData, DistinationEntity distinationEntity)
        {
            if (distinationEntity.DistinationDataList == null) distinationEntity.DistinationDataList = new List<DistinationEntityItem>();
            distinationEntity.DistinationDataList.AddRange(filterData.Select(x => new DistinationEntityItem { DistinationName = x.Name, DistinationCode = x.Code }).ToList());
        }
    }
}
