The Source code in this reopsitory is developed as part of a system design interview question 

Folder structure of this project and solution: 
Slack.WebAPI/


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
