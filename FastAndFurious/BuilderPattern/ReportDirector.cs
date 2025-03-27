using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class ReportDirector
    {
        private ReportFactory reportFactory;

        public ReportDirector(ReportFactory reportFactory)
        {
            this.reportFactory = reportFactory;
        }

        public string CreateReportBasedOnParameters(string command)
        {
            if (command == "s")
            {
                return reportFactory.CreateSimpleReport();
            }
            else if (command == "f")
            {
                return reportFactory.CreateFullReport();
            }
            else
            {
                throw new NotSupportedException(command);
            }
        }
    }
}
