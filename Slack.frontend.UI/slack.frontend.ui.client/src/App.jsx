/* Commented default code about Weather forecast.   
//import { useEffect, useState } from 'react';
//import './App.css';

//function App() {
//    const [forecasts, setForecasts] = useState();

//    useEffect(() => {
//        populateWeatherData();
//    }, []);

//    const contents = forecasts === undefined
//        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//        : <table className="table table-striped" aria-labelledby="tableLabel">
//            <thead>
//                <tr>
//                    <th>Date</th>
//                    <th>Temp. (C)</th>
//                    <th>Temp. (F)</th>
//                    <th>Summary</th>
//                </tr>
//            </thead>
//            <tbody>
//                {forecasts.map(forecast =>
//                    <tr key={forecast.date}>
//                        <td>{forecast.date}</td>
//                        <td>{forecast.temperatureC}</td>
//                        <td>{forecast.temperatureF}</td>
//                        <td>{forecast.summary}</td>
//                    </tr>
//                )}
//            </tbody>
//        </table>;

//    return (
//        <div>
//            <h1 id="tableLabel">Weather forecast</h1>
//            <p>This component demonstrates fetching data from the server.</p>
//            {contents}
//        </div>
//    );
    
//    async function populateWeatherData() {
//        const response = await fetch('weatherforecast');
//        if (response.ok) {
//            const data = await response.json();
//            setForecasts(data);
//        }
//    }
//}

//export default App;

*/

import React, { useEffect, useState, useRef } from 'react';
import ChannelList from './components/ChannelList';
import ChatWindow from './components/ChatWindow';
import MessageInput from './components/MessageInput';
import * as api from './api';
import * as signalR from '@microsoft/signalr';

// MOCK: replace with real authentication (MSAL/AD) if needed
const mockUser = { id: "11111111-1111-1111-1111-111111111111", displayName: "Alice" };
const mockToken = "<JWT_TOKEN_FROM_AZURE_AD>"; // Replace with real token

function App() {
    const [channels, setChannels] = useState([]);
    const [currentChannel, setCurrentChannel] = useState(null);
    const [messages, setMessages] = useState([]);
    const [signalRConnection, setSignalRConnection] = useState(null);

    // Fetch channels on mount
    useEffect(() => {
        api.fetchChannels(mockToken).then(setChannels);
    }, []);

    // Fetch messages for the selected channel
    useEffect(() => {
        if (!currentChannel) return;
        api.fetchMessages(currentChannel.id, mockToken).then(setMessages);
        // Join channel group on SignalR
        if (signalRConnection) {
            signalRConnection.invoke("JoinChannel", currentChannel.id);
        }
    }, [currentChannel, signalRConnection]);

    // Setup SignalR
    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:5001/hubs/message", {
                accessTokenFactory: () => mockToken
            })
            .withAutomaticReconnect()
            .build();

        connection.start()
            .then(() => setSignalRConnection(connection))
            .catch(err => console.error('SignalR Connection Error:', err));

        return () => {
            connection.stop();
        };
    }, []);

    // Send message handler
    const handleSendMessage = (text, fromSignalR = false) => {
        if (!currentChannel) return;
        const message = {
            channelId: currentChannel.id,
            userId: mockUser.id,
            user: mockUser.displayName,
            text,
            timestamp: new Date().toISOString()
        };
        if (!fromSignalR && signalRConnection) {
            signalRConnection.invoke("SendMessage", currentChannel.id, mockUser.displayName, text);
            api.postMessage(message, mockToken);
        }
        setMessages(prev => [...prev, message]);
    };

    return (
        <div style={{ display: 'flex', minHeight: '100vh', fontFamily: 'Arial' }}>
            <div style={{ width: 220, background: '#f4f4f4', padding: 16 }}>
                <ChannelList
                    channels={channels}
                    current={currentChannel}
                    onSelect={setCurrentChannel}
                />
            </div>
            <div style={{ flex: 1, display: 'flex', flexDirection: 'column', padding: 16 }}>
                {currentChannel ? (
                    <>
                        <ChatWindow
                            channel={currentChannel}
                            messages={messages}
                            user={mockUser}
                            onSend={handleSendMessage}
                            signalRConnection={signalRConnection}
                        />
                        <MessageInput onSend={handleSendMessage} />
                    </>
                ) : (
                    <div>Select a channel to start chatting.</div>
                )}
            </div>
        </div>
    );
}

export default App;

