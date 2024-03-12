Test Task for Developer Task Description
Create a web app, for managing sales order data.
Requirements
1. Create new database tables Using Code First In Entity Framework.
2. Blazor WebAssembly app with an interface to show data from DB.
3. Make an ability to change and save data in the application: state, name, and dimensions.
4. Add the ability to create and delete orders, windows and elements.
5. Optional: Interface validations. DTO. Separated BLL and DAL projects.
Provide source code with all necessary information to run and test the application. Test data for storing into the database:

```
<Orders>
<Order Name="New York Building 1" State="NY">
<Windows>
<Window Name="A51" QuantityOfWindows="4" TotalSubElements="3">
<SubElements>
<SubElement Element="1" Type="Doors" Width="1200" Height="1850" /> <SubElement Element="2" Type="Window" Width="800" Height="1850" /> <SubElement Element="3" Type="Window" Width="700" Height="1850" />
</SubElements> </Window>
<Window Name="C Zone 5" QuantityOfWindows="2" TotalSubElements="1"> <SubElements>
<SubElement Element="1" Type="Window" Width="1500" Height="2000" /> </SubElements>
</Window> </Windows>
</Order>
<Order Name="California Hotel AJK" State="CA">
</Order> </Orders>
```