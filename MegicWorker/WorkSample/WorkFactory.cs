using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace WorkSample
{
    public class WorkFactory
    {
        private Worker _worker;       
        private delegate void working();
        private List<working> _workinglist;

        private DataEntity _dataEntity;
        private DistinationEntity _distinationEntity;

        public WorkFactory(Worker worker, DataEntity dataEntity)
        {
            _worker = worker;
            _dataEntity = dataEntity;
            _workinglist = new List<working>();
            _distinationEntity = new DistinationEntity();
        }

        public WorkFactory AddConfig(Action<List<string>> getConfig)
        {
            working _working = (() =>
            {
                List<string> config = new List<string>();
                getConfig(config);

                var dataFilter = _worker.Filter(config, _dataEntity);

                _worker.GetResult(dataFilter, _distinationEntity);
            });
            _workinglist.Add(_working);
            return this;
        }

        public DistinationEntity Run()
        {
            foreach (var work in _workinglist)
            {
                work();
            }
            return _distinationEntity;
             
        }


    }
}
