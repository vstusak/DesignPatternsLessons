using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class DataLoader
    {
        private IEnumerable<ExpensiveResult> _data1 => DataSource.GetEntities();
        private IEnumerable<ExpensiveResult> _data2 => DataSource.GetEntities();

        public virtual IEnumerable<ExpensiveResult> Data1 => _data1;
        public virtual IEnumerable<ExpensiveResult> Data2 => _data2;
    }

    public class VirtualProxyDataLoader : DataLoader
    {
        private IEnumerable<ExpensiveResult> _cacheData1;
        private IEnumerable<ExpensiveResult> _cacheData2;

        public override IEnumerable<ExpensiveResult> Data1 => _cacheData1 ??= base.Data1;
        public override IEnumerable<ExpensiveResult> Data2 => _cacheData2 ??= base.Data2;
    }

    public class LazyDataLoader
    {
        private readonly Lazy<IEnumerable<ExpensiveResult>> _data1;
        private readonly Lazy<IEnumerable<ExpensiveResult>> _data2;

        public IEnumerable<ExpensiveResult> Data1 => _data1.Value;

        public IEnumerable<ExpensiveResult> Data2 => _data2.Value;

        public LazyDataLoader()
        {
            _data1 = new Lazy<IEnumerable<ExpensiveResult>>(DataSource.GetEntities);
            _data2 = new Lazy<IEnumerable<ExpensiveResult>>(DataSource.GetEntities);
        }
    }
}
