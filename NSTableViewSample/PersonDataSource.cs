using System;
using System.Collections.Generic;
using AppKit;

namespace NSTableViewSample
{
    public class PersonDataSource : NSTableViewDataSource
    {
        public PersonDataSource(List<Person> items)
        {
            Items = items;
        }
        public List<Person> Items { get; }

        public override nint GetRowCount(NSTableView tableView) => Items.Count;
    }
}
