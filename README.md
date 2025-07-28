The Source code in this reopsitory is developed as part of a system design approach. 

How to run the project / application: 
Step 1: Create a new folder Slack.WebAPI and add the above files/folders as shown.

Step 2: Add all necessary NuGet packages in Visual Studio, below is a list of necessary packages for this application:

    1. Microsoft.EntityFrameworkCore.SqlServer

    2. Microsoft.Identity.Web

    3. Microsoft.AspNetCore.SignalR

    4. Swashbuckle.AspNetCore

Update appsettings.json with your Azure AD and SQL Server details.

************************ Build and run the solution!    *************************

Folder structure of (Backend) this project and solution: 
Slack.WebAPI/
Slack React Clone. (Clone of exisiting Slack application.)

├── Controllers/
│   ├── UserController.cs
│   ├── ChannelController.cs
│   └── MessageController.cs


├── Data/
│   ├── SlackDbContext.cs
│   └── DbInitializer.cs


├── Hubs/
│   └── MessageHub.cs


├── Models/
│   ├── User.cs
│   ├── Channel.cs
│   ├── Message.cs
│   └── UserChannel.cs



├── Services/
│   └── (add business logic here if needed)
├── appsettings.json
├── Program.cs
├── Startup.cs


├── Slack.WebAPI.csproj

Folder structure of (Frontend) this project and solution with HTML, React and JavaScript:  

slack-frontend/

'
├── public/
│   └── index.html


└── src/
    ├── App.js
   
    ├── components/
    
        │   ├── ChannelList.js
        │   ├── ChatWindow.js
        │   └── MessageInput.js
    ├── api.js
    └── index.js


Contributing to this project Pull requests and feedback are welcome. Please fork the repository and submit a pull request with your enhancements

License This project is open source and available under MIT License.

Built By Vijaya Laxmi Kumbaji Cloud Architect | Senior .NET Developer | Lead .NET Developer | Full stack Developer / Python AI/ML Developer |
