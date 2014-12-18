<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoList.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todos</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Categories</h1>
        <asp:ListView runat="server" 
            ID="lvCategories" 
            ItemType="_03.Todo.Models.Category" 
            DataKeyNames="Id" 
            DeleteMethod="lvCategories_DeleteItem" 
            InsertMethod="lvCategories_InsertItem"
            InsertItemPosition="None"  
            UpdateMethod="lvCategories_UpdateItem" 
            SelectMethod="lvCategories_GetData">
            <LayoutTemplate>
                <table runat="server" id="View" >
                <tr runat="server">
                    <th runat="server">Id</th>
                    <th runat="server">Name</th>
                    <th></th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
                <asp:Button ID="InsertCategoryFormBtn" runat="server" Text="Insert Category" OnClick="InsertCategoryFormBtn_Click"/>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Item.Id %></td>
                    <td><%#: Item.Name %></td>
                    <td><asp:Button ID="EditCategory" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteCategory" runat="server" CommandName="Delete" Text="Delete" />
                    </td>
            </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <td>No categories</td>
                <td><asp:Button ID="InsertCategoryFormBtn" runat="server" Text="Insert Category" OnClick="InsertCategoryFormBtn_Click"/></td>
            </EmptyDataTemplate>
            <EditItemTemplate>
            <tr>
                <td>
                    <%# Item.Id %>
                </td>
                <td>
                    <asp:TextBox runat="server" Text='<%#: Bind("Name") %>' ID="CategoryNameTextBox" />
                </td>
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" CommandArgument="<%# Item.Id %>" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <td>
            </td>
            <td>
                <asp:TextBox runat="server" Text='<%#: Bind("Name") %>' ID="CategoryCreateNameTextBox" />
            </td>
            <td>
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Save" />
                <asp:Button ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Cancel" />
            </td>
        </InsertItemTemplate>
        </asp:ListView>
        <h1>Todos</h1>
        <asp:ListView runat="server" 
            ID="ListViewTodos" 
            ItemType="_03.Todo.Models.TodoTask" 
            DataKeyNames="Id" 
            DeleteMethod="ListViewTodos_DeleteItem" 
            InsertMethod="ListViewTodos_InsertItem"
            InsertItemPosition="None"  
            UpdateMethod="ListViewTodos_UpdateItem"
            SelectMethod="ListViewTodos_GetData">
            <LayoutTemplate>
                <table runat="server" id="View2" >
                <tr runat="server">
                    <th runat="server">Id</th>
                    <th runat="server">Title</th>
                    <th runat="server">Body</th>
                    <th runat="server">Last Modified</th>
                    <th runat="server">Category</th>
                    <th></th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
                <asp:Button ID="InsertTodoFormBtn" runat="server" Text="Insert Todo" OnClick="InsertTodoFormBtn_Click"/>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Item.Id %></td>
                    <td><%#: Item.Title %></td>
                    <td><%#: Item.Body %></td>
                    <td><%#: Item.LastModified %></td>
                    <td><%#: Item.Category.Name %></td>
                    <td><asp:Button ID="EditTodo" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteTodo" runat="server" CommandName="Delete" Text="Delete" />
                    </td>
            </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <td>No Todos</td>
                <td><asp:Button ID="InsertTodoFormBtn" runat="server" Text="Insert Todo" OnClick="InsertTodoFormBtn_Click"/></td>
            </EmptyDataTemplate>
            <EditItemTemplate>
            <tr>
                <td>
                    <%# Item.Id %>
                </td>
                <td>
                    <asp:TextBox runat="server" Text='<%#: Bind("Title") %>' ID="TodoTitleTextBox" />
                </td>
                <td>
                    <asp:TextBox runat="server" Text='<%#: Bind("Body") %>' ID="TodoBodyTextBox" />
                </td>
                <td></td>
                <td>
                    <asp:TextBox runat="server" Text='<%#: Bind("CategoryId") %>' ID="TodoCategoryIdTextBox" />
                </td>
                <td>
                    <asp:Button ID="UpdateButton1" runat="server" CommandName="Update" CommandArgument="<%# Item.Id %>" Text="Update" />
                    <asp:Button ID="CancelButton1" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <td>
            </td>
            <td>
                <asp:TextBox runat="server" Text='<%#: Bind("Title") %>' ID="TodoTitleTextBox" />
            </td>
            <td>
                <asp:TextBox runat="server" Text='<%#: Bind("Body") %>' ID="TodoBodyTextBox" />
            </td>
            <td></td>
            <td>
                <asp:TextBox runat="server" Text='<%#: Bind("CategoryId") %>' ID="TodoCategoryIdTextBox" />
            </td>
            <td>
                <asp:Button ID="InsertButton1" runat="server" CommandName="Insert" Text="Save" />
                <asp:Button ID="CancelButton1" runat="server" OnClick="CancelButton1_Click" Text="Cancel" />
            </td>
        </InsertItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource runat="server" DataObjectTypeName="_03.Todo.Models.Category" ID="ListCategories" ></asp:ObjectDataSource>
    </form>
</body>
</html>
