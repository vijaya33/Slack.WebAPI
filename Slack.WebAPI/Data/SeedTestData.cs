using Slack.WebAPI.Models;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Slack.WebAPI.Data
{
    public class SeedTestData
    {  

        /**

            --Users
                INSERT INTO Users(Id, DisplayName, Email)
                VALUES(NEWID(), 'Alice Johnson', 'alice@example.com'),
                (NEWID(), 'Bob Smith', 'bob@example.com');

            --Channels
                INSERT INTO Channels(Id, Name, IsPrivate)
                VALUES(NEWID(), 'general', 0),
                (NEWID(), 'random', 0);

            --(Find the actual IDs using SELECTs or update below with the actual GUIDs generated)
            -- UserChannel(Alice in general)
                INSERT INTO UserChannels(UserId, ChannelId)
                SELECT u.Id, c.Id
                FROM Users u, Channels c
                WHERE u.Email= 'alice@example.com' AND c.Name= 'general';

            --Messages
                INSERT INTO Messages(Id, ChannelId, UserId, Text, Timestamp)
                SELECT NEWID(), c.Id, u.Id, 'Welcome to the general channel!', SYSDATETIMEOFFSET()
                FROM Users u, Channels c
                WHERE u.Email='alice@example.com' AND c.Name= 'general';
        **/

}
}