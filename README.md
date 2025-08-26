# How to load data on demand using command in WinUI TreeGrid

This example describes how to load data on demand using command in [WinUI TreeGrid](https://www.syncfusion.com/winui-controls/treegrid) (SfTreeGrid).

## Load on demand using command

`SfTreeGrid` allows you to load child items only when they are requested to load on-demand. Initially populate the root Nodes by assigning `SfTreeGrid.ItemsSource` and then when any node is expanded, child items can be loaded using [SfTreeGrid.LoadOnDemandCommand](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_LoadOnDemandCommand).

### Handling expander visibility

`SfTreeGrid` shows the expander for a particular node based on return value of [CanExecute](https://docs.microsoft.com/en-us/dotnet/api/system.windows.input.icommand.canexecute?view=netframework-4.8) method of `LoadOnDemandCommand`. If `CanExecute` returns `true`, then expander icon is displayed for that node. If `CanExecute` returns `false`, then expander icon will not displayed for that node. `CanExecute` method gets called to decide the visibility of expander icon and before executing `LoadOnDemandCommand`.

``` csharp
public bool CanExecute(object parameter)
{
    TreeNode node = (parameter as TreeNode);
    EmployeeInfo emp = node.Item as EmployeeInfo;
    if (emp != null)
        if (emp.ReportsTo == -1 || emp.ReportsTo == 34 || emp.ReportsTo == 36 || emp.ReportsTo == 65)
            return true;
    return false;
}
```

### On-demand loading of child items

You can load child items for the node in [Execute](https://docs.microsoft.com/en-us/dotnet/api/system.windows.input.icommand.execute?view=netframework-4.8) method of `LoadOnDemandCommand`. Execute method will get called when user expands the tree node. In execute method, you can populate the child nodes by calling [TreeNode.PopulateChildNodes](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.TreeGrid.TreeNode.html#Syncfusion_UI_Xaml_TreeGrid_TreeNode_PopulateChildNodes) method by passing the child items collection.

``` csharp
MainPage page;
public void Execute(object parameter)
{
    TreeNode node = (parameter as TreeNode);
    page = new MainPage();
    EmployeeInfo emp = node.Item as EmployeeInfo;
    if (emp != null)
    {
        node.PopulateChildNodes((page.DataContext as ViewModel).GetReportees(emp.ID));
    }
}
```
