using System;
using AppKit;

namespace NSTableViewSample
{
    public class PersonTableDelegate:NSTableViewDelegate
    {
        private readonly PersonDataSource ds;
        public PersonTableDelegate(PersonDataSource ds)
        {
            this.ds = ds;
        }
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            var item = ds.Items[(int)row];
            var view = (NSTableCellView)tableView.MakeView(tableColumn.Identifier,this);

            switch(tableColumn.Identifier){
                case "Name":
                    view.TextField.StringValue = item.Name;
                    break;
                case "Mail":
                    view.TextField.StringValue = item.Mail;
                    break;
                default:
                    throw new ArgumentException(nameof(tableColumn));
            }
            return view;
        }
    }
}
