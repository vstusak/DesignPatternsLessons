﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("BuilderPatternTests")]
namespace BuilderPattern
{
    public class SimpleReportBuilder : IReportBuilder
    {
        internal StringBuilder _report = new StringBuilder();
        private IDateTimeProvider _myDateTimeProvider;

        public SimpleReportBuilder(IDateTimeProvider dateTimeProvider)
        {
            _myDateTimeProvider = dateTimeProvider;
        }

        public IReportBuilder Reset()
        {
            _report.Clear();
            return this;
        }

        public IReportBuilder SetHeader()
        {
            _report.AppendLine("Header");
            return this;
        }

        public IReportBuilder SetAddress(string address)
        {
            _report.AppendLine(address);
            return this;
        }

        public IReportBuilder CreateList(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                _report.AppendLine($"{book.Name} by {book.Author}, {book.NumberOfPages} pages");
            }
            return this;
        }

        public IReportBuilder SetTimeStamp()
        {
            _report.AppendLine(_myDateTimeProvider.Now.ToString());
            return this;
        }

        public IReportBuilder SetFooter()
        {
            _report.AppendLine("Footer");
            return this;
        }

        public string Build()
        {
            return _report.ToString();
        }
    }
}