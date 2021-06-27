# Ugly Calculator
<p>The calculator is a Visual Studio 2019 solution. You can either download the code, clone the repo or simply choose to open in Visual Studio.</p> 
<p>The tech is ASP.NET Core 5 (.NET 5) using a InMemory database included in EntityFramework Core 5 </p>
<p>Press F5 to run i debug mode.</p>

<h2>How it works</h2>
<p>The solution reads registers from a file into a InMemory database. The database resets on every "run" from Visual Studio, so you start 
with fresh data on every time you run the application.</p>
<p>The application starts in calculator view. From the menu you can access "Register", where you have CRUD operations available for data in the database. 
You also have access to "Print Register" where you can print output for the current value of the selected register.</p>
<p>Logging information will appear in "Output" console within Visual Studio</p>

<h2>User Inteface</h2>
<p>No design changes or manipulation have been done in the layout for the application. Ugly Calculator uses the design included in a new ASP.NET Core application from Visual Studio</p>
<p>For simplicity I seperated "Print" function to a different view (Print Register), this just to minimize the time spent. Did not seem like a important detail.</p>
